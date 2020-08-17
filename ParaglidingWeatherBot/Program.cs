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

            Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

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
            var wind_gusts = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, '332 ')])");
            var precipitation = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, '222 ')])");
            var humidity = document.DocumentNode.SelectNodes("(//table[@id='forecast']//td[contains(@class, '215 ')])");

            var buidler = new StringBuilder();
            int hour = 0;
            int today = DateTime.Today.Day;

            buidler.Append("<pre>").Append(today).Append('\n');
            for (var index = 0; index < hours.Count; ++index)
            {
                if (hour == 8)
                {
                    hour = 0;
                    today = today + 1;
                    buidler.Append('\n').Append(today).Append('\n');
                }

                buidler
                    .Append($"{hours[index].InnerText.Trim(),-4}, ")
                    .Append($"{temperatures[index].InnerText.Trim(),4}, ")
                    .Append($"{wind_dirs[index].InnerText.Trim().ToUpperInvariant(),4}, ")
                    .Append($"{winds[index].InnerText.Trim(),3}, ")
                    .Append($"{wind_gusts[index].InnerText.Trim(),3}, ")
                    .Append($"{humidity[index].InnerText.Trim(),3}, ")
                    .Append($"{precipitation[index].InnerText.Trim(),4}\n");

                hour = hour + 1;
            }

            buidler.Append("</pre>");

            await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: buidler.ToString(),
                        parseMode: Telegram.Bot.Types.Enums.ParseMode.Html).ConfigureAwait(false);
        }
    }
}
