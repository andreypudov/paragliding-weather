// <copyright file="WeatherParser.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Bot
{
    using System.Threading.Tasks;
    using HtmlAgilityPack;

    /// <summary>
    /// Parses the weather inforation on SkyMeteo webpage.
    /// </summary>
    public static class WeatherParser
    {
        /// <summary>
        /// Returns the HTML representation of the forecast information.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public static async Task<HtmlDocument?> GetAsync()
        {
            var web = new HtmlWeb();
            return await web.LoadFromWebAsync("http://meteo.paraplan.net/ru/forecast/summary.html?place=3148");
        }
    }
}
