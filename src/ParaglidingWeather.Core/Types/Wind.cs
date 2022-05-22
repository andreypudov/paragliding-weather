// <copyright file = "Wind.cs" company = "Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types;

/// <summary>
/// Represents a wind entity.
/// </summary>
public struct Wind : IWind, IEquatable<Wind>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Wind"/> struct.
    /// </summary>
    /// <param name="speed">The value of wind speend.</param>
    /// <param name="direction">The value of wind direction.</param>
    /// <param name="gust">The value of wind gust.</param>
    public Wind(ISpeed speed, IDirection direction, ISpeed gust)
    {
        this.Speed = speed;
        this.Direction = direction;
        this.Gust = gust;
    }

    /// <inheritdoc/>
    public ISpeed Speed { get; }

    /// <inheritdoc/>
    public IDirection Direction { get; }

    /// <inheritdoc/>
    public ISpeed Gust { get; }

    /// <summary>
    /// Determines whether two specified strings have the same value.
    /// </summary>
    /// <param name="left">The first <see cref="Wind"/> to compare, or <c>null</c>.</param>
    /// <param name="right">The second <see cref="Wind"/> to compare, or <c>null</c>.</param>
    /// <returns><c>true</c> if the value of a is the same as the value of b; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Wind left, Wind right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two specified strings have different values.
    /// </summary>
    /// <param name="left">The first <see cref="Wind"/> to compare, or <c>null</c>.</param>
    /// <param name="right">The second <see cref="Wind"/> to compare, or <c>null</c>.</param>
    /// <returns><c>true</c> if the value of a is different from the value of b; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Wind left, Wind right)
    {
        return !(left == right);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is Wind wind && this.Equals(wind);
    }

    /// <inheritdoc/>
    public bool Equals(Wind other)
    {
        return this.Speed.Equals(other.Speed) &&
               this.Direction.Equals(other.Direction) &&
               this.Gust.Equals(other.Gust);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Speed, this.Direction, this.Gust);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[{this.Speed}, {this.Direction}, {this.Gust}]";
    }
}