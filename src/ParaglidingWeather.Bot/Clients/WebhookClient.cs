// <copyright file="WebhookClient.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Bot.Clients;

using Microsoft.Extensions.Logging;
using System.Net;
using Newtonsoft.Json;
using ParaglidingWeather.Bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Exceptions;

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

        var handler = update.Type switch
        {
            // UpdateType.Unknown:
            // UpdateType.ChannelPost:
            // UpdateType.EditedChannelPost:
            // UpdateType.ShippingQuery:
            // UpdateType.PreCheckoutQuery:
            // UpdateType.Poll:
            // UpdateType.InlineQuery
            // UpdateType.ChosenInlineResult
            UpdateType.Message => this.OnMessageHandler(update.Message!),
            UpdateType.EditedMessage => this.OnMessageHandler(update.EditedMessage!),
            UpdateType.CallbackQuery => this.OnCallbackQueryHandler(update.CallbackQuery!),
            _ => this.UnknownUpdateHandlerAsync(update),
        };

        try
        {
            await handler;
        }
        catch (Exception exception)
        {
            await this.HandleErrorAsync(exception);
        }
    }

    private async Task OnMessageHandler(Message message)
    {
        if ((message!.Type != MessageType.Text)
            || string.IsNullOrEmpty(message.Text))
        {
            await this.ReplyInvalidRequestAsync(message);
            return;
        }

        await this.LogAsync(
            message.Chat.Id,
            message.Chat.Username,
            message.Chat.FirstName,
            message.Chat.LastName,
            message.MessageId);

        switch (message.Text.Trim())
        {
            case "/start":
            case "/forecast":
                await this.OnForecastAsync(message.Chat.Id);
                break;
            default:
                await this.client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: $"Неверная команда: {message.Text}\nИспользуйте /forecast для получения прогноза погоды.");
                break;
        }
    }

    private async Task OnCallbackQueryHandler(CallbackQuery callbackQuery)
    {
        if ((callbackQuery.Message is null)
            || string.IsNullOrEmpty(callbackQuery.Data)
            || string.IsNullOrEmpty(callbackQuery.Message.Text))
        {
            await this.ReplyInvalidRequestAsync(callbackQuery.Message);
            return;
        }

        await this.LogAsync(
            callbackQuery.Message.Chat.Id,
            callbackQuery.Message.Chat.Username,
            callbackQuery.Message.Chat.FirstName,
            callbackQuery.Message.Chat.LastName,
            callbackQuery.Message.MessageId);

        try
        {
            await this.client.EditMessageReplyMarkupAsync(
                callbackQuery.Message.Chat.Id,
                callbackQuery.Message.MessageId);
        }
        catch (AggregateException ex)
        {
            this.logger.LogError(ex.ToString());
        }

        switch (callbackQuery.Data.Trim())
        {
            case "start":
            case "forecast":
                await this.OnForecastAsync(callbackQuery.Message.Chat.Id);
                break;
            default:
                await this.client.SendTextMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: $"Неверная команда: {callbackQuery.Data}\nИспользуйте /forecast для получения прогноза погоды.");
                break;
        }
    }

    private async Task OnForecastAsync(long chatId)
    {
        try
        {
            var markdown = await this.GetMarkdown(chatId);
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
                InlineKeyboardButton.WithCallbackData(text: "Повторить запрос", callbackData: "forecast"),
            },
        });

        await this.client.SendTextMessageAsync(
            chatId: chatId,
            text: message,
            replyMarkup: keyboard,
            disableWebPagePreview: true,
            parseMode: ParseMode.MarkdownV2);
    }

    private Task HandleErrorAsync(Exception exception)
    {
        var message = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString(),
        };

        this.logger.LogInformation(message);
        return Task.CompletedTask;
    }

    private Task UnknownUpdateHandlerAsync(Update update)
    {
        if (update.Message is not null)
        {
            this.client.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: $"Неверная команда.\nИспользуйте /forecast для получения прогноза погоды.");
        }

        this.logger.LogInformation($"Unknown update type: {update.Type}");
        return Task.CompletedTask;
    }

    private async Task ReplyInvalidRequestAsync(Message? message)
    {
        if (message is not null)
        {
            await this.client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Неверная команда. Используйте /forecast для получения прогноза погоды.");
        }
    }

    private async Task LogAsync(long id, string? userName, string? firstName, string? lastName, int messageId)
    {
        userName = WebUtility.HtmlDecode(userName);
        firstName = WebUtility.HtmlDecode(firstName);
        lastName = WebUtility.HtmlDecode(lastName);

        var message = $"[{id}] [{userName}] [{firstName} {lastName}] [{messageId}]";

        await MissionMonitor.PublishAsync($"{nameof(ParaglidingWeather)} {message}");
        this.logger.LogInformation(message);
    }
}