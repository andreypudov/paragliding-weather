// <copyright file="IForecastProvider.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ParaglidingWeather.Core;
    using ParaglidingWeather.Core.Types;

    /// <summary>
    /// Represents a data reader that returns a weather forecast.
    /// </summary>
    public interface IForecastProvider
    {
        /// <summary>
        /// Returns the weather forecast for the week or fewer number available days.
        /// </summary>
        /// <param name="coordinate">The geographic coordinate of the location.</param>
        /// <returns>Returns the weather forecast.</returns>
        List<IWeatherReport> GetForecast(Coordinate coordinate);

        /// <summary>
        /// Returns the weather forecast for the week or fewer number available days in an asynchronous operation.
        /// </summary>
        /// <param name="coordinate">The geographic coordinate of the location.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<List<IWeatherReport>> GetForecastAsync(Coordinate coordinate);
    }
}
