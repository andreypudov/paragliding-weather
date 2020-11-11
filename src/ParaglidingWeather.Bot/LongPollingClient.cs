// <copyright file="LongPollingClient.cs" company="Andrey Pudov">
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
    using Telegram.Bot;
    using Telegram.Bot.Args;
    using Telegram.Bot.Types.ReplyMarkups;

    /// <summary>
    /// Represents a console running instance for the application.
    /// </summary>
    public class LongPollingClient
    {
        private readonly ITelegramBotClient client;
        private readonly ILogger<LongPollingClient> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LongPollingClient"/> class.
        /// </summary>
        /// <param name="configuration">The instance of a application configuration.</param>
        /// <param name="logger">The instance of an application logger.</param>
        public LongPollingClient(WeaherBotConfiguration configuration, ILogger<LongPollingClient> logger)
        {
            // TODO
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.client = new TelegramBotClient(configuration.Token);
            this.logger = logger;
        }

        /// <summary>
        /// The main entry point for the bot.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "To be added later.")]
        public void Run()
        {
            this.client.OnMessage += this.OnMessageHandler;
            this.client.OnCallbackQuery += this.OnCallbackQueryHandler;
            this.client.StartReceiving();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            this.client.StopReceiving();
        }

        private static string GetInnerTextValue(HtmlNode node)
        {
            return WebUtility.HtmlDecode(node.InnerText.Trim());
        }

        private async void OnMessageHandler(object? sender, MessageEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Message.Text))
            {
                return;
            }

            this.logger.LogInformation(
                $"Received a text message in chat "
                + $"{e.Message.Chat.Id} "
                + $"{e.Message.Chat.Username} "
                + $"{e.Message.Chat.FirstName} "
                + $"{e.Message.Chat.LastName}");

            switch (e.Message.Text.Trim())
            {
                case "/forecast":
                    await this.OnForecastAsync(e.Message.Chat.Id)
                        .ConfigureAwait(false);
                    break;
                default:
                    await this.client.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: $"Invalid command: {e.Message.Text}")
                        .ConfigureAwait(false);

                    break;
            }
        }

        private async void OnCallbackQueryHandler(object? sender, CallbackQueryEventArgs e)
        {
            if (string.IsNullOrEmpty(e.CallbackQuery.Data))
            {
                return;
            }

            this.logger.LogInformation(
                $"Received a text message in chat "
                + $"{e.CallbackQuery.Message.Chat.Id} "
                + $"{e.CallbackQuery.Message.Chat.Username} "
                + $"{e.CallbackQuery.Message.Chat.FirstName} "
                + $"{e.CallbackQuery.Message.Chat.LastName} "
                + $"{e.CallbackQuery.Message.MessageId}");

            /* await this.client.AnswerCallbackQueryAsync(
                e.CallbackQuery.Id,
                "Received a text message " + e.CallbackQuery.Data).ConfigureAwait(false); */
            try
            {
                await this.client.EditMessageReplyMarkupAsync(
                    e.CallbackQuery.Message.Chat.Id,
                    e.CallbackQuery.Message.MessageId).ConfigureAwait(false);
            }
            catch (AggregateException ex)
            {
                this.logger.LogError(ex.ToString());
            }

            switch (e.CallbackQuery.Data.Trim())
            {
                case "forecast":
                    await this.OnForecastAsync(e.CallbackQuery.Message.Chat.Id)
                        .ConfigureAwait(false);
                    break;
                default:
                    await this.client.SendTextMessageAsync(
                        chatId: e.CallbackQuery.Message.Chat,
                        text: $"Invalid command: {e.CallbackQuery.Data}")
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

            var buidler = new StringBuilder();
            int hour = 0;
            int day = 0;

            buidler
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
                    buidler
                        .Append($"```\n\n*{DateTime.Today.AddDays(day).Day} - ")
                        .Append($"{culture.DateTimeFormat.GetDayName(DateTime.Today.AddDays(day).DayOfWeek)}*\n```\n");
                }

                buidler
                    .Append($"{GetInnerTextValue(hours[index])}, ")
                    .Append($"{GetInnerTextValue(temperatures[index]),3}, [")
                    .Append($"{GetInnerTextValue(wind_dirs[index]).ToUpperInvariant(),3}, ")
                    .Append($"{GetInnerTextValue(winds[index])}, ")
                    .Append($"{GetInnerTextValue(wind_gusts[index]),2}], ")
                    .Append($"{GetInnerTextValue(humidity[index])}, ")
                    .Append($"{GetInnerTextValue(precipitation[index])}\n");

                hour = hour + 1;
            }

            buidler.Append("```");

            var keyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    new InlineKeyboardButton() { Text = "Повторить запрос", CallbackData = "forecast" },
                },
            });

            await this.client.SendTextMessageAsync(
                chatId: chatId,
                text: buidler
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
    }
}