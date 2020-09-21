// <copyright file="SkyMeteoWebForecastProvider.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb
{
    using System;
    using System.Threading.Tasks;
    using HtmlAgilityPack;
    using ParaglidingWeather.Core;
    using ParaglidingWeather.Core.Types;

    /// <summary>
    /// Provides a weather forecast by fetching a data from a web page of SkyMeteo service.
    /// </summary>
    public class SkyMeteoWebForecastProvider : IForecastProvider
    {
        /// <inheritdoc/>
        public IForecast GetForecast(Coordinate coordinate)
        {
            var web = new HtmlWeb();
            var document = web.Load(new Uri("http://meteo.paraplan.net/forecast/summary.html?place=3148"));

            Console.WriteLine(document);

            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IForecast> GetForecastAsync(Coordinate coordinate)
        {
            throw new System.NotImplementedException();
        }
    }
}
