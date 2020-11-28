// <copyright file="LongPollingClient.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Bot
{
    using System;
    using System.Threading.Tasks;
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
        private readonly Configuration configuration;
        private readonly ILogger<LongPollingClient> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LongPollingClient"/> class.
        /// </summary>
        /// <param name="configuration">The instance of a application configuration.</param>
        /// <param name="logger">The instance of an application logger.</param>
        public LongPollingClient(Configuration configuration, ILogger<LongPollingClient> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.client = new TelegramBotClient(configuration.Token);
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

        private async void OnMessageHandler(object? sender, MessageEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Message.Text))
            {
                return;
            }

            this.Log(
                $"[{e.Message.Chat.Id}] "
                + $"[{e.Message.Chat.Username}] "
                + $"[{e.Message.Chat.FirstName} "
                + $"{e.Message.Chat.LastName}]");

            switch (e.Message.Text.Trim())
            {
                case "/start":
                case "/forecast":
                    await this.OnForecastAsync(e.Message.Chat.Id)
                        .ConfigureAwait(false);
                    break;
                default:
                    await this.client.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: $"Неверная команда: {e.Message.Text}\nИспользуйте /forecast для получения прогноза погоды.")
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

            this.Log(
                $"[{e.CallbackQuery.Message.Chat.Id}] "
                + $"[{e.CallbackQuery.Message.Chat.Username}] "
                + $"[{e.CallbackQuery.Message.Chat.FirstName} "
                + $"{e.CallbackQuery.Message.Chat.LastName}] "
                + $"[{e.CallbackQuery.Message.MessageId}]");

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
                case "start":
                case "forecast":
                    await this.OnForecastAsync(e.CallbackQuery.Message.Chat.Id)
                        .ConfigureAwait(false);
                    break;
                default:
                    await this.client.SendTextMessageAsync(
                        chatId: e.CallbackQuery.Message.Chat,
                        text: $"Неверная команда: {e.CallbackQuery.Data}\nИспользуйте /forecast для получения прогноза погоды.")
                        .ConfigureAwait(false);

                    break;
            }
        }

        private async Task OnForecastAsync(long chatId)
        {
            var document = await WeatherParser.GetAsync();
            if (document == null)
            {
                await this.SendReply(chatId, "Информация о погоде недоступна.");
                return;
            }

            var markdown = WeatherFormatter.Format(document);
            await this.SendReply(chatId, markdown);
        }

        private async Task SendReply(long chatId, string message)
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
                text: message
                    .Replace("<", "\\<", StringComparison.InvariantCulture)
                    .Replace(">", "\\>", StringComparison.InvariantCulture)
                    .Replace("+", "\\+", StringComparison.InvariantCulture)
                    .Replace("-", "\\-", StringComparison.InvariantCulture)
                    .Replace(".", "\\.", StringComparison.InvariantCulture)
                    .Replace("|", "\\|", StringComparison.InvariantCulture)
                    .Replace("(", "\\(", StringComparison.InvariantCulture)
                    .Replace(")", "\\)", StringComparison.InvariantCulture)
                    .Replace("=", "\\=", StringComparison.InvariantCulture),
                replyMarkup: keyboard,
                disableWebPagePreview: true,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.MarkdownV2).ConfigureAwait(false);
        }

        private void Log(string message)
        {
            MissionMonitor.Publish($"{nameof(ParaglidingWeather)} {message}");
            this.logger.LogInformation(message);
        }
    }
}