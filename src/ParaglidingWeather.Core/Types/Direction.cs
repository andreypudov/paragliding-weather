// <copyright file = "Direction.cs" company = "Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    using System;

    /// <summary>
    /// Represents a compass direction.
    /// </summary>
    public struct Direction : IDirection, IEquatable<Direction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Direction"/> struct.
        /// </summary>
        /// <param name="degree">The value of the compass degree.</param>
        public Direction(double degree)
        {
            this.Degree = degree;
        }

        /// <inheritdoc/>
        public double Degree { get; }

        public static bool operator ==(Direction left, Direction right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Direction left, Direction right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is Direction direction && this.Equals(direction);
        }

        /// <inheritdoc/>
        public bool Equals(Direction other)
        {
            return this.Degree == other.Degree;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Degree.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Degree:0.0}";
        }
    }
}
