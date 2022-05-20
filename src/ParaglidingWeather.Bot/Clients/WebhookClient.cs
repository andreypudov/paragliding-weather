﻿// <copyright file="WebhookClient.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Bot.Clients
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using ParaglidingWeather.Bot.Helpers;
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
        private readonly Configuration configuration;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookClient"/> class.
        /// </summary>
        /// <param name="configuration">The configuration of the bot.</param>
        /// <param name="logger">The instance of the logger.</param>
        public WebhookClient(Configuration configuration, ILogger logger)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.client = new TelegramBotClient(configuration.Token);
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

            await this.LogAsync(
                update.Message.Chat.Id,
                update.Message.Chat.Username,
                update.Message.Chat.FirstName,
                update.Message.Chat.LastName,
                update.Message.MessageId);

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
                            text: $"Неверная команда: {update.Message.Text}\nИспользуйте /forecast для получения прогноза погоды.")
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

            await this.LogAsync(
                update.CallbackQuery.Message.Chat.Id,
                update.CallbackQuery.Message.Chat.Username,
                update.CallbackQuery.Message.Chat.FirstName,
                update.CallbackQuery.Message.Chat.LastName,
                update.CallbackQuery.Message.MessageId);

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
                            text: $"Неверная команда: {update.CallbackQuery.Data}\nИспользуйте /forecast для получения прогноза погоды.")
                        .ConfigureAwait(false);
                    break;
            }
        }

        private async Task OnForecastAsync(long chatId)
        {
            var markdown = string.Empty;
            try
            {
                markdown = await this.GetMarkdown(chatId);
                await this.ReplyAsync(chatId, markdown);
            }
            catch (Exception e)
            {
                this.logger.LogError($"{nameof(WebhookClient)} OnForecastAsync {e.Message}");
                await this.ReplyAsync(chatId, "Не удалось получить информацию о погоде");
            }
        }

        private async Task<string> GetMarkdown(long chatId)
        {
            var document = await WeatherParser.GetAsync();
            if (document == null)
            {
                await this.ReplyAsync(chatId, "Информация о погоде недоступна.");
                return string.Empty;
            }

            return WeatherFormatter.Format(document);
        }

        private async Task ReplyAsync(long chatId, string message)
        {
            var keyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    new InlineKeyboardButton() { Text = "Повторить запрос", CallbackData = "forecast" },
                },
            });

            await this.client.SendTextMessageAsync(
                chatId: chatId,
                text: message,
                replyMarkup: keyboard,
                disableWebPagePreview: true,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.MarkdownV2).ConfigureAwait(false);
        }

        private async Task LogAsync(long id, string userName, string firstName, string lastName, int messageId)
        {
            userName = WebUtility.HtmlDecode(userName);
            firstName = WebUtility.HtmlDecode(firstName);
            lastName = WebUtility.HtmlDecode(lastName);

            var message = $"[{id}] [{userName}] [{firstName} {lastName}] [{messageId}]";

            await MissionMonitor.PublishAsync($"{nameof(ParaglidingWeather)} {message}");
            this.logger.LogInformation(message);
        }
    }
}
