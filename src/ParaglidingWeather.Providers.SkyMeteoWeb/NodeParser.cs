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
        /// <returns>The instance of weather reports.</returns>
        public IWeatherReport? Parse()
        {
            if ((this.node.ChildNodes.Count != 11)
                && (this.node.ChildNodes.Count != 12)
                && (int.TryParse(this.node.ChildNodes[2].InnerText, out _) == false))
            {
                return null;
            }

            if (int.TryParse(new string(this.node.ChildNodes[1].InnerText.Where(char.IsDigit).ToArray()), out int time)
                && int.TryParse(this.node.ChildNodes[2].InnerText, out int temperature)
                && int.TryParse(this.node.ChildNodes[3].LastChild.GetAttributeValue("alt", "0"), out int wind_direction)
                && int.TryParse(this.node.ChildNodes[5].InnerText, out int wind_speed)
                && int.TryParse(this.node.ChildNodes[6].InnerText, out int wind_gust)
                && int.TryParse(this.node.ChildNodes[7].InnerText, out int humidity)
                && int.TryParse(this.node.ChildNodes[8].InnerText, out int cloudiness)
                && double.TryParse(this.node.ChildNodes[8].InnerText, out double precipitation)
                && int.TryParse(this.node.ChildNodes[8].InnerText, out int pressure))
            {
                return new WeatherReport(
                    time: DateTime.Today.AddHours(time),
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
