// <copyright file="Humidity.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types;

using NUnit.Framework;

/// <summary>
/// Represents a test class for <see cref="Core.Types.Humidity"/>.
/// </summary>
public class Humidity
{
    /// <summary>
    /// Represents a test case for <see cref="Core.Types.Humidity.Humidity(double, Units.Humidity)"/> method.
    /// </summary>
    /// <param name="humidity">The value of humidity.</param>
    /// <param name="unit">The unit of pressure.</param>
    [TestCase(10, Units.Humidity.Relative)]
    [TestCase(double.MaxValue, Units.Humidity.Relative)]
    [TestCase(double.MinValue, Units.Humidity.Relative)]
    public void Constructor(double humidity, Units.Humidity unit)
    {
        var instance = new Core.Types.Humidity(humidity, unit);
        Assert.AreEqual(humidity, instance.GetHumidity(unit));
    }

    /// <summary>
    /// Represents a test case for equality.
    /// </summary>
    /// <param name="valueA">The value of humidity of the first instance.</param>
    /// <param name="unitA">The unit of humidity of the first instance.</param>
    /// <param name="valueB">The value of humidity of the second instance.</param>
    /// <param name="unitB">The unit of humidity of the second instance.</param>
    [TestCase(10.0, Units.Humidity.Relative, 10.0, Units.Humidity.Relative)]
    [TestCase(double.MaxValue, Units.Humidity.Relative, double.MaxValue, Units.Humidity.Relative)]
    [TestCase(double.MinValue, Units.Humidity.Relative, double.MinValue, Units.Humidity.Relative)]
    public void EqualityPositive(double valueA, Units.Humidity unitA, double valueB, Units.Humidity unitB)
    {
        var first = new Core.Types.Humidity(valueA, unitA);
        var second = new Core.Types.Humidity(valueB, unitB);

        Assert.AreEqual(first, second);
        Assert.AreEqual((object)first, (object)second);
        Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
        Assert.IsTrue(first == second);
    }

    /// <summary>
    /// Represents a test case for inequality.
    /// </summary>
    /// <param name="valueA">The value of humidity of the first instance.</param>
    /// <param name="unitA">The unit of humidity of the first instance.</param>
    /// <param name="valueB">The value of humidity of the second instance.</param>
    /// <param name="unitB">The unit of humidity of the second instance.</param>
    [TestCase(10.0, Units.Humidity.Relative, 20.0, Units.Humidity.Relative)]
    [TestCase(double.MinValue, Units.Humidity.Relative, double.MaxValue, Units.Humidity.Relative)]
    public void InequalityPositive(double valueA, Units.Humidity unitA, double valueB, Units.Humidity unitB)
    {
        var first = new Core.Types.Humidity(valueA, unitA);
        var second = new Core.Types.Humidity(valueB, unitB);

        Assert.AreNotEqual(first, second);
        Assert.AreNotEqual((object)first, (object)second);
        Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        Assert.IsTrue(first != second);
    }

    /// <summary>
    /// Represents a test case for <see cref="Core.Types.Humidity.ToString"/> method.
    /// </summary>
    /// <param name="expected">The value of expected return.</param>
    /// <param name="humidity">The value of humidity.</param>
    /// <param name="unit">The unit of pressure.</param>
    [TestCase("10.0", 10.0, Units.Humidity.Relative)]
    public void ToString(string expected, double humidity, Units.Humidity unit)
    {
        Assert.AreEqual(expected, new Core.Types.Humidity(humidity, unit).ToString());
    }
}