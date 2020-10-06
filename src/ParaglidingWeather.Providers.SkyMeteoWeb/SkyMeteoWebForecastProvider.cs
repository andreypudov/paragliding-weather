// <copyright file="SkyMeteoWebForecastProvider.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ParaglidingWeather.Core;
    using ParaglidingWeather.Core.Types;

    /// <summary>
    /// Provides a weather forecast by fetching a data from a web page of SkyMeteo service.
    /// </summary>
    public class SkyMeteoWebForecastProvider : IForecastProvider
    {
        private readonly IFetcher fetcher;
        private readonly DateTime date;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkyMeteoWebForecastProvider"/> class.
        /// </summary>
        /// <param name="fetcher">The instance of the data fetcher.</param>
        /// <param name="date">The date of the forecast.</param>
        public SkyMeteoWebForecastProvider(IFetcher fetcher, DateTime date)
        {
            this.fetcher = fetcher;
            this.date = date;
        }

        /// <inheritdoc/>
        public List<IWeatherReport> GetForecast(Coordinate coordinate)
        {
            var document = this.fetcher.Fetch();
            var parser = new DocumentParser(document);

            return parser.Parse(this.date);
        }

        /// <inheritdoc/>
        public Task<List<IWeatherReport>> GetForecastAsync(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }
    }
}
