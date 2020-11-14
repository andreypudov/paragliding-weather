// <copyright file="Cloudiness.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    using System;

    /// <summary>
    /// Represents a speed entity.
    /// </summary>
    public struct Cloudiness : ICloudiness, IEquatable<Cloudiness>
    {
        private readonly double cloudiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cloudiness"/> struct.
        /// </summary>
        /// <param name="cloudiness">The value of cloudiness.</param>
        /// <param name="unit">The unit of cloudiness.</param>
        public Cloudiness(double cloudiness, Units.Cloudiness unit)
        {
            switch (unit)
            {
                case Units.Cloudiness.Relative:
                default:
                    this.cloudiness = cloudiness;
                    break;
            }
        }

        /// <summary>
        /// Determines whether two specified strings have the same value.
        /// </summary>
        /// <param name="left">The first <see cref="Cloudiness"/> to compare, or <c>null</c>.</param>
        /// <param name="right">The second <see cref="Cloudiness"/> to compare, or <c>null</c>.</param>
        /// <returns><c>true</c> if the value of a is the same as the value of b; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Cloudiness left, Cloudiness right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified strings have different values.
        /// </summary>
        /// <param name="left">The first <see cref="Cloudiness"/> to compare, or <c>null</c>.</param>
        /// <param name="right">The second <see cref="Cloudiness"/> to compare, or <c>null</c>.</param>
        /// <returns><c>true</c> if the value of a is different from the value of b; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Cloudiness left, Cloudiness right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public double GetCloudiness(Units.Cloudiness unit)
        {
            return this.cloudiness;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is Cloudiness cloudiness && this.Equals(cloudiness);
        }

        /// <inheritdoc/>
        public bool Equals(Cloudiness other)
        {
            return this.cloudiness == other.cloudiness;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.cloudiness.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.cloudiness:0.0}";
        }
    }
}
