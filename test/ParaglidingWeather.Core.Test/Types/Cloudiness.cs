// <copyright file="Cloudiness.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types;

using NUnit.Framework;

/// <summary>
/// Represents a test class for <see cref="Core.Types.Cloudiness"/>.
/// </summary>
public class Cloudiness
{
    /// <summary>
    /// Represents a test case for <see cref="Core.Types.Cloudiness.Cloudiness(double, Units.Cloudiness)"/> method.
    /// </summary>
    /// <param name="cloudiness">The value of cloudiness.</param>
    /// <param name="unit">The unit of cloudiness.</param>
    [TestCase(10.0, Units.Cloudiness.Relative)]
    [TestCase(double.MaxValue, Units.Cloudiness.Relative)]
    [TestCase(double.MinValue, Units.Cloudiness.Relative)]
    public void Constructor(double cloudiness, Units.Cloudiness unit)
    {
        var instance = new Core.Types.Cloudiness(cloudiness, unit);
        Assert.AreEqual(cloudiness, instance.GetCloudiness(unit));
    }

    /// <summary>
    /// Represents a test case for equality.
    /// </summary>
    /// <param name="valueA">The value of cloudiness of the first instance.</param>
    /// <param name="unitA">The unit of cloudiness of the first instance.</param>
    /// <param name="valueB">The value of cloudiness of the second instance.</param>
    /// <param name="unitB">The unit of cloudiness of the second instance.</param>
    [TestCase(10.0, Units.Cloudiness.Relative, 10.0, Units.Cloudiness.Relative)]
    [TestCase(double.MaxValue, Units.Cloudiness.Relative, double.MaxValue, Units.Cloudiness.Relative)]
    [TestCase(double.MinValue, Units.Cloudiness.Relative, double.MinValue, Units.Cloudiness.Relative)]
    public void EqualityPositive(double valueA, Units.Cloudiness unitA, double valueB, Units.Cloudiness unitB)
    {
        var first = new Core.Types.Cloudiness(valueA, unitA);
        var second = new Core.Types.Cloudiness(valueB, unitB);

        Assert.AreEqual(first, second);
        Assert.AreEqual((object)first, (object)second);
        Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
        Assert.IsTrue(first == second);
    }

    /// <summary>
    /// Represents a test case for inequality.
    /// </summary>
    /// <param name="valueA">The value of cloudiness of the first instance.</param>
    /// <param name="unitA">The unit of cloudiness of the first instance.</param>
    /// <param name="valueB">The value of cloudiness of the second instance.</param>
    /// <param name="unitB">The unit of cloudiness of the second instance.</param>
    [TestCase(10.0, Units.Cloudiness.Relative, 20.0, Units.Cloudiness.Relative)]
    [TestCase(double.MinValue, Units.Cloudiness.Relative, double.MaxValue, Units.Cloudiness.Relative)]
    public void InequalityPositive(double valueA, Units.Cloudiness unitA, double valueB, Units.Cloudiness unitB)
    {
        var first = new Core.Types.Cloudiness(valueA, unitA);
        var second = new Core.Types.Cloudiness(valueB, unitB);

        Assert.AreNotEqual(first, second);
        Assert.AreNotEqual((object)first, (object)second);
        Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        Assert.IsTrue(first != second);
    }

    /// <summary>
    /// Represents a test case for <see cref="Core.Types.Cloudiness.ToString"/> method.
    /// </summary>
    /// <param name="expected">The value of expected return.</param>
    /// <param name="cloudiness">The value of cloudiness.</param>
    /// <param name="unit">The unit of cloudiness.</param>
    [TestCase("10.0", 10.0, Units.Cloudiness.Relative)]
    public void ToString(string expected, double cloudiness, Units.Cloudiness unit)
    {
        Assert.AreEqual(expected, new Core.Types.Cloudiness(cloudiness, unit).ToString());
    }
}