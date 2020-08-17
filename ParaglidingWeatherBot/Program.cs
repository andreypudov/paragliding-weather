// <copyright file="Program.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeatherBot
{
    using System;
    using System.Text;
    using HtmlAgilityPack;
    using Telegram.Bot;
    using Telegram.Bot.Args;

    /// <summary>
    /// An entry point of the application.
    /// </summary>
    internal class Program
    {
        private static ITelegramBotClient botClient = new TelegramBotClient("1352055876:AAEOYes34UWQ8MP6qscrquaB_ojp1brfMes");

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "To be added later.")]
        private static void Main(/* string[] args */)
        {
            botClient.OnMessage += OnMessageHandler;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }

        private static async void OnMessageHandler(object? sender, MessageEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Message.Text))
            {
                return;
            }

            switch (e.Message.Text.Trim())
            {
                case "/forecast":
                    OnForecastAsync(e);
                    break;
                default:
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: $"Invalid command: {e.Message.Text}").ConfigureAwait(false);
                    break;
            }
        }

        private static async void OnForecastAsync(MessageEventArgs e)
        {
            var web = new HtmlWeb();
            var document = web.Load(new Uri("http://meteo.paraplan.net/forecast/summary.html?place=3148"));

            var hours = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, 'hour')])");
            var temperatures = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, '213')])");
            var wind_dirs = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, 'wind_dir ')])");
            var winds = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, 'wind ')])");

            var buidler = new StringBuilder();

            for (var index = 0; index < hours.Count; ++index)
            {
                buidler
                    .Append(hours[index].InnerText.Trim()).Append(", ")
                    .Append(temperatures[index].InnerText.Trim()).Append(", ")
                    .Append(wind_dirs[index].InnerText.Trim()).Append(", ")
                    .Append(winds[index].InnerText.Trim()).Append('\n');
            }

            await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: buidler.ToString()).ConfigureAwait(false);
        }
    }
}
