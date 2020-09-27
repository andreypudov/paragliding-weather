// <copyright file="WeatherReport.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core
{
    using System;
    using ParaglidingWeather.Core.Types;

    /// <summary>
    /// Represents a weather forecast entry.
    /// </summary>
    public class WeatherReport : IWeatherReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherReport"/> class.
        /// </summary>
        /// <param name="time">The value of time.</param>
        /// <param name="temperature">The value of temperature.</param>
        /// <param name="pressure">The value of atmospheric pressure.</param>
        /// <param name="humidity">The value of humidity.</param>
        /// <param name="wind">The value of wind.</param>
        /// <param name="cloudiness">The value of cloudiness.</param>
        /// <param name="precipitation">The value of precipitation.</param>
        public WeatherReport(
            DateTime time,
            ITemperature temperature,
            IPressure pressure,
            IHumidity humidity,
            IWind wind,
            ICloudiness cloudiness,
            IPrecipitation precipitation)
        {
            this.Time = time;
            this.Temperature = temperature;
            this.Pressure = pressure;
            this.Humidity = humidity;
            this.Wind = wind;
            this.Cloudiness = cloudiness;
            this.Precipitation = precipitation;
        }

        /// <summary>
        /// Gets the value of time.
        /// </summary>
        public DateTime Time { get; }

        /// <summary>
        /// Gets the value of temperature.
        /// </summary>
        public ITemperature Temperature { get; }

        /// <summary>
        /// Gets the value of atmospheric pressure.
        /// </summary>
        public IPressure Pressure { get; }

        /// <summary>
        /// Gets the value of humidity.
        /// </summary>
        public IHumidity Humidity { get; }

        /// <summary>
        /// Gets the value of wind.
        /// </summary>
        public IWind Wind { get; }

        /// <summary>
        /// Gets the value of cloudiness.
        /// </summary>
        public ICloudiness Cloudiness { get; }

        /// <summary>
        /// Gets the value of precipitation.
        /// </summary>
        public IPrecipitation Precipitation { get; }
    }
}
