// <copyright file="SkyMeteoWebForecastProvider.cs" company="Andrey Pudov">
// Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb.Test
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using HtmlAgilityPack;
    using Moq;
    using NUnit.Framework;
    using ParaglidingWeather.Core;
    using ParaglidingWeather.Core.Types;
    using ParaglidingWeather.Providers.SkyMeteoWeb;

    /// <summary>
    /// Represents a test class for <see cref="SkyMeteoWeb.SkyMeteoWebForecastProvider"/>.
    /// </summary>
    public class SkyMeteoWebForecastProvider
    {
        private static readonly List<IWeatherReport> ExpectedReport = new List<IWeatherReport>()
        {
            MakeWeatherReport("2020-08-21 00:00:00", 5, 1013, 86, 4, 290, 10, 75, 0.0),
            MakeWeatherReport("2020-08-21 03:00:00", 4, 1013, 90, 4, 277, 10, 87, 0.0),
            MakeWeatherReport("2020-08-21 06:00:00", 5, 1012, 88, 5, 258, 12, 99, 0.0),
            MakeWeatherReport("2020-08-21 09:00:00", 8, 1010, 76, 7, 261, 13, 100, 0.0),
            MakeWeatherReport("2020-08-21 12:00:00", 9, 1009, 81, 7, 267, 13, 100, 0.4),
            MakeWeatherReport("2020-08-21 15:00:00", 9, 1009, 84, 7, 276, 13, 100, 0.8),
            MakeWeatherReport("2020-08-21 18:00:00", 9, 1010, 87, 6, 279, 13, 100, 0.2),
            MakeWeatherReport("2020-08-21 21:00:00", 10, 1010, 88, 5, 281, 13, 100, 0.3),

            MakeWeatherReport("2020-08-22 00:00:00", 9, 1010, 93, 5, 279, 11, 100, 0.1),
            MakeWeatherReport("2020-08-22 03:00:00", 9, 1011, 94, 4, 269, 11, 100, 0.1),
            MakeWeatherReport("2020-08-22 06:00:00", 9, 1011, 95, 5, 252, 10, 100, 0.0),
            MakeWeatherReport("2020-08-22 09:00:00", 11, 1010, 86, 7, 249, 12, 100, 0.0),
            MakeWeatherReport("2020-08-22 12:00:00", 15, 1009, 75, 8, 257, 12, 100, 0.0),
            MakeWeatherReport("2020-08-22 15:00:00", 17, 1008, 68, 7, 262, 12, 98, 0.0),
            MakeWeatherReport("2020-08-22 18:00:00", 14, 1009, 77, 5, 262, 14, 75, 0.0),
            MakeWeatherReport("2020-08-22 21:00:00", 13, 1009, 76, 5, 270, 15, 85, 0.0),

            MakeWeatherReport("2020-08-23 00:00:00", 12, 1010, 81, 5, 272, 14, 71, 0.0),
            MakeWeatherReport("2020-08-23 03:00:00", 11, 1012, 85, 5, 275, 12, 76, 0.0),
            MakeWeatherReport("2020-08-23 06:00:00", 10, 1013, 90, 5, 275, 11, 87, 0.0),
            MakeWeatherReport("2020-08-23 09:00:00", 13, 1015, 79, 5, 279, 8, 52, 0.0),
            MakeWeatherReport("2020-08-23 12:00:00", 17, 1015, 66, 4, 277, 7, 2, 0.0),
            MakeWeatherReport("2020-08-23 15:00:00", 18, 1016, 61, 4, 271, 6, 1, 0.0),
            MakeWeatherReport("2020-08-23 18:00:00", 13, 1016, 78, 2, 257, 3, 1, 0.0),
            MakeWeatherReport("2020-08-23 21:00:00", 11, 1017, 82, 2, 220, 2, 30, 0.0),

            MakeWeatherReport("2020-08-24 00:00:00", 10, 1017, 88, 2, 206, 3, 47, 0.0),
            MakeWeatherReport("2020-08-24 03:00:00", 10, 1018, 92, 2, 203, 3, 52, 0.0),
            MakeWeatherReport("2020-08-24 06:00:00", 10, 1019, 95, 2, 196, 3, 65, 0.0),
            MakeWeatherReport("2020-08-24 09:00:00", 14, 1019, 82, 3, 204, 5, 70, 0.0),
            MakeWeatherReport("2020-08-24 12:00:00", 19, 1019, 67, 3, 215, 5, 80, 0.0),
            MakeWeatherReport("2020-08-24 15:00:00", 20, 1019, 64, 3, 226, 4, 85, 0.0),
            MakeWeatherReport("2020-08-24 18:00:00", 15, 1019, 85, 2, 195, 2, 72, 0.0),
            MakeWeatherReport("2020-08-24 21:00:00", 14, 1021, 90, 2, 195, 3, 80, 0.0),

            MakeWeatherReport("2020-08-25 00:00:00", 13, 1021, 91, 2, 201, 3, 94, 0.0),
            MakeWeatherReport("2020-08-25 03:00:00", 12, 1022, 91, 2, 200, 2, 94, 0.0),
            MakeWeatherReport("2020-08-25 06:00:00", 11, 1022, 92, 2, 186, 2, 61, 0.0),
            MakeWeatherReport("2020-08-25 09:00:00", 16, 1022, 75, 2, 181, 3, 38, 0.0),
            MakeWeatherReport("2020-08-25 12:00:00", 20, 1023, 59, 2, 178, 3, 10, 0.0),
            MakeWeatherReport("2020-08-25 15:00:00", 21, 1022, 57, 3, 175, 4, 5, 0.0),
            MakeWeatherReport("2020-08-25 18:00:00", 16, 1022, 77, 2, 157, 3, 4, 0.0),
            MakeWeatherReport("2020-08-25 21:00:00", 14, 1023, 83, 2, 164, 3, 34, 0.0),
        };

        /// <summary>
        /// Represents a test case for <see cref="SkyMeteoWeb.SkyMeteoWebForecastProvider.GetForecast"/> method.
        /// </summary>
        [Test]
        public void GetForecast()
        {
            var fetcherMock = new Mock<IFetcher>();
            var document = new HtmlDocument();

            document.LoadHtml(Resources.TestCase.SkyMeteo_Forecast_NizhnyNovgorod_Valid);
            fetcherMock.Setup(_ => _.Fetch()).Returns(document);

            // the geographic coordinate of Nizhny Novgorod
            var coordintae = new Coordinate(latitude: 56.31, longitude: 44.02);
            var provider = new SkyMeteoWeb.SkyMeteoWebForecastProvider(fetcherMock.Object, new DateTime(2020, 08, 21));

            var forecast = provider.GetForecast(coordintae);
            Assert.AreEqual(ExpectedReport, forecast);
        }

        private static WeatherReport MakeWeatherReport(
            string time,
            int temperature,
            int pressure,
            int humidity,
            int windSpeed,
            double windDirection,
            int gustSpeed,
            int cloudiness,
            double precipitation)
        {
            return new WeatherReport(
                DateTime.Parse(time, CultureInfo.InvariantCulture),
                new Temperature(temperature, Core.Units.Temperature.Celsius),
                new Pressure(pressure, Core.Units.Pressure.Pascal),
                new Humidity(humidity, Core.Units.Humidity.Relative),
                new Wind(
                    new Speed(windSpeed, Core.Units.Speed.MeterPerSecond),
                    new Direction(windDirection),
                    new Speed(gustSpeed, Core.Units.Speed.MeterPerSecond)),
                new Cloudiness(cloudiness, Core.Units.Cloudiness.Relative),
                new Precipitation(precipitation, Core.Units.Precipitation.Millimetres));
        }
    }
}
