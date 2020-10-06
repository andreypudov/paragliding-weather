// <copyright file="Wind.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types
{
    using NUnit.Framework;
    using ParaglidingWeather.Core.Types;

    /// <summary>
    /// Represents a test class for <see cref="Core.Types.Wind"/>.
    /// </summary>
    public class Wind
    {
        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Wind.Wind(ISpeed, IDirection, ISpeed)"/> method.
        /// </summary>
        /// <param name="speed">The value of wind speend.</param>
        /// <param name="direction">The value of wind direction.</param>
        /// <param name="gust">The value of wind gust.</param>
        [TestCase(10, 20.0, 5)]
        public void Constructor(int speed, double direction, int gust)
        {
            var instance = new Core.Types.Wind(
                new Core.Types.Speed(speed, Units.Speed.MeterPerSecond),
                new Core.Types.Direction(direction),
                new Core.Types.Speed(gust, Units.Speed.MeterPerSecond));
            Assert.AreEqual(speed, instance.Speed.GetSpeed(Units.Speed.MeterPerSecond));
            Assert.AreEqual(direction, instance.Direction.Degree);
            Assert.AreEqual(gust, instance.Gust.GetSpeed(Units.Speed.MeterPerSecond));
        }

        /// <summary>
        /// Represents a test case for equality.
        /// </summary>
        /// <param name="speedA">The value of wind speend of the first instance.</param>
        /// <param name="directionA">The value of wind direction of the first instance.</param>
        /// <param name="gustA">The value of wind gust of the first instance.</param>
        /// <param name="speedB">The value of wind speend of the second instance.</param>
        /// <param name="directionB">The value of wind direction of the second instance.</param>
        /// <param name="gustB">The value of wind gust of the second instance.</param>
        [TestCase(10, 20.0, 5, 10, 20.0, 5)]
        public void EqualityPositive(int speedA, double directionA, int gustA, int speedB, double directionB, int gustB)
        {
            var first = new Core.Types.Wind(
                new Core.Types.Speed(speedA, Units.Speed.MeterPerSecond),
                new Core.Types.Direction(directionA),
                new Core.Types.Speed(gustA, Units.Speed.MeterPerSecond));
            var second = new Core.Types.Wind(
                new Core.Types.Speed(speedB, Units.Speed.MeterPerSecond),
                new Core.Types.Direction(directionB),
                new Core.Types.Speed(gustB, Units.Speed.MeterPerSecond));

            Assert.AreEqual(first, second);
            Assert.AreEqual((object)first, (object)second);
            Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
            Assert.IsTrue(first == second);
        }

        /// <summary>
        /// Represents a test case for inequality.
        /// </summary>
        /// <param name="speedA">The value of wind speend of the first instance.</param>
        /// <param name="directionA">The value of wind direction of the first instance.</param>
        /// <param name="gustA">The value of wind gust of the first instance.</param>
        /// <param name="speedB">The value of wind speend of the second instance.</param>
        /// <param name="directionB">The value of wind direction of the second instance.</param>
        /// <param name="gustB">The value of wind gust of the second instance.</param>
        [TestCase(10, 20.0, 5, 20, 20.0, 5)]
        [TestCase(10, 20.0, 5, 10, 20.5, 5)]
        [TestCase(10, 20.0, 5, 10, 20.0, 0)]
        public void InequalityPositive(int speedA, double directionA, int gustA, int speedB, double directionB, int gustB)
        {
            var first = new Core.Types.Wind(
                new Core.Types.Speed(speedA, Units.Speed.MeterPerSecond),
                new Core.Types.Direction(directionA),
                new Core.Types.Speed(gustA, Units.Speed.MeterPerSecond));
            var second = new Core.Types.Wind(
                new Core.Types.Speed(speedB, Units.Speed.MeterPerSecond),
                new Core.Types.Direction(directionB),
                new Core.Types.Speed(gustB, Units.Speed.MeterPerSecond));

            Assert.AreNotEqual(first, second);
            Assert.AreNotEqual((object)first, (object)second);
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.IsTrue(first != second);
        }

        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Temperature.ToString"/> method.
        /// </summary>
        /// <param name="expected">The value of expected return.</param>
        /// <param name="speed">The value of wind speend.</param>
        /// <param name="direction">The value of wind direction.</param>
        /// <param name="gust">The value of wind gust.</param>
        [TestCase("[10, 20.0, 5]", 10, 20.0, 5)]
        public void ToString(string expected, int speed, double direction, int gust)
        {
            var instance = new Core.Types.Wind(
                new Core.Types.Speed(speed, Units.Speed.MeterPerSecond),
                new Core.Types.Direction(direction),
                new Core.Types.Speed(gust, Units.Speed.MeterPerSecond));
            Assert.AreEqual(expected, instance.ToString());
        }
    }
}
