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
        /// Represents a test case for <see cref="Core.Types.Wind.Wind(ISpeed, Core.Types.Direction, ISpeed)"/> method.
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
    }
}
