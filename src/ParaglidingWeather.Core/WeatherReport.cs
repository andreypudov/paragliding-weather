// <copyright file="WeatherReport.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core
{
    using System;
    using System.Globalization;
    using System.Text;
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

        /// <inheritdoc/>
        public DateTime Time { get; }

        /// <inheritdoc/>
        public ITemperature Temperature { get; }

        /// <inheritdoc/>
        public IPressure Pressure { get; }

        /// <inheritdoc/>
        public IHumidity Humidity { get; }

        /// <inheritdoc/>
        public IWind Wind { get; }

        /// <inheritdoc/>
        public ICloudiness Cloudiness { get; }

        /// <inheritdoc/>
        public IPrecipitation Precipitation { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder
                .Append(this.Time.ToString("yyy-MMMM-dd HH:mm:ss", CultureInfo.InvariantCulture)).Append(", ")
                .Append(this.Temperature).Append(", ")
                .Append(this.Pressure).Append(", ")
                .Append(this.Humidity).Append(", ")
                .Append(this.Wind).Append(", ")
                .Append(this.Cloudiness).Append(", ")
                .Append(this.Precipitation);

            return builder.ToString();
        }
    }
}
