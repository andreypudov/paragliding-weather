// <copyright file="Humidity.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    using System;

    /// <summary>
    /// Represents a humidity entity.
    /// </summary>
    public struct Humidity : IHumidity, IEquatable<Humidity>
    {
        private readonly double humidity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Humidity"/> struct.
        /// </summary>
        /// <param name="humidity">The value of humidity.</param>
        /// <param name="unit">The unit of pressure.</param>
        public Humidity(double humidity, Units.Humidity unit)
        {
            switch (unit)
            {
                case Units.Humidity.Relative:
                default:
                    this.humidity = humidity;
                    break;
            }
        }

        /// <summary>
        /// Determines whether two specified strings have the same value.
        /// </summary>
        /// <param name="left">The first <see cref="Humidity"/> to compare, or <c>null</c>.</param>
        /// <param name="right">The second <see cref="Humidity"/> to compare, or <c>null</c>.</param>
        /// <returns><c>true</c> if the value of a is the same as the value of b; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Humidity left, Humidity right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified strings have different values.
        /// </summary>
        /// <param name="left">The first <see cref="Humidity"/> to compare, or <c>null</c>.</param>
        /// <param name="right">The second <see cref="Humidity"/> to compare, or <c>null</c>.</param>
        /// <returns><c>true</c> if the value of a is different from the value of b; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Humidity left, Humidity right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public double GetHumidity(Units.Humidity unit)
        {
            return this.humidity;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is Humidity humidity && this.Equals(humidity);
        }

        /// <inheritdoc/>
        public bool Equals(Humidity other)
        {
            return this.humidity == other.humidity;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.humidity.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.humidity:0.0}";
        }
    }
}
