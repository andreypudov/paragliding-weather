// <copyright file="IWeatherReport.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core
{
    using System;
    using ParaglidingWeather.Core.Types;

    /// <summary>
    /// Represents a weather forecast entry.
    /// </summary>
    public interface IWeatherReport
    {
        /// <summary>
        /// Gets the value of time.
        /// </summary>
        DateTime Time { get; }

        /// <summary>
        /// Gets the value of temperature.
        /// </summary>
        ITemperature Temperature { get; }

        /// <summary>
        /// Gets the value of atmospheric pressure.
        /// </summary>
        IPressure Pressure { get; }

        /// <summary>
        /// Gets the value of humidity.
        /// </summary>
        IHumidity Humidity { get; }

        /// <summary>
        /// Gets the value of wind.
        /// </summary>
        IWind Wind { get; }

        /// <summary>
        /// Gets the value of cloudiness.
        /// </summary>
        ICloudiness Cloudiness { get; }

        /// <summary>
        /// Gets the value of precipitation.
        /// </summary>
        IPrecipitation Precipitation { get; }
    }
}
