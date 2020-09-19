// <copyright file = "Coordinate.cs" company = "Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core
{
    using System;

    /// <summary>
    /// Represents a geographic coordinate.
    /// </summary>
    public struct Coordinate : IEquatable<Coordinate>
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

        /// <summary>
        /// Gets the latitude value of the geographic coordinate.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// Gets the longitude value of the geographic coordinate.
        /// </summary>
        public double Longitude { get; }

        public static bool operator ==(Coordinate left, Coordinate right)
        {
            return left.Equals(right);
        }

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
    }
}
