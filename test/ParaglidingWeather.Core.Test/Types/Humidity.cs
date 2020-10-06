// <copyright file="Humidity.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types
{
    using NUnit.Framework;

    /// <summary>
    /// Represents a test class for <see cref="Core.Types.Humidity"/>.
    /// </summary>
    public class Humidity
    {
        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Humidity.Humidity(int, Units.Humidity)"/> method.
        /// </summary>
        /// <param name="humidity">The value of humidity.</param>
        /// <param name="unit">The unit of pressure.</param>
        [TestCase(10, Units.Humidity.Relative)]
        [TestCase(int.MaxValue, Units.Humidity.Relative)]
        [TestCase(int.MinValue, Units.Humidity.Relative)]
        public void Constructor(int humidity, Units.Humidity unit)
        {
            var instance = new Core.Types.Humidity(humidity, unit);
            Assert.AreEqual(humidity, instance.GetHumidity(unit));
        }

        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Humidity.ToString"/> method.
        /// </summary>
        /// <param name="expected">The value of expected return.</param>
        /// <param name="humidity">The value of humidity.</param>
        /// <param name="unit">The unit of pressure.</param>
        [TestCase("10", 10, Units.Humidity.Relative)]
        public void ToString(string expected, int humidity, Units.Humidity unit)
        {
            Assert.AreEqual(expected, new Core.Types.Humidity(humidity, unit).ToString());
        }
    }
}
