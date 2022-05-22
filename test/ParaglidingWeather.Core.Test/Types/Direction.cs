// <copyright file="Direction.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types;

using NUnit.Framework;

/// <summary>
/// Represents a test class for <see cref="Core.Types.Direction"/>.
/// </summary>
public class Direction
{
    /// <summary>
    /// Represents a test case for <see cref="Core.Types.Direction.Direction(double)"/> method.
    /// </summary>
    /// <param name="degree">The value of the compass degree.</param>
    [TestCase(10.0)]
    [TestCase(double.MaxValue)]
    [TestCase(double.MinValue)]
    public void Constructor(double degree)
    {
        var instance = new Core.Types.Direction(degree);
        Assert.AreEqual(degree, instance.Degree);
    }

    /// <summary>
    /// Represents a test case for equality.
    /// </summary>
    /// <param name="degreeA">The value of the first compass degree.</param>
    /// <param name="degreeB">The value of the second compass degree.</param>
    [TestCase(10.0, 10.0)]
    [TestCase(double.MaxValue, double.MaxValue)]
    [TestCase(double.MinValue, double.MinValue)]
    public void EqualityPositive(double degreeA, double degreeB)
    {
        var first = new Core.Types.Direction(degreeA);
        var second = new Core.Types.Direction(degreeB);

        Assert.AreEqual(first, second);
        Assert.AreEqual((object)first, (object)second);
        Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
        Assert.IsTrue(first == second);
    }

    /// <summary>
    /// Represents a test case for inequality.
    /// </summary>
    /// <param name="degreeA">The value of the first compass degree.</param>
    /// <param name="degreeB">The value of the second compass degree.</param>
    [TestCase(10.0, 20.0)]
    [TestCase(double.MaxValue, double.MinValue)]
    [TestCase(double.MinValue, double.MaxValue)]
    public void InequalityPositive(double degreeA, double degreeB)
    {
        var first = new Core.Types.Direction(degreeA);
        var second = new Core.Types.Direction(degreeB);

        Assert.AreNotEqual(first, second);
        Assert.AreNotEqual((object)first, (object)second);
        Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        Assert.IsTrue(first != second);
    }

    /// <summary>
    /// Represents a test case for <see cref="Core.Types.Direction.ToString"/> method.
    /// </summary>
    /// <param name="expected">The value of expected return.</param>
    /// <param name="degree">The value of the compass degree.</param>
    [TestCase("10.0", 10.0)]
    public void ToString(string expected, double degree)
    {
        Assert.AreEqual(expected, new Core.Types.Direction(degree).ToString());
    }
}