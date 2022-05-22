// <copyright file = "Coordinate.cs" company = "Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types;

/// <summary>
/// Represents a geographic coordinate.
/// </summary>
public struct Coordinate : ICoordinate, IEquatable<Coordinate>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Coordinate"/> struct.
    /// </summary>
    /// <param name="latitude">The latitude coordinate of the location.</param>
    /// <param name="longitude">The longitude coordinate of the location.</param>
    public Coordinate(double latitude, double longitude)
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    /// <inheritdoc/>
    public double Latitude { get; }

    /// <inheritdoc/>
    public double Longitude { get; }

    /// <summary>
    /// Determines whether two specified strings have the same value.
    /// </summary>
    /// <param name="left">The first <see cref="Coordinate"/> to compare, or <c>null</c>.</param>
    /// <param name="right">The second <see cref="Coordinate"/> to compare, or <c>null</c>.</param>
    /// <returns><c>true</c> if the value of a is the same as the value of b; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Coordinate left, Coordinate right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two specified strings have different values.
    /// </summary>
    /// <param name="left">The first <see cref="Coordinate"/> to compare, or <c>null</c>.</param>
    /// <param name="right">The second <see cref="Coordinate"/> to compare, or <c>null</c>.</param>
    /// <returns><c>true</c> if the value of a is different from the value of b; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Coordinate left, Coordinate right)
    {
        return !(left == right);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is Coordinate coordinate && this.Equals(coordinate);
    }

    /// <inheritdoc/>
    public bool Equals(Coordinate other)
    {
        return this.Latitude == other.Latitude &&
               this.Longitude == other.Longitude;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Latitude, this.Longitude);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[{this.Latitude:0.0}, {this.Longitude:0.0}]";
    }
}