// <copyright file="IForecast.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a collection of weather forecast entries.
    /// </summary>
    public interface IForecast
    {
        /// <summary>
        /// Gets the list of forecast entries.
        /// </summary>
        List<IForecastEntry> Records { get; }
    }
}
