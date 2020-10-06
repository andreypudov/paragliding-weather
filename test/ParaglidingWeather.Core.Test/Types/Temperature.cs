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
    }
}
