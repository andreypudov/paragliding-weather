// <copyright file="NodeParser.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb;

using HtmlAgilityPack;
using ParaglidingWeather.Core;
using ParaglidingWeather.Core.Types;

/// <summary>
/// Provides methods to parse HTML node.
/// </summary>
public class NodeParser
{
    private readonly HtmlNode node;

    /// <summary>
    /// Initializes a new instance of the <see cref="NodeParser"/> class.
    /// </summary>
    /// <param name="node">The HTML node to parse.</param>
    public NodeParser(HtmlNode node)
    {
        this.node = node;
    }

    /// <summary>
    /// Parses the node and returns weather information.
    /// </summary>
    /// <param name="date">The date of the forecast.</param>
    /// <returns>The instance of weather reports.</returns>
    public IWeatherReport? Parse(ref DateTime date) => this.node.SelectNodes("*").Count switch
    {
        11 or 12 => this.ParseDateRow(ref date),
        _ => null,
    };

    private static void UpdateDate(ref DateTime date, int day)
    {
        while (date.Day != day)
        {
            date = date.AddDays(1);
        }
    }

    private IWeatherReport? ParseDateRow(ref DateTime date)
    {
        const int DATE_COLUMN = 0;
        const int TIME_COLUMN = 0;
        const int TEMPERATURE_COLUMN = 1;
        const int WIND_DIRECTION_COLUMN = 2;
        const int WIND_SPEED_COLUMN = 4;
        const int WIND_GUST_COLUMN = 5;
        const int HUMIDITY_COLUMN = 6;
        const int CLOUDINESS_COLUMN = 7;
        const int PRECIPITATION_COLUMN = 8;
        const int PRESSURE_COLUMN = 9;

        var columns = this.node.SelectNodes("*");
        int firstColumn = 0;
        int day = 0;

        if (columns.Count == 12)
        {
            int.TryParse(new string(columns[DATE_COLUMN].SelectNodes("*")[1].InnerText.Where(char.IsDigit).ToArray()), out day);
            UpdateDate(ref date, day);
            firstColumn = 1;
        }

        if (int.TryParse(new string(columns[TIME_COLUMN + firstColumn].InnerText.Where(char.IsDigit).ToArray()), out int time)
            && int.TryParse(columns[TEMPERATURE_COLUMN + firstColumn].InnerText.Replace("−", "-"), out int temperature)
            && double.TryParse(new string(columns[WIND_DIRECTION_COLUMN + firstColumn].LastChild.GetAttributeValue("data-tippy-content", "0").Where(char.IsDigit).ToArray()), out double windDirection)
            && int.TryParse(columns[WIND_SPEED_COLUMN + firstColumn].InnerText, out int windSpeed)
            && int.TryParse(columns[WIND_GUST_COLUMN + firstColumn].InnerText, out int windGust)
            && int.TryParse(columns[HUMIDITY_COLUMN + firstColumn].InnerText, out int humidity)
            && int.TryParse(columns[CLOUDINESS_COLUMN + firstColumn].InnerText, out int cloudiness)
            && double.TryParse(columns[PRECIPITATION_COLUMN + firstColumn].InnerText, out double precipitation)
            && int.TryParse(columns[PRESSURE_COLUMN + firstColumn].InnerText, out int pressure))
        {
            return new WeatherReport(
                time: date.AddHours((int)(time / 100)),
                temperature: new Temperature(temperature, Core.Units.Temperature.Celsius),
                pressure: new Pressure(pressure, Core.Units.Pressure.Pascal),
                humidity: new Humidity(humidity, Core.Units.Humidity.Relative),
                wind: new Wind(
                    speed: new Speed(windSpeed, Core.Units.Speed.MeterPerSecond),
                    direction: new Direction(windDirection),
                    gust: new Speed(windGust, Core.Units.Speed.MeterPerSecond)),
                cloudiness: new Cloudiness(cloudiness, Core.Units.Cloudiness.Relative),
                precipitation: new Precipitation(precipitation, Core.Units.Precipitation.Millimetres));
        }

        return null;
    }
}