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
        private readonly int humidity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Humidity"/> struct.
        /// </summary>
        /// <param name="humidity">The value of humidity.</param>
        /// <param name="unit">The unit of pressure.</param>
        public Humidity(int humidity, Units.Humidity unit)
        {
            switch (unit)
            {
                case Units.Humidity.Relative:
                default:
                    this.humidity = humidity;
                    break;
            }
        }

        public static bool operator ==(Humidity left, Humidity right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Humidity left, Humidity right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public int GetHumidity(Units.Humidity unit)
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
            return $"{this.humidity}";
        }
    }
}
