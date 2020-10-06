// <copyright file="Temperature.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types
{
    using NUnit.Framework;

    /// <summary>
    /// Represents a test class for <see cref="Core.Types.Temperature"/>.
    /// </summary>
    public class Temperature
    {
        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Temperature.Temperature(int, Units.Temperature)"/> method.
        /// </summary>
        /// <param name="temperature">The value of temperature.</param>
        /// <param name="unit">The unit of temperature.</param>
        [TestCase(10, Units.Temperature.Celsius)]
        [TestCase(int.MaxValue, Units.Temperature.Celsius)]
        [TestCase(int.MinValue, Units.Temperature.Celsius)]
        public void Constructor(int temperature, Units.Temperature unit)
        {
            var instance = new Core.Types.Temperature(temperature, unit);
            Assert.AreEqual(temperature, instance.GetTemperature(unit));
        }

        /// <summary>
        /// Represents a test case for equality.
        /// </summary>
        /// <param name="valueA">The value of temperature of the first instance.</param>
        /// <param name="unitA">The unit of temperature of the first instance.</param>
        /// <param name="valueB">The value of temperature of the second instance.</param>
        /// <param name="unitB">The unit of temperature of the second instance.</param>
        [TestCase(10, Units.Temperature.Celsius, 10, Units.Temperature.Celsius)]
        [TestCase(int.MaxValue, Units.Temperature.Celsius, int.MaxValue, Units.Temperature.Celsius)]
        [TestCase(int.MinValue, Units.Temperature.Celsius, int.MinValue, Units.Temperature.Celsius)]
        public void EqualityPositive(int valueA, Units.Temperature unitA, int valueB, Units.Temperature unitB)
        {
            var first = new Core.Types.Temperature(valueA, unitA);
            var second = new Core.Types.Temperature(valueB, unitB);

            Assert.AreEqual(first, second);
            Assert.AreEqual((object)first, (object)second);
            Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
            Assert.IsTrue(first == second);
        }

        /// <summary>
        /// Represents a test case for inequality.
        /// </summary>
        /// <param name="valueA">The value of temperature of the first instance.</param>
        /// <param name="unitA">The unit of temperature of the first instance.</param>
        /// <param name="valueB">The value of temperature of the second instance.</param>
        /// <param name="unitB">The unit of temperature of the second instance.</param>
        [TestCase(10, Units.Temperature.Celsius, 20, Units.Temperature.Celsius)]
        [TestCase(int.MinValue, Units.Temperature.Celsius, int.MaxValue, Units.Temperature.Celsius)]
        public void InequalityPositive(int valueA, Units.Temperature unitA, int valueB, Units.Temperature unitB)
        {
            var first = new Core.Types.Temperature(valueA, unitA);
            var second = new Core.Types.Temperature(valueB, unitB);

            Assert.AreNotEqual(first, second);
            Assert.AreNotEqual((object)first, (object)second);
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.IsTrue(first != second);
        }

        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Temperature.ToString"/> method.
        /// </summary>
        /// <param name="expected">The value of expected return.</param>
        /// <param name="temperature">The value of temperature.</param>
        /// <param name="unit">The unit of temperature.</param>
        [TestCase("10", 10, Units.Temperature.Celsius)]
        public void ToString(string expected, int temperature, Units.Temperature unit)
        {
            Assert.AreEqual(expected, new Core.Types.Temperature(temperature, unit).ToString());
        }
    }
}
