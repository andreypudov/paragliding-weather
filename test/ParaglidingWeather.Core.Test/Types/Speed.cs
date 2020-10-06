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
        /// Represents a test case for <see cref="Core.Types.Speed.Speed(int, Units.Speed)"/> method.
        /// </summary>
        /// <param name="speed">The value of speed.</param>
        /// <param name="unit">The unit of speed.</param>
        [TestCase(10, Units.Speed.MeterPerSecond)]
        [TestCase(int.MaxValue, Units.Speed.MeterPerSecond)]
        [TestCase(int.MinValue, Units.Speed.MeterPerSecond)]
        public void Constructor(int speed, Units.Speed unit)
        {
            var instance = new Core.Types.Speed(speed, unit);
            Assert.AreEqual(speed, instance.GetSpeed(unit));
        }

        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Speed.ToString"/> method.
        /// </summary>
        /// <param name="expected">The value of expected return.</param>
        /// <param name="speed">The value of speed.</param>
        /// <param name="unit">The unit of speed.</param>
        [TestCase("10", 10, Units.Speed.MeterPerSecond)]
        public void ToString(string expected, int speed, Units.Speed unit)
        {
            Assert.AreEqual(expected, new Core.Types.Speed(speed, unit).ToString());
        }
    }
}
