// <copyright file="SkyMeteoWebForecastProvider.cs" company="Andrey Pudov">
// Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb.Test
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
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
            GetWeatherReport("2020-08-21", 5, 1013, 86, 4, 290, 10, 75, 0.0),
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

            // Assert.IsTrue(Enumerable.SequenceEqual(new List<IWeatherReport>(), forecast));
            Assert.AreEqual(ExpectedReport[0], forecast[0]);
        }

        private static WeatherReport GetWeatherReport(
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
