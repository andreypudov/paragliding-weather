// <copyright file="IForecastEntry.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeatherBot.Core
{
    using System;

    /// <summary>
    /// Represents a weather forecast entry.
    /// </summary>
    public interface IForecastEntry
    {
        /// <summary>
        /// Gets the value of time.
        /// </summary>
        DateTime Time { get; }

        /// <summary>
        /// Gets the value of temperature.
        /// </summary>
        int Temperature { get; }

        /// <summary>
        /// Gets the value of wind direction.
        /// </summary>
        Direction WindDirection { get; }

        /// <summary>
        /// Gets the value of wind speend.
        /// </summary>
        int WindSpeed { get; }

        /// <summary>
        /// Gets the value of gusts speed.
        /// </summary>
        int WindGusts { get; }

        /// <summary>
        /// Gets the value of humidity.
        /// </summary>
        int Humidity { get; }

        /// <summary>
        /// Gets the value of cloudy.
        /// </summary>
        int Cloudy { get; }

        /// <summary>
        /// Gets the value of precipitation.
        /// </summary>
        int Precipitation { get; }

        /// <summary>
        /// Gets the value of barometric pressure.
        /// </summary>
        int Pressure { get; }
    }
}
