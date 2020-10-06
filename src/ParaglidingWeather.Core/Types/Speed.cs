// <copyright file="Speed.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    using System;

    /// <summary>
    /// Represents a speed entity.
    /// </summary>
    public struct Speed : ISpeed, IEquatable<Speed>
    {
        private readonly double speed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Speed"/> struct.
        /// </summary>
        /// <param name="speed">The value of speed.</param>
        /// <param name="unit">The unit of speed.</param>
        public Speed(double speed, Units.Speed unit)
        {
            switch (unit)
            {
                case Units.Speed.MeterPerSecond:
                default:
                    this.speed = speed;
                    break;
            }
        }

        public static bool operator ==(Speed left, Speed right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Speed left, Speed right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public double GetSpeed(Units.Speed unit)
        {
            return this.speed;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is Speed speed && this.Equals(speed);
        }

        /// <inheritdoc/>
        public bool Equals(Speed other)
        {
            return this.speed == other.speed;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.speed.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.speed:0.0}";
        }
    }
}
