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
        [TestCase(double.MaxValue, Units.Precipitation.Millimetres)]
        [TestCase(double.MinValue, Units.Precipitation.Millimetres)]
        public void Constructor(double precipitation, Units.Precipitation unit)
        {
            var instance = new Core.Types.Precipitation(precipitation, unit);
            Assert.AreEqual(precipitation, instance.GetPrecipitation(unit));
        }

        /// <summary>
        /// Represents a test case for equality.
        /// </summary>
        /// <param name="valueA">The value of precipitation of the first instance.</param>
        /// <param name="unitA">The unit of precipitation of the first instance.</param>
        /// <param name="valueB">The value of precipitation of the second instance.</param>
        /// <param name="unitB">The unit of precipitation of the second instance.</param>
        [TestCase(10.0, Units.Precipitation.Millimetres, 10.0, Units.Precipitation.Millimetres)]
        [TestCase(double.MaxValue, Units.Precipitation.Millimetres, double.MaxValue, Units.Precipitation.Millimetres)]
        [TestCase(double.MinValue, Units.Precipitation.Millimetres, double.MinValue, Units.Precipitation.Millimetres)]
        public void EqualityPositive(double valueA, Units.Precipitation unitA, double valueB, Units.Precipitation unitB)
        {
            var first = new Core.Types.Precipitation(valueA, unitA);
            var second = new Core.Types.Precipitation(valueB, unitB);

            Assert.AreEqual(first, second);
            Assert.AreEqual((object)first, (object)second);
            Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
            Assert.IsTrue(first == second);
        }

        /// <summary>
        /// Represents a test case for inequality.
        /// </summary>
        /// <param name="valueA">The value of precipitation of the first instance.</param>
        /// <param name="unitA">The unit of precipitation of the first instance.</param>
        /// <param name="valueB">The value of precipitation of the second instance.</param>
        /// <param name="unitB">The unit of precipitation of the second instance.</param>
        [TestCase(10.0, Units.Precipitation.Millimetres, 20.0, Units.Precipitation.Millimetres)]
        [TestCase(double.MinValue, Units.Precipitation.Millimetres, double.MaxValue, Units.Precipitation.Millimetres)]
        public void InequalityPositive(double valueA, Units.Precipitation unitA, double valueB, Units.Precipitation unitB)
        {
            var first = new Core.Types.Precipitation(valueA, unitA);
            var second = new Core.Types.Precipitation(valueB, unitB);

            Assert.AreNotEqual(first, second);
            Assert.AreNotEqual((object)first, (object)second);
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.IsTrue(first != second);
        }

        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Precipitation.ToString"/> method.
        /// </summary>
        /// <param name="expected">The value of expected return.</param>
        /// <param name="precipitation">The value of precipitation.</param>
        /// <param name="unit">The unit of precipitation.</param>
        [TestCase("10.0", 10.0, Units.Precipitation.Millimetres)]
        public void ToString(string expected, double precipitation, Units.Precipitation unit)
        {
            Assert.AreEqual(expected, new Core.Types.Precipitation(precipitation, unit).ToString());
        }
    }
}
