// <copyright file="Precipitation.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    using System;

    /// <summary>
    /// Represents a speed entity.
    /// </summary>
    public struct Precipitation : IPrecipitation, IEquatable<Precipitation>
    {
        private readonly double precipitation;

        /// <summary>
        /// Initializes a new instance of the <see cref="Precipitation"/> struct.
        /// </summary>
        /// <param name="precipitation">The value of precipitation.</param>
        /// <param name="unit">The unit of precipitation.</param>
        public Precipitation(double precipitation, Units.Precipitation unit)
        {
            switch (unit)
            {
                case Units.Precipitation.Millimetres:
                default:
                    this.precipitation = precipitation;
                    break;
            }
        }

        /// <summary>
        /// Determines whether two specified strings have the same value.
        /// </summary>
        /// <param name="left">The first <see cref="Precipitation"/> to compare, or <c>null</c>.</param>
        /// <param name="right">The second <see cref="Precipitation"/> to compare, or <c>null</c>.</param>
        /// <returns><c>true</c> if the value of a is the same as the value of b; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Precipitation left, Precipitation right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified strings have different values.
        /// </summary>
        /// <param name="left">The first <see cref="Precipitation"/> to compare, or <c>null</c>.</param>
        /// <param name="right">The second <see cref="Precipitation"/> to compare, or <c>null</c>.</param>
        /// <returns><c>true</c> if the value of a is different from the value of b; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Precipitation left, Precipitation right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public double GetPrecipitation(Units.Precipitation unit)
        {
            return this.precipitation;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is Precipitation speed && this.Equals(speed);
        }

        /// <inheritdoc/>
        public bool Equals(Precipitation other)
        {
            return this.precipitation == other.precipitation;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.precipitation.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.precipitation:0.0}";
        }
    }
}
