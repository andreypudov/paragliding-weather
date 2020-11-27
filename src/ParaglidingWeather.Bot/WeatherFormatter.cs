// <copyright file="WeatherFormatter.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Bot
{
    using System;
    using System.Net;
    using System.Text;
    using HtmlAgilityPack;

    /// <summary>
    /// Represents weather formatter that returns a markdown representation.
    /// </summary>
    public static class WeatherFormatter
    {
        /// <summary>
        /// Formats a given weather forecast to markdown representation.
        /// </summary>
        /// <param name="document">The HTML representation of the weather forecast.</param>
        /// <returns>The markdown representation of the given weather forecast.</returns>
        public static string Format(HtmlDocument document)
        {
            var rows = document.DocumentNode.SelectNodes("(//table[@id='forecast']//tr)");
            var culture = new System.Globalization.CultureInfo("ru-RU");
            var buildler = new StringBuilder();

            int day = 0;

            buildler
                .Append("*Время, Температура, Ветер, Поровы, Влажность, Осадки*\n```");

            foreach (var row in rows)
            {
                var columns = row.SelectNodes("td|th");
                if (columns == null)
                {
                    continue;
                }

                HtmlNodeCollection forecast = columns;

                if ((forecast.Count == 11) || (forecast.Count == 12))
                {
                    int firstColumn = 0;
                    if (forecast.Count == 12)
                    {
                        buildler
                            .Append($"```\n\n*{DateTime.Today.AddDays(day).Day} - ")
                            .Append($"{culture.DateTimeFormat.GetDayName(DateTime.Today.AddDays(day).DayOfWeek)}*\n```\n");
                        day = day + 1;
                        firstColumn = 1;
                    }

                    buildler
                        .Append($"{GetInnerTextValue(forecast[firstColumn]).Split(":")[0]}ч, ")
                        .Append($"{GetInnerTextValue(forecast[firstColumn + 1]),3} [")
                        .Append($"{GetInnerTextValue(forecast[firstColumn + 3]).ToUpperInvariant(),3}, ")
                        .Append($"{GetInnerTextValue(forecast[firstColumn + 4])}, ")
                        .Append($"{GetInnerTextValue(forecast[firstColumn + 5]),2}] ")
                        .Append($"{GetInnerTextValue(forecast[firstColumn + 6]),3}, ")
                        .Append($"{GetInnerTextValue(forecast[firstColumn + 8])}\n");
                }
            }

            buildler.Append("```");

            return buildler.ToString();
        }

        private static string GetInnerTextValue(HtmlNode node)
        {
            return WebUtility.HtmlDecode(node.InnerText.Trim());
        }
    }
}
