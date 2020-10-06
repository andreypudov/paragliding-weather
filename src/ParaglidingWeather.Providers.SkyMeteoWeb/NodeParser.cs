// <copyright file="NodeParser.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using ParaglidingWeather.Core;
    using ParaglidingWeather.Core.Types;

    /// <summary>
    /// Provides methods to parse HTML node.
    /// </summary>
    public class NodeParser
    {
        private readonly HtmlNode node;
        private readonly DateTime date;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeParser"/> class.
        /// </summary>
        /// <param name="node">The HTML node to parse.</param>
        /// <param name="date">The date of the forecast.</param>
        public NodeParser(HtmlNode node, DateTime date)
        {
            this.node = node;
            this.date = date;
        }

        /// <summary>
        /// Parses the node and returns weather information.
        /// </summary>
        /// <returns>The instance of weather reports.</returns>
        public IWeatherReport? Parse()
        {
            int columns = this.node.SelectNodes("*").Count;

            if (columns == 12)
            {
                return this.ParseDateRow();
            }
            else if (columns == 11)
            {
                return this.ParseGeneralRow();
            }

            return null;
        }

        private IWeatherReport? ParseDateRow()
        {
            const int DATE_COLUMN = 0;
            const int TIME_COLUMN = 1;
            const int TEMPERATURE_COLUMN = 2;
            const int WIND_DIRECTION_COLUMN = 3;
            const int WIND_SPEED_COLUMN = 5;
            const int WIND_GUST_COLUMN = 6;
            const int HUMIDITY_COLUMN = 7;
            const int CLOUDINESS_COLUMN = 8;
            const int PRECIPITATION_COLUMN = 9;
            const int PRESSURE_COLUMN = 10;

            var columns = this.node.SelectNodes("*");
            if ((columns[DATE_COLUMN].SelectNodes("*")?.Count != 2)
                || (int.TryParse(columns[DATE_COLUMN].SelectNodes("*")[1].InnerText, out _) == false)
                || (int.TryParse(columns[TEMPERATURE_COLUMN].InnerText, out _) == false))
            {
                return null;
            }

            if (int.TryParse(new string(columns[DATE_COLUMN].SelectNodes("*")[1].InnerText.Where(char.IsDigit).ToArray()), out int date)
                && int.TryParse(new string(columns[TIME_COLUMN].InnerText.Where(char.IsDigit).ToArray()), out int time)
                && int.TryParse(columns[TEMPERATURE_COLUMN].InnerText, out int temperature)
                && double.TryParse(columns[WIND_DIRECTION_COLUMN].LastChild.GetAttributeValue("alt", "0"), out double wind_direction)
                && int.TryParse(columns[WIND_SPEED_COLUMN].InnerText, out int wind_speed)
                && int.TryParse(columns[WIND_GUST_COLUMN].InnerText, out int wind_gust)
                && int.TryParse(columns[HUMIDITY_COLUMN].InnerText, out int humidity)
                && int.TryParse(columns[CLOUDINESS_COLUMN].InnerText, out int cloudiness)
                && double.TryParse(columns[PRECIPITATION_COLUMN].InnerText, out double precipitation)
                && int.TryParse(columns[PRESSURE_COLUMN].InnerText, out int pressure))
            {
                return new WeatherReport(
                    time: this.date.AddHours(time),
                    temperature: new Temperature(temperature, Core.Units.Temperature.Celsius),
                    pressure: new Pressure(pressure, Core.Units.Pressure.Pascal),
                    humidity: new Humidity(humidity, Core.Units.Humidity.Relative),
                    wind: new Wind(
                        speed: new Speed(wind_speed, Core.Units.Speed.MeterPerSecond),
                        direction: new Direction(wind_direction),
                        gust: new Speed(wind_gust, Core.Units.Speed.MeterPerSecond)),
                    cloudiness: new Cloudiness(cloudiness, Core.Units.Cloudiness.Relative),
                    precipitation: new Precipitation(precipitation, Core.Units.Precipitation.Millimetres));
            }

            return null;
        }

        private IWeatherReport? ParseGeneralRow()
        {
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
            if (int.TryParse(columns[TEMPERATURE_COLUMN].InnerText, out _) == false)
            {
                return null;
            }

            if (int.TryParse(new string(columns[TIME_COLUMN].InnerText.Where(char.IsDigit).ToArray()), out int time)
                && int.TryParse(columns[TEMPERATURE_COLUMN].InnerText, out int temperature)
                && double.TryParse(columns[WIND_DIRECTION_COLUMN].LastChild.GetAttributeValue("alt", "0"), out double wind_direction)
                && int.TryParse(columns[WIND_SPEED_COLUMN].InnerText, out int wind_speed)
                && int.TryParse(columns[WIND_GUST_COLUMN].InnerText, out int wind_gust)
                && int.TryParse(columns[HUMIDITY_COLUMN].InnerText, out int humidity)
                && int.TryParse(columns[CLOUDINESS_COLUMN].InnerText, out int cloudiness)
                && double.TryParse(columns[PRECIPITATION_COLUMN].InnerText, out double precipitation)
                && int.TryParse(columns[PRESSURE_COLUMN].InnerText, out int pressure))
            {
                return new WeatherReport(
                    time: this.date.AddHours(time),
                    temperature: new Temperature(temperature, Core.Units.Temperature.Celsius),
                    pressure: new Pressure(pressure, Core.Units.Pressure.Pascal),
                    humidity: new Humidity(humidity, Core.Units.Humidity.Relative),
                    wind: new Wind(
                        speed: new Speed(wind_speed, Core.Units.Speed.MeterPerSecond),
                        direction: new Direction(wind_direction),
                        gust: new Speed(wind_gust, Core.Units.Speed.MeterPerSecond)),
                    cloudiness: new Cloudiness(cloudiness, Core.Units.Cloudiness.Relative),
                    precipitation: new Precipitation(precipitation, Core.Units.Precipitation.Millimetres));
            }

            return null;
        }
    }
}
