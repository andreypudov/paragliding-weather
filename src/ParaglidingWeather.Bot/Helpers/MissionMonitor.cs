// <copyright file="MissionMonitor.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Bot.Helpers;

using System.Net;

/// <summary>
/// Represents the mission monitor.
/// </summary>
public static class MissionMonitor
{
    private static readonly string BotApiKey = "1207628089:AAF-ytVyTJsmQ-5y_XTL-ZUUrtIU4LGfnzo";
    private static readonly string ChannelName = "-1001232512421";

    private static readonly HttpClient Client = new HttpClient();

    /// <summary>
    /// Publishes provided message to the Message monitor channel.
    /// </summary>
    /// <param name="message">The value of the message to publish.</param>
    /// <returns>The instance of the async task.</returns>
    public static async Task PublishAsync(string message)
    {
        var url = $"https://api.telegram.org/bot{BotApiKey}/sendMessage?chat_id={ChannelName}&text={WebUtility.HtmlEncode(message)}";

        try
        {
            await Client.GetAsync(url);
        }
        catch (Exception)
        {
            // intentionally left blank
        }
    }
}