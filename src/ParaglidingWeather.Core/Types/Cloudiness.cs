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
        private int cloudiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cloudiness"/> struct.
        /// </summary>
        /// <param name="cloudiness">The value of cloudiness.</param>
        /// <param name="unit">The unit of cloudiness.</param>
        public Cloudiness(int cloudiness, Units.Cloudiness unit)
        {
            switch (unit)
            {
                case Units.Cloudiness.Relative:
                default:
                    this.cloudiness = cloudiness;
                    break;
            }
        }

        public static bool operator ==(Cloudiness left, Cloudiness right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Cloudiness left, Cloudiness right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public int GetCloudiness(Units.Cloudiness unit)
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
    }
}
