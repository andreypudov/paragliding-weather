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

        /// <summary>
        /// Initializes a new instance of the <see cref="SkyMeteoWebForecastProvider"/> class.
        /// </summary>
        /// <param name="fetcher">The instance of the data fetcher.</param>
        public SkyMeteoWebForecastProvider(IFetcher fetcher)
        {
            this.fetcher = fetcher;
        }

        /// <inheritdoc/>
        public List<IWeatherReport> GetForecast(Coordinate coordinate)
        {
            var document = this.fetcher.Fetch();
            var parser = new DocumentParser(document);

            return parser.Parse();
        }

        /// <inheritdoc/>
        public Task<List<IWeatherReport>> GetForecastAsync(Coordinate coordinate)
        {
            throw new System.NotImplementedException();
        }
    }
}
