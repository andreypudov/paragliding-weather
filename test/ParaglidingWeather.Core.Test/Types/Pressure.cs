// <copyright file="Pressure.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types
{
    using NUnit.Framework;

    /// <summary>
    /// Represents a test class for <see cref="Core.Types.Pressure"/>.
    /// </summary>
    public class Pressure
    {
        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Pressure.Pressure(int, Units.Pressure)"/> method.
        /// </summary>
        /// <param name="pressure">The value of pressure.</param>
        /// <param name="unit">The unit of pressure.</param>
        [TestCase(10, Units.Pressure.Pascal)]
        [TestCase(int.MaxValue, Units.Pressure.Pascal)]
        [TestCase(int.MinValue, Units.Pressure.Pascal)]
        public void Constructor(int pressure, Units.Pressure unit)
        {
            var instance = new Core.Types.Pressure(pressure, unit);
            Assert.AreEqual(pressure, instance.GetPressure(unit));
        }

        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Pressure.ToString"/> method.
        /// </summary>
        /// <param name="expected">The value of expected return.</param>
        /// <param name="pressure">The value of pressure.</param>
        /// <param name="unit">The unit of pressure.</param>
        [TestCase("10", 10, Units.Pressure.Pascal)]
        public void ToString(string expected, int pressure, Units.Pressure unit)
        {
            Assert.AreEqual(expected, new Core.Types.Pressure(pressure, unit).ToString());
        }
    }
}
