// <copyright file="Pressure.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types;

using NUnit.Framework;

/// <summary>
/// Represents a test class for <see cref="Core.Types.Pressure"/>.
/// </summary>
public class Pressure
{
    /// <summary>
    /// Represents a test case for <see cref="Core.Types.Pressure.Pressure(double, Units.Pressure)"/> method.
    /// </summary>
    /// <param name="pressure">The value of pressure.</param>
    /// <param name="unit">The unit of pressure.</param>
    [TestCase(10.0, Units.Pressure.Pascal)]
    [TestCase(double.MaxValue, Units.Pressure.Pascal)]
    [TestCase(double.MinValue, Units.Pressure.Pascal)]
    public void Constructor(double pressure, Units.Pressure unit)
    {
        var instance = new Core.Types.Pressure(pressure, unit);
        Assert.AreEqual(pressure, instance.GetPressure(unit));
    }

    /// <summary>
    /// Represents a test case for equality.
    /// </summary>
    /// <param name="valueA">The value of pressure of the first instance.</param>
    /// <param name="unitA">The unit of pressure of the first instance.</param>
    /// <param name="valueB">The value of pressure of the second instance.</param>
    /// <param name="unitB">The unit of pressure of the second instance.</param>
    [TestCase(10.0, Units.Pressure.Pascal, 10.0, Units.Pressure.Pascal)]
    [TestCase(double.MaxValue, Units.Pressure.Pascal, double.MaxValue, Units.Pressure.Pascal)]
    [TestCase(double.MinValue, Units.Pressure.Pascal, double.MinValue, Units.Pressure.Pascal)]
    public void EqualityPositive(double valueA, Units.Pressure unitA, double valueB, Units.Pressure unitB)
    {
        var first = new Core.Types.Pressure(valueA, unitA);
        var second = new Core.Types.Pressure(valueB, unitB);

        Assert.AreEqual(first, second);
        Assert.AreEqual((object)first, (object)second);
        Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
        Assert.IsTrue(first == second);
    }

    /// <summary>
    /// Represents a test case for inequality.
    /// </summary>
    /// <param name="valueA">The value of pressure of the first instance.</param>
    /// <param name="unitA">The unit of pressure of the first instance.</param>
    /// <param name="valueB">The value of pressure of the second instance.</param>
    /// <param name="unitB">The unit of pressure of the second instance.</param>
    [TestCase(10.0, Units.Pressure.Pascal, 20.0, Units.Pressure.Pascal)]
    [TestCase(double.MinValue, Units.Pressure.Pascal, double.MaxValue, Units.Pressure.Pascal)]
    public void InequalityPositive(double valueA, Units.Pressure unitA, double valueB, Units.Pressure unitB)
    {
        var first = new Core.Types.Pressure(valueA, unitA);
        var second = new Core.Types.Pressure(valueB, unitB);

        Assert.AreNotEqual(first, second);
        Assert.AreNotEqual((object)first, (object)second);
        Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        Assert.IsTrue(first != second);
    }

    /// <summary>
    /// Represents a test case for <see cref="Core.Types.Pressure.ToString"/> method.
    /// </summary>
    /// <param name="expected">The value of expected return.</param>
    /// <param name="pressure">The value of pressure.</param>
    /// <param name="unit">The unit of pressure.</param>
    [TestCase("10.0", 10.0, Units.Pressure.Pascal)]
    public void ToString(string expected, double pressure, Units.Pressure unit)
    {
        Assert.AreEqual(expected, new Core.Types.Pressure(pressure, unit).ToString());
    }
}