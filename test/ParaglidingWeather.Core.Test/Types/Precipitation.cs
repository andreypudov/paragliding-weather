// <copyright file="Precipitation.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types
{
    using NUnit.Framework;

    /// <summary>
    /// Represents a test class for <see cref="Core.Types.Precipitation"/>.
    /// </summary>
    public class Precipitation
    {
        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Precipitation.Precipitation(double, Units.Precipitation)"/> method.
        /// </summary>
        /// <param name="precipitation">The value of precipitation.</param>
        /// <param name="unit">The unit of precipitation.</param>
        [TestCase(10.0, Units.Humidity.Relative)]
        [TestCase(double.MaxValue, Units.Humidity.Relative)]
        [TestCase(double.MinValue, Units.Humidity.Relative)]
        public void Constructor(double precipitation, Units.Precipitation unit)
        {
            var instance = new Core.Types.Precipitation(precipitation, unit);
            Assert.AreEqual(precipitation, instance.GetPrecipitation(unit));
        }
    }
}
