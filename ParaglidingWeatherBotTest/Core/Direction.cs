// <copyright file="Direction.cs" company="Andrey Pudov">
// Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeatherBotTest.Core
{
    using System.Globalization;
    using NUnit.Framework;
    using ParaglidingWeatherBot.Core;

    /// <summary>
    /// Represents a test class for <see cref="ParaglidingWeatherBot.Core.Direction"/>.
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// Represents a non-localized test case for <see cref="DirectionExtension.GetAbbreviation"/> method.
        /// </summary>
        /// <param name="abbreviation">The expected value of abbreviation.</param>
        /// <param name="direction">The value of direction.</param>
        [TestCase("N", ParaglidingWeatherBot.Core.Direction.North)]
        [TestCase("NbE", ParaglidingWeatherBot.Core.Direction.NorthByEast)]
        [TestCase("NNE", ParaglidingWeatherBot.Core.Direction.NorthNortheast)]
        [TestCase("NEbN", ParaglidingWeatherBot.Core.Direction.NortheastByNorth)]
        [TestCase("NE", ParaglidingWeatherBot.Core.Direction.Northeast)]
        [TestCase("NEbE", ParaglidingWeatherBot.Core.Direction.NortheastByEast)]
        [TestCase("ENE", ParaglidingWeatherBot.Core.Direction.EastNortheast)]
        [TestCase("EbN", ParaglidingWeatherBot.Core.Direction.EastByNorth)]
        [TestCase("E", ParaglidingWeatherBot.Core.Direction.East)]
        [TestCase("EbS", ParaglidingWeatherBot.Core.Direction.EastBySouth)]
        [TestCase("ESE", ParaglidingWeatherBot.Core.Direction.EastSoutheast)]
        [TestCase("SEbE", ParaglidingWeatherBot.Core.Direction.SoutheastByEast)]
        [TestCase("SE", ParaglidingWeatherBot.Core.Direction.Southeast)]
        [TestCase("SEbS", ParaglidingWeatherBot.Core.Direction.SoutheastBySouth)]
        [TestCase("SSE", ParaglidingWeatherBot.Core.Direction.SouthSoutheast)]
        [TestCase("SbE", ParaglidingWeatherBot.Core.Direction.SouthByEast)]
        [TestCase("S", ParaglidingWeatherBot.Core.Direction.South)]
        [TestCase("SbW", ParaglidingWeatherBot.Core.Direction.SouthByWest)]
        [TestCase("SSW", ParaglidingWeatherBot.Core.Direction.SouthSouthwest)]
        [TestCase("SWbS", ParaglidingWeatherBot.Core.Direction.SouthwestBySouth)]
        [TestCase("SW", ParaglidingWeatherBot.Core.Direction.Southwest)]
        [TestCase("SWbW", ParaglidingWeatherBot.Core.Direction.SouthwestByWest)]
        [TestCase("WSW", ParaglidingWeatherBot.Core.Direction.WestSouthwest)]
        [TestCase("WbS", ParaglidingWeatherBot.Core.Direction.WestBySouth)]
        [TestCase("W", ParaglidingWeatherBot.Core.Direction.West)]
        [TestCase("WbN", ParaglidingWeatherBot.Core.Direction.WestByNorth)]
        [TestCase("WNW", ParaglidingWeatherBot.Core.Direction.WestNorthwest)]
        [TestCase("NWbW", ParaglidingWeatherBot.Core.Direction.NorthwestByWest)]
        [TestCase("NW", ParaglidingWeatherBot.Core.Direction.Northwest)]
        [TestCase("NWbN", ParaglidingWeatherBot.Core.Direction.NorthwestByNorth)]
        [TestCase("NNW", ParaglidingWeatherBot.Core.Direction.NorthNorthwest)]
        [TestCase("NbW", ParaglidingWeatherBot.Core.Direction.NorthByWest)]
        public void GetAbbreviation(string abbreviation, ParaglidingWeatherBot.Core.Direction direction)
        {
            Assert.AreEqual(abbreviation, direction.GetAbbreviation(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Represents a localized test case for <see cref="DirectionExtension.GetAbbreviation"/> method.
        /// </summary>
        /// <param name="abbreviation">The expected value of abbreviation.</param>
        /// <param name="direction">The value of direction.</param>
        [TestCase("С", ParaglidingWeatherBot.Core.Direction.North)]
        [TestCase("СтВ", ParaglidingWeatherBot.Core.Direction.NorthByEast)]
        [TestCase("ССВ", ParaglidingWeatherBot.Core.Direction.NorthNortheast)]
        [TestCase("СВтС", ParaglidingWeatherBot.Core.Direction.NortheastByNorth)]
        [TestCase("СВ", ParaglidingWeatherBot.Core.Direction.Northeast)]
        [TestCase("СВтВ", ParaglidingWeatherBot.Core.Direction.NortheastByEast)]
        [TestCase("ВСВ", ParaglidingWeatherBot.Core.Direction.EastNortheast)]
        [TestCase("ВтС", ParaglidingWeatherBot.Core.Direction.EastByNorth)]
        [TestCase("В", ParaglidingWeatherBot.Core.Direction.East)]
        [TestCase("ВтЮ", ParaglidingWeatherBot.Core.Direction.EastBySouth)]
        [TestCase("ВЮВ", ParaglidingWeatherBot.Core.Direction.EastSoutheast)]
        [TestCase("ЮВтВ", ParaglidingWeatherBot.Core.Direction.SoutheastByEast)]
        [TestCase("ЮВ", ParaglidingWeatherBot.Core.Direction.Southeast)]
        [TestCase("ЮВтЮ", ParaglidingWeatherBot.Core.Direction.SoutheastBySouth)]
        [TestCase("ЮЮВ", ParaglidingWeatherBot.Core.Direction.SouthSoutheast)]
        [TestCase("ЮтВ", ParaglidingWeatherBot.Core.Direction.SouthByEast)]
        [TestCase("Ю", ParaglidingWeatherBot.Core.Direction.South)]
        [TestCase("ЮтЗ", ParaglidingWeatherBot.Core.Direction.SouthByWest)]
        [TestCase("ЮЮЗ", ParaglidingWeatherBot.Core.Direction.SouthSouthwest)]
        [TestCase("ЮЗтЮ", ParaglidingWeatherBot.Core.Direction.SouthwestBySouth)]
        [TestCase("ЮЗ", ParaglidingWeatherBot.Core.Direction.Southwest)]
        [TestCase("ЮЗтЗ", ParaglidingWeatherBot.Core.Direction.SouthwestByWest)]
        [TestCase("ЗЮЗ", ParaglidingWeatherBot.Core.Direction.WestSouthwest)]
        [TestCase("ЗтЮ", ParaglidingWeatherBot.Core.Direction.WestBySouth)]
        [TestCase("З", ParaglidingWeatherBot.Core.Direction.West)]
        [TestCase("ЗтС", ParaglidingWeatherBot.Core.Direction.WestByNorth)]
        [TestCase("ЗСЗ", ParaglidingWeatherBot.Core.Direction.WestNorthwest)]
        [TestCase("СЗтЗ", ParaglidingWeatherBot.Core.Direction.NorthwestByWest)]
        [TestCase("СЗ", ParaglidingWeatherBot.Core.Direction.Northwest)]
        [TestCase("СЗтС", ParaglidingWeatherBot.Core.Direction.NorthwestByNorth)]
        [TestCase("ССЗ", ParaglidingWeatherBot.Core.Direction.NorthNorthwest)]
        [TestCase("СтЗ", ParaglidingWeatherBot.Core.Direction.NorthByWest)]
        public void GetLocalizedAbbreviation(string abbreviation, ParaglidingWeatherBot.Core.Direction direction)
        {
            Assert.AreEqual(abbreviation, direction.GetAbbreviation(new CultureInfo("ru-RU")));
        }
    }
}