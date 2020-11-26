// <copyright file="WebhookClient.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Bot
{
    using System;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using HtmlAgilityPack;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Telegram.Bot;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;
    using Telegram.Bot.Types.ReplyMarkups;

    /// <summary>
    /// Represents the handler of web hook requests.
    /// </summary>
    public class WebhookClient
    {
        private readonly ITelegramBotClient client;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookClient"/> class.
        /// </summary>
        /// <param name="token">The token of the bot.</param>
        /// <param name="logger">The instance of the logger.</param>
        public WebhookClient(string token, ILogger logger)
        {
            this.client = new TelegramBotClient(token);
            this.logger = logger;
        }

        /// <summary>
        /// Processes client request from the web hook.
        /// </summary>
        /// <param name="request">The HTTP request from the client.</param>
        /// <returns>The task that processes a request.</returns>
        public Task Update(string request)
        {
            this.logger.LogInformation($"{nameof(WebhookClient)} {request}");

            var update = JsonConvert.DeserializeObject<Update>(request);
            return this.HandleUpdate(update);
        }

        private static string GetInnerTextValue(HtmlNode node)
        {
            return WebUtility.HtmlDecode(node.InnerText.Trim());
        }

        private async Task HandleUpdate(Update update)
        {
            this.logger.LogInformation($"{nameof(WebhookClient)} HandleUpdate");

            switch (update.Type)
            {
                case UpdateType.Message:
                    await this.OnMessageHandler(update).ConfigureAwait(false);
                    break;
                case UpdateType.CallbackQuery:
                    await this.OnCallbackQueryHandler(update).ConfigureAwait(false);
                    break;
            }
        }

        private async Task OnMessageHandler(Update update)
        {
            if (string.IsNullOrEmpty(update.Message.Text))
            {
                return;
            }

            this.Log(
                $"[{update.Message.Chat.Id}] "
                + $"[{update.Message.Chat.Username} "
                + $"{update.Message.Chat.FirstName}] "
                + $"[{update.Message.Chat.LastName}]");

            switch (update.Message.Text.Trim())
            {
                case "/start":
                case "/forecast":
                    await this.OnForecastAsync(update.Message.Chat.Id)
                        .ConfigureAwait(false);
                    break;
                default:
                    await this.client.SendTextMessageAsync(
                            chatId: update.Message.Chat,
                            text: $"Invalid command: {update.Message.Text}")
                        .ConfigureAwait(false);

                    break;
            }
        }

        private async Task OnCallbackQueryHandler(Update update)
        {
            if (string.IsNullOrEmpty(update.CallbackQuery.Data))
            {
                return;
            }

            this.Log(
                $"[{update.CallbackQuery.Message.Chat.Id}] "
                + $"[{update.CallbackQuery.Message.Chat.Username}] "
                + $"[{update.CallbackQuery.Message.Chat.FirstName} "
                + $"{update.CallbackQuery.Message.Chat.LastName}] "
                + $"[{update.CallbackQuery.Message.MessageId}]");

            try
            {
                await this.client.EditMessageReplyMarkupAsync(
                    update.CallbackQuery.Message.Chat.Id,
                    update.CallbackQuery.Message.MessageId).ConfigureAwait(false);
            }
            catch (AggregateException ex)
            {
                this.logger.LogError(ex.ToString());
            }

            switch (update.CallbackQuery.Data.Trim())
            {
                case "start":
                case "forecast":
                    await this.OnForecastAsync(update.CallbackQuery.Message.Chat.Id)
                        .ConfigureAwait(false);
                    break;
                default:
                    await this.client.SendTextMessageAsync(
                            chatId: update.CallbackQuery.Message.Chat,
                            text: $"Invalid command: {update.CallbackQuery.Data}")
                        .ConfigureAwait(false);

                    break;
            }
        }

        private async Task OnForecastAsync(long chatId)
        {
            var web = new HtmlWeb();
            var document = web.Load(new Uri("http://meteo.paraplan.net/forecast/summary.html?place=3148"));

            var hours = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, 'hour')])");
            var temperatures = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, '213')])");
            var wind_dirs = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, 'wind_dir ')])");
            var winds = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, 'wind ')])");
            var wind_gusts = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, '332 ')])");
            var precipitation = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, '222 ')])");
            var humidity = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, '215 ')])");

            var culture = new System.Globalization.CultureInfo("ru-RU");

            var builder = new StringBuilder();
            int hour = 0;
            int day = 0;

            builder
                .Append("*Время, Температура, Ветер, Поровы, Влажность, Осадки*\n\n")
                .Append($"*{DateTime.Today.Day} - ")
                .Append($"{culture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek)}*\n")
                .Append("```\n");
            for (var index = 0; index < hours.Count; ++index)
            {
                if (hour == 8)
                {
                    hour = 0;
                    day = day + 1;
                    builder
                        .Append($"```\n\n*{DateTime.Today.AddDays(day).Day} - ")
                        .Append($"{culture.DateTimeFormat.GetDayName(DateTime.Today.AddDays(day).DayOfWeek)}*\n```\n");
                }

                builder
                    .Append($"{GetInnerTextValue(hours[index])}, ")
                    .Append($"{GetInnerTextValue(temperatures[index]),3}, [")
                    .Append($"{GetInnerTextValue(wind_dirs[index]).ToUpperInvariant(),3}, ")
                    .Append($"{GetInnerTextValue(winds[index])}, ")
                    .Append($"{GetInnerTextValue(wind_gusts[index]),2}], ")
                    .Append($"{GetInnerTextValue(humidity[index])}, ")
                    .Append($"{GetInnerTextValue(precipitation[index])}\n");

                hour = hour + 1;
            }

            builder.Append("```");

            var keyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    new InlineKeyboardButton() { Text = "Повторить запрос", CallbackData = "forecast" },
                },
            });

            await this.client.SendTextMessageAsync(
                chatId: chatId,
                text: builder
                    .ToString()
                    .Replace("<", "\\<", StringComparison.InvariantCulture)
                    .Replace(">", "\\>", StringComparison.InvariantCulture)
                    .Replace("+", "\\+", StringComparison.InvariantCulture)
                    .Replace("-", "\\-", StringComparison.InvariantCulture)
                    .Replace(".", "\\.", StringComparison.InvariantCulture)
                    .Replace("|", "\\|", StringComparison.InvariantCulture),
                replyMarkup: keyboard,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.MarkdownV2).ConfigureAwait(false);
        }

        private void Log(string message)
        {
            // await MissionMonitor.Publish($"{nameof(ParaglidingWeather)} {message}");
            this.logger.LogInformation(message);
        }
    }
}
