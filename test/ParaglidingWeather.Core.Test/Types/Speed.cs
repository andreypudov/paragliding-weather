// <copyright file="Speed.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types
{
    using NUnit.Framework;

    /// <summary>
    /// Represents a test class for <see cref="Core.Types.Speed"/>.
    /// </summary>
    public class Speed
    {
        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Speed.Speed(double, Units.Speed)"/> method.
        /// </summary>
        /// <param name="speed">The value of speed.</param>
        /// <param name="unit">The unit of speed.</param>
        [TestCase(10.0, Units.Speed.MeterPerSecond)]
        [TestCase(double.MaxValue, Units.Speed.MeterPerSecond)]
        [TestCase(double.MinValue, Units.Speed.MeterPerSecond)]
        public void Constructor(double speed, Units.Speed unit)
        {
            var instance = new Core.Types.Speed(speed, unit);
            Assert.AreEqual(speed, instance.GetSpeed(unit));
        }

        /// <summary>
        /// Represents a test case for equality.
        /// </summary>
        /// <param name="valueA">The value of speed of the first instance.</param>
        /// <param name="unitA">The unit of speed of the first instance.</param>
        /// <param name="valueB">The value of speed of the second instance.</param>
        /// <param name="unitB">The unit of speed of the second instance.</param>
        [TestCase(10.0, Units.Speed.MeterPerSecond, 10.0, Units.Speed.MeterPerSecond)]
        [TestCase(double.MaxValue, Units.Speed.MeterPerSecond, double.MaxValue, Units.Speed.MeterPerSecond)]
        [TestCase(double.MinValue, Units.Speed.MeterPerSecond, double.MinValue, Units.Speed.MeterPerSecond)]
        public void EqualityPositive(double valueA, Units.Speed unitA, double valueB, Units.Speed unitB)
        {
            var first = new Core.Types.Speed(valueA, unitA);
            var second = new Core.Types.Speed(valueB, unitB);

            Assert.AreEqual(first, second);
            Assert.AreEqual((object)first, (object)second);
            Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
            Assert.IsTrue(first == second);
        }

        /// <summary>
        /// Represents a test case for inequality.
        /// </summary>
        /// <param name="valueA">The value of speed of the first instance.</param>
        /// <param name="unitA">The unit of speed of the first instance.</param>
        /// <param name="valueB">The value of speed of the second instance.</param>
        /// <param name="unitB">The unit of speed of the second instance.</param>
        [TestCase(10.0, Units.Speed.MeterPerSecond, 20.0, Units.Speed.MeterPerSecond)]
        [TestCase(double.MinValue, Units.Speed.MeterPerSecond, double.MaxValue, Units.Speed.MeterPerSecond)]
        public void InequalityPositive(double valueA, Units.Speed unitA, double valueB, Units.Speed unitB)
        {
            var first = new Core.Types.Speed(valueA, unitA);
            var second = new Core.Types.Speed(valueB, unitB);

            Assert.AreNotEqual(first, second);
            Assert.AreNotEqual((object)first, (object)second);
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.IsTrue(first != second);
        }

        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Speed.ToString"/> method.
        /// </summary>
        /// <param name="expected">The value of expected return.</param>
        /// <param name="speed">The value of speed.</param>
        /// <param name="unit">The unit of speed.</param>
        [TestCase("10.0", 10.0, Units.Speed.MeterPerSecond)]
        public void ToString(string expected, double speed, Units.Speed unit)
        {
            Assert.AreEqual(expected, new Core.Types.Speed(speed, unit).ToString());
        }
    }
}
