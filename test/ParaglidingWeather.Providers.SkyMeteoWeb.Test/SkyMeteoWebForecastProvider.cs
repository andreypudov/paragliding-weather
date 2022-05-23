// <copyright file="SkyMeteoWebForecastProvider.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb.Test;

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
        MakeWeatherReport("2022-05-23 00:00:00", 1, 1003, 75, 2, 337, 6, 5, 0.0),
        MakeWeatherReport("2022-05-23 03:00:00", -1, 1002, 80, 2, 319, 5, 13, 0.0),
        MakeWeatherReport("2022-05-23 06:00:00", 2, 1002, 77, 3, 305, 5, 80, 0.0),
        MakeWeatherReport("2022-05-23 09:00:00", 4, 1001, 62, 4, 302, 6, 100, 0.1),
        MakeWeatherReport("2022-05-23 12:00:00", 5, 1001, 63, 5, 304, 6, 100, 0.1),
        MakeWeatherReport("2022-05-23 15:00:00", 6, 1001, 56, 5, 298, 7, 100, 0.3),
        MakeWeatherReport("2022-05-23 18:00:00", 5, 1001, 77, 4, 299, 10, 100, 0.3),
        MakeWeatherReport("2022-05-23 21:00:00", 3, 1001, 88, 4, 283, 8, 100, 0.6),

        MakeWeatherReport("2022-05-24 00:00:00", 2, 1001, 96, 4, 281, 8, 100, 0.4),
        MakeWeatherReport("2022-05-24 03:00:00", 1, 1001, 98, 3, 248, 8, 100, 0.5),
        MakeWeatherReport("2022-05-24 06:00:00", 2, 1001, 98, 4, 259, 8, 100, 0.7),
        MakeWeatherReport("2022-05-24 09:00:00", 2, 1003, 97, 2, 314, 4, 98, 1.2),
        MakeWeatherReport("2022-05-24 12:00:00", 4, 1004, 78, 3, 319, 4, 100, 0.6),
        MakeWeatherReport("2022-05-24 15:00:00", 7, 1005, 56, 4, 321, 4, 100, 1.2),
        MakeWeatherReport("2022-05-24 18:00:00", 6, 1007, 62, 4, 331, 5, 98, 0.3),
        MakeWeatherReport("2022-05-24 21:00:00", 3, 1008, 80, 2, 313, 5, 82, 0.4),

        MakeWeatherReport("2022-05-25 00:00:00", 2, 1009, 83, 2, 315, 6, 94, 0.0),
        MakeWeatherReport("2022-05-25 03:00:00", 1, 1010, 93, 3, 321, 8, 40, 0.0),
        MakeWeatherReport("2022-05-25 06:00:00", 3, 1010, 88, 4, 330, 7, 53, 0.0),
        MakeWeatherReport("2022-05-25 09:00:00", 6, 1011, 75, 5, 325, 7, 100, 0.1),
        MakeWeatherReport("2022-05-25 12:00:00", 7, 1012, 68, 5, 321, 7, 89, 0.3),
        MakeWeatherReport("2022-05-25 15:00:00", 9, 1012, 61, 5, 305, 7, 99, 1.0),
        MakeWeatherReport("2022-05-25 18:00:00", 8, 1012, 68, 4, 304, 7, 98, 0.6),
        MakeWeatherReport("2022-05-25 21:00:00", 5, 1013, 89, 3, 286, 7, 5, 1.1),

        MakeWeatherReport("2022-05-26 00:00:00", 4, 1013, 91, 3, 286, 8, 100, 0.0),
        MakeWeatherReport("2022-05-26 03:00:00", 5, 1013, 87, 3, 269, 8, 100, 0.0),
        MakeWeatherReport("2022-05-26 06:00:00", 5, 1013, 80, 4, 263, 8, 100, 0.0),
        MakeWeatherReport("2022-05-26 09:00:00", 10, 1012, 55, 4, 258, 6, 76, 0.0),
        MakeWeatherReport("2022-05-26 12:00:00", 12, 1010, 46, 5, 232, 6, 100, 0.0),
        MakeWeatherReport("2022-05-26 15:00:00", 13, 1008, 52, 4, 233, 7, 25, 0.0),
        MakeWeatherReport("2022-05-26 18:00:00", 14, 1005, 57, 3, 186, 6, 100, 0.0),
        MakeWeatherReport("2022-05-26 21:00:00", 11, 1003, 91, 5, 196, 11, 100, 0.4),

        MakeWeatherReport("2022-05-27 00:00:00", 10, 998, 98, 4, 113, 8, 100, 4.1),
        MakeWeatherReport("2022-05-27 03:00:00", 10, 994, 98, 3, 143, 7, 100, 9.2),
        MakeWeatherReport("2022-05-27 06:00:00", 10, 992, 99, 4, 265, 8, 100, 2.3),
        MakeWeatherReport("2022-05-27 09:00:00", 9, 994, 98, 3, 290, 6, 100, 5.5),
        MakeWeatherReport("2022-05-27 12:00:00", 9, 997, 97, 4, 311, 7, 100, 3.5),
        MakeWeatherReport("2022-05-27 15:00:00", 13, 1000, 81, 5, 278, 6, 98, 5.4),
        MakeWeatherReport("2022-05-27 18:00:00", 12, 1001, 84, 4, 271, 8, 90, 0.3),
        MakeWeatherReport("2022-05-27 21:00:00", 9, 1003, 95, 3, 228, 7, 5, 0.3),
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
        var coordintae = new Coordinate(latitude: 56.1936, longitude: 44.0021);
        var provider = new SkyMeteoWeb.SkyMeteoWebForecastProvider(fetcherMock.Object, new DateTime(2022, 05, 23));

        var forecast = provider.GetForecast(coordintae);
        Assert.AreEqual(ExpectedReport, forecast);
    }

    private static WeatherReport MakeWeatherReport(
        string time,
        double temperature,
        double pressure,
        double humidity,
        double windSpeed,
        double windDirection,
        double gustSpeed,
        double cloudiness,
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