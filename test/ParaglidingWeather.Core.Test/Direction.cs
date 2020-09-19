// <copyright file="Direction.cs" company="Andrey Pudov">
// Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeatherTest.Core
{
    using System.Globalization;
    using NUnit.Framework;
    using ParaglidingWeather.Core;

    /// <summary>
    /// Represents a test class for <see cref="ParaglidingWeather.Core.Direction"/>.
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// Represents a non-localized test case for <see cref="DirectionExtension.GetAbbreviation"/> method.
        /// </summary>
        /// <param name="abbreviation">The expected value of abbreviation.</param>
        /// <param name="direction">The value of direction.</param>
        [TestCase("N", ParaglidingWeather.Core.Direction.North)]
        [TestCase("NbE", ParaglidingWeather.Core.Direction.NorthByEast)]
        [TestCase("NNE", ParaglidingWeather.Core.Direction.NorthNortheast)]
        [TestCase("NEbN", ParaglidingWeather.Core.Direction.NortheastByNorth)]
        [TestCase("NE", ParaglidingWeather.Core.Direction.Northeast)]
        [TestCase("NEbE", ParaglidingWeather.Core.Direction.NortheastByEast)]
        [TestCase("ENE", ParaglidingWeather.Core.Direction.EastNortheast)]
        [TestCase("EbN", ParaglidingWeather.Core.Direction.EastByNorth)]
        [TestCase("E", ParaglidingWeather.Core.Direction.East)]
        [TestCase("EbS", ParaglidingWeather.Core.Direction.EastBySouth)]
        [TestCase("ESE", ParaglidingWeather.Core.Direction.EastSoutheast)]
        [TestCase("SEbE", ParaglidingWeather.Core.Direction.SoutheastByEast)]
        [TestCase("SE", ParaglidingWeather.Core.Direction.Southeast)]
        [TestCase("SEbS", ParaglidingWeather.Core.Direction.SoutheastBySouth)]
        [TestCase("SSE", ParaglidingWeather.Core.Direction.SouthSoutheast)]
        [TestCase("SbE", ParaglidingWeather.Core.Direction.SouthByEast)]
        [TestCase("S", ParaglidingWeather.Core.Direction.South)]
        [TestCase("SbW", ParaglidingWeather.Core.Direction.SouthByWest)]
        [TestCase("SSW", ParaglidingWeather.Core.Direction.SouthSouthwest)]
        [TestCase("SWbS", ParaglidingWeather.Core.Direction.SouthwestBySouth)]
        [TestCase("SW", ParaglidingWeather.Core.Direction.Southwest)]
        [TestCase("SWbW", ParaglidingWeather.Core.Direction.SouthwestByWest)]
        [TestCase("WSW", ParaglidingWeather.Core.Direction.WestSouthwest)]
        [TestCase("WbS", ParaglidingWeather.Core.Direction.WestBySouth)]
        [TestCase("W", ParaglidingWeather.Core.Direction.West)]
        [TestCase("WbN", ParaglidingWeather.Core.Direction.WestByNorth)]
        [TestCase("WNW", ParaglidingWeather.Core.Direction.WestNorthwest)]
        [TestCase("NWbW", ParaglidingWeather.Core.Direction.NorthwestByWest)]
        [TestCase("NW", ParaglidingWeather.Core.Direction.Northwest)]
        [TestCase("NWbN", ParaglidingWeather.Core.Direction.NorthwestByNorth)]
        [TestCase("NNW", ParaglidingWeather.Core.Direction.NorthNorthwest)]
        [TestCase("NbW", ParaglidingWeather.Core.Direction.NorthByWest)]
        public void GetAbbreviation(string abbreviation, ParaglidingWeather.Core.Direction direction)
        {
            Assert.AreEqual(abbreviation, direction.GetAbbreviation(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Represents a localized test case for <see cref="DirectionExtension.GetAbbreviation"/> method.
        /// </summary>
        /// <param name="abbreviation">The expected value of abbreviation.</param>
        /// <param name="direction">The value of direction.</param>
        [TestCase("С", ParaglidingWeather.Core.Direction.North)]
        [TestCase("СтВ", ParaglidingWeather.Core.Direction.NorthByEast)]
        [TestCase("ССВ", ParaglidingWeather.Core.Direction.NorthNortheast)]
        [TestCase("СВтС", ParaglidingWeather.Core.Direction.NortheastByNorth)]
        [TestCase("СВ", ParaglidingWeather.Core.Direction.Northeast)]
        [TestCase("СВтВ", ParaglidingWeather.Core.Direction.NortheastByEast)]
        [TestCase("ВСВ", ParaglidingWeather.Core.Direction.EastNortheast)]
        [TestCase("ВтС", ParaglidingWeather.Core.Direction.EastByNorth)]
        [TestCase("В", ParaglidingWeather.Core.Direction.East)]
        [TestCase("ВтЮ", ParaglidingWeather.Core.Direction.EastBySouth)]
        [TestCase("ВЮВ", ParaglidingWeather.Core.Direction.EastSoutheast)]
        [TestCase("ЮВтВ", ParaglidingWeather.Core.Direction.SoutheastByEast)]
        [TestCase("ЮВ", ParaglidingWeather.Core.Direction.Southeast)]
        [TestCase("ЮВтЮ", ParaglidingWeather.Core.Direction.SoutheastBySouth)]
        [TestCase("ЮЮВ", ParaglidingWeather.Core.Direction.SouthSoutheast)]
        [TestCase("ЮтВ", ParaglidingWeather.Core.Direction.SouthByEast)]
        [TestCase("Ю", ParaglidingWeather.Core.Direction.South)]
        [TestCase("ЮтЗ", ParaglidingWeather.Core.Direction.SouthByWest)]
        [TestCase("ЮЮЗ", ParaglidingWeather.Core.Direction.SouthSouthwest)]
        [TestCase("ЮЗтЮ", ParaglidingWeather.Core.Direction.SouthwestBySouth)]
        [TestCase("ЮЗ", ParaglidingWeather.Core.Direction.Southwest)]
        [TestCase("ЮЗтЗ", ParaglidingWeather.Core.Direction.SouthwestByWest)]
        [TestCase("ЗЮЗ", ParaglidingWeather.Core.Direction.WestSouthwest)]
        [TestCase("ЗтЮ", ParaglidingWeather.Core.Direction.WestBySouth)]
        [TestCase("З", ParaglidingWeather.Core.Direction.West)]
        [TestCase("ЗтС", ParaglidingWeather.Core.Direction.WestByNorth)]
        [TestCase("ЗСЗ", ParaglidingWeather.Core.Direction.WestNorthwest)]
        [TestCase("СЗтЗ", ParaglidingWeather.Core.Direction.NorthwestByWest)]
        [TestCase("СЗ", ParaglidingWeather.Core.Direction.Northwest)]
        [TestCase("СЗтС", ParaglidingWeather.Core.Direction.NorthwestByNorth)]
        [TestCase("ССЗ", ParaglidingWeather.Core.Direction.NorthNorthwest)]
        [TestCase("СтЗ", ParaglidingWeather.Core.Direction.NorthByWest)]
        public void GetLocalizedAbbreviation(string abbreviation, ParaglidingWeather.Core.Direction direction)
        {
            Assert.AreEqual(abbreviation, direction.GetAbbreviation(new CultureInfo("ru-RU")));
        }
    }
}