// <copyright file="Coordinate.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types;

using NUnit.Framework;

/// <summary>
/// Represents a test class for <see cref="Core.Types.Coordinate"/>.
/// </summary>
public class Coordinate
{
    /// <summary>
    /// Represents a test case for <see cref="Core.Types.Coordinate.Coordinate(double, double)"/> method.
    /// </summary>
    /// <param name="latitude">The latitude coordinate of the location.</param>
    /// <param name="longitude">The longitude coordinate of the location.</param>
    [TestCase(0.0, 0.0)]
    [TestCase(double.MaxValue, double.MaxValue)]
    [TestCase(double.MinValue, double.MinValue)]
    public void Constructor(double latitude, double longitude)
    {
        var instance = new Core.Types.Coordinate(latitude, longitude);
        Assert.AreEqual(latitude, instance.Latitude);
        Assert.AreEqual(longitude, instance.Longitude);
    }

    /// <summary>
    /// Represents a test case for equality.
    /// </summary>
    /// <param name="latitudeA">The latitude coordinate of the first location.</param>
    /// <param name="longitudeA">The longitude coordinate of the first location.</param>
    /// <param name="latitudeB">The latitude coordinate of the second location.</param>
    /// <param name="longitudeB">The longitude coordinate of the second location.</param>
    [TestCase(10.0, 20.0, 10.0, 20.0)]
    [TestCase(double.MaxValue, double.MinValue, double.MaxValue, double.MinValue)]
    [TestCase(double.MinValue, double.MaxValue, double.MinValue, double.MaxValue)]
    public void EqualityPositive(double latitudeA, double longitudeA, double latitudeB, double longitudeB)
    {
        var first = new Core.Types.Coordinate(latitudeA, longitudeA);
        var second = new Core.Types.Coordinate(latitudeB, longitudeB);

        Assert.AreEqual(first, second);
        Assert.AreEqual((object)first, (object)second);
        Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
        Assert.IsTrue(first == second);
    }

    /// <summary>
    /// Represents a test case for inequality.
    /// </summary>
    /// <param name="latitudeA">The latitude coordinate of the first location.</param>
    /// <param name="longitudeA">The longitude coordinate of the first location.</param>
    /// <param name="latitudeB">The latitude coordinate of the second location.</param>
    /// <param name="longitudeB">The longitude coordinate of the second location.</param>
    [TestCase(10.0, 20.0, 20.0, 10.0)]
    [TestCase(double.MaxValue, double.MinValue, double.MinValue, double.MaxValue)]
    [TestCase(double.MinValue, double.MaxValue, double.MaxValue, double.MinValue)]
    public void InequalityPositive(double latitudeA, double longitudeA, double latitudeB, double longitudeB)
    {
        var first = new Core.Types.Coordinate(latitudeA, longitudeA);
        var second = new Core.Types.Coordinate(latitudeB, longitudeB);

        Assert.AreNotEqual(first, second);
        Assert.AreNotEqual((object)first, (object)second);
        Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        Assert.IsTrue(first != second);
    }

    /// <summary>
    /// Represents a test case for <see cref="Core.Types.Coordinate.ToString"/> method.
    /// </summary>
    /// <param name="expected">The value of expected return.</param>
    /// <param name="latitude">The latitude coordinate of the location.</param>
    /// <param name="longitude">The longitude coordinate of the location.</param>
    [TestCase("[10.0, 10.0]", 10.0, 10.0)]
    public void ToString(string expected, double latitude, double longitude)
    {
        Assert.AreEqual(expected, new Core.Types.Coordinate(latitude, longitude).ToString());
    }
}