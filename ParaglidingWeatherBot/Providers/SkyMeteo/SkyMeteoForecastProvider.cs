// <copyright file="SkyMeteoForecastProvider.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeatherBot.Providers.SkyMeteo
{
    using ParaglidingWeatherBot.Core;

    /// <summary>
    /// Provides a weather forecast using SkyMeteo public API.
    /// </summary>
    public class SkyMeteoForecastProvider : IForecastProvider
    {
        /// <inheritdoc/>
        public IForecast GetForecast()
        {
            throw new System.NotImplementedException();
        }
    }
}
