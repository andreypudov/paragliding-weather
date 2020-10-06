// <copyright file="CompassPoint.cs" company="Andrey Pudov">
// Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test
{
    using System.Globalization;
    using NUnit.Framework;
    using ParaglidingWeather.Core;

    /// <summary>
    /// Represents a test class for <see cref="ParaglidingWeather.Core.CompassPoint"/>.
    /// </summary>
    public class CompassPoint
    {
        /// <summary>
        /// Represents a non-localized test case for <see cref="CompassPointExtension.GetAbbreviation"/> method.
        /// </summary>
        /// <param name="abbreviation">The expected value of abbreviation.</param>
        /// <param name="point">The value of compass point.</param>
        [TestCase("N", ParaglidingWeather.Core.CompassPoint.North)]
        [TestCase("NbE", ParaglidingWeather.Core.CompassPoint.NorthByEast)]
        [TestCase("NNE", ParaglidingWeather.Core.CompassPoint.NorthNortheast)]
        [TestCase("NEbN", ParaglidingWeather.Core.CompassPoint.NortheastByNorth)]
        [TestCase("NE", ParaglidingWeather.Core.CompassPoint.Northeast)]
        [TestCase("NEbE", ParaglidingWeather.Core.CompassPoint.NortheastByEast)]
        [TestCase("ENE", ParaglidingWeather.Core.CompassPoint.EastNortheast)]
        [TestCase("EbN", ParaglidingWeather.Core.CompassPoint.EastByNorth)]
        [TestCase("E", ParaglidingWeather.Core.CompassPoint.East)]
        [TestCase("EbS", ParaglidingWeather.Core.CompassPoint.EastBySouth)]
        [TestCase("ESE", ParaglidingWeather.Core.CompassPoint.EastSoutheast)]
        [TestCase("SEbE", ParaglidingWeather.Core.CompassPoint.SoutheastByEast)]
        [TestCase("SE", ParaglidingWeather.Core.CompassPoint.Southeast)]
        [TestCase("SEbS", ParaglidingWeather.Core.CompassPoint.SoutheastBySouth)]
        [TestCase("SSE", ParaglidingWeather.Core.CompassPoint.SouthSoutheast)]
        [TestCase("SbE", ParaglidingWeather.Core.CompassPoint.SouthByEast)]
        [TestCase("S", ParaglidingWeather.Core.CompassPoint.South)]
        [TestCase("SbW", ParaglidingWeather.Core.CompassPoint.SouthByWest)]
        [TestCase("SSW", ParaglidingWeather.Core.CompassPoint.SouthSouthwest)]
        [TestCase("SWbS", ParaglidingWeather.Core.CompassPoint.SouthwestBySouth)]
        [TestCase("SW", ParaglidingWeather.Core.CompassPoint.Southwest)]
        [TestCase("SWbW", ParaglidingWeather.Core.CompassPoint.SouthwestByWest)]
        [TestCase("WSW", ParaglidingWeather.Core.CompassPoint.WestSouthwest)]
        [TestCase("WbS", ParaglidingWeather.Core.CompassPoint.WestBySouth)]
        [TestCase("W", ParaglidingWeather.Core.CompassPoint.West)]
        [TestCase("WbN", ParaglidingWeather.Core.CompassPoint.WestByNorth)]
        [TestCase("WNW", ParaglidingWeather.Core.CompassPoint.WestNorthwest)]
        [TestCase("NWbW", ParaglidingWeather.Core.CompassPoint.NorthwestByWest)]
        [TestCase("NW", ParaglidingWeather.Core.CompassPoint.Northwest)]
        [TestCase("NWbN", ParaglidingWeather.Core.CompassPoint.NorthwestByNorth)]
        [TestCase("NNW", ParaglidingWeather.Core.CompassPoint.NorthNorthwest)]
        [TestCase("NbW", ParaglidingWeather.Core.CompassPoint.NorthByWest)]
        public void GetAbbreviation(string abbreviation, ParaglidingWeather.Core.CompassPoint point)
        {
            Assert.AreEqual(abbreviation, point.GetAbbreviation(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Represents a localized test case for <see cref="CompassPointExtension.GetAbbreviation"/> method.
        /// </summary>
        /// <param name="abbreviation">The expected value of abbreviation.</param>
        /// <param name="point">The value of compass point.</param>
        [TestCase("С", ParaglidingWeather.Core.CompassPoint.North)]
        [TestCase("СтВ", ParaglidingWeather.Core.CompassPoint.NorthByEast)]
        [TestCase("ССВ", ParaglidingWeather.Core.CompassPoint.NorthNortheast)]
        [TestCase("СВтС", ParaglidingWeather.Core.CompassPoint.NortheastByNorth)]
        [TestCase("СВ", ParaglidingWeather.Core.CompassPoint.Northeast)]
        [TestCase("СВтВ", ParaglidingWeather.Core.CompassPoint.NortheastByEast)]
        [TestCase("ВСВ", ParaglidingWeather.Core.CompassPoint.EastNortheast)]
        [TestCase("ВтС", ParaglidingWeather.Core.CompassPoint.EastByNorth)]
        [TestCase("В", ParaglidingWeather.Core.CompassPoint.East)]
        [TestCase("ВтЮ", ParaglidingWeather.Core.CompassPoint.EastBySouth)]
        [TestCase("ВЮВ", ParaglidingWeather.Core.CompassPoint.EastSoutheast)]
        [TestCase("ЮВтВ", ParaglidingWeather.Core.CompassPoint.SoutheastByEast)]
        [TestCase("ЮВ", ParaglidingWeather.Core.CompassPoint.Southeast)]
        [TestCase("ЮВтЮ", ParaglidingWeather.Core.CompassPoint.SoutheastBySouth)]
        [TestCase("ЮЮВ", ParaglidingWeather.Core.CompassPoint.SouthSoutheast)]
        [TestCase("ЮтВ", ParaglidingWeather.Core.CompassPoint.SouthByEast)]
        [TestCase("Ю", ParaglidingWeather.Core.CompassPoint.South)]
        [TestCase("ЮтЗ", ParaglidingWeather.Core.CompassPoint.SouthByWest)]
        [TestCase("ЮЮЗ", ParaglidingWeather.Core.CompassPoint.SouthSouthwest)]
        [TestCase("ЮЗтЮ", ParaglidingWeather.Core.CompassPoint.SouthwestBySouth)]
        [TestCase("ЮЗ", ParaglidingWeather.Core.CompassPoint.Southwest)]
        [TestCase("ЮЗтЗ", ParaglidingWeather.Core.CompassPoint.SouthwestByWest)]
        [TestCase("ЗЮЗ", ParaglidingWeather.Core.CompassPoint.WestSouthwest)]
        [TestCase("ЗтЮ", ParaglidingWeather.Core.CompassPoint.WestBySouth)]
        [TestCase("З", ParaglidingWeather.Core.CompassPoint.West)]
        [TestCase("ЗтС", ParaglidingWeather.Core.CompassPoint.WestByNorth)]
        [TestCase("ЗСЗ", ParaglidingWeather.Core.CompassPoint.WestNorthwest)]
        [TestCase("СЗтЗ", ParaglidingWeather.Core.CompassPoint.NorthwestByWest)]
        [TestCase("СЗ", ParaglidingWeather.Core.CompassPoint.Northwest)]
        [TestCase("СЗтС", ParaglidingWeather.Core.CompassPoint.NorthwestByNorth)]
        [TestCase("ССЗ", ParaglidingWeather.Core.CompassPoint.NorthNorthwest)]
        [TestCase("СтЗ", ParaglidingWeather.Core.CompassPoint.NorthByWest)]
        public void GetLocalizedAbbreviation(string abbreviation, ParaglidingWeather.Core.CompassPoint point)
        {
            Assert.AreEqual(abbreviation, point.GetAbbreviation(new CultureInfo("ru-RU")));
        }
    }
}