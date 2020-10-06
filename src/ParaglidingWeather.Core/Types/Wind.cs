// <copyright file = "Wind.cs" company = "Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    using System;

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
        public Wind(ISpeed speed, Direction direction, ISpeed gust)
        {
            this.Speed = speed;
            this.Direction = direction;
            this.Gust = gust;
        }

        /// <inheritdoc/>
        public ISpeed Speed { get; }

        /// <inheritdoc/>
        public Direction Direction { get; }

        /// <inheritdoc/>
        public ISpeed Gust { get; }

        public static bool operator ==(Wind left, Wind right)
        {
            return left.Equals(right);
        }

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
            return this.Speed == other.Speed &&
                   this.Direction == other.Direction &&
                   this.Gust == other.Gust;
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
}
