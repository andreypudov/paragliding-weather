// <copyright file="Pressure.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    using System;

    /// <summary>
    /// Represents a pressure entity.
    /// </summary>
    public struct Pressure : IPressure, IEquatable<Pressure>
    {
        private int pressure;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pressure"/> struct.
        /// </summary>
        /// <param name="pressure">The value of pressure.</param>
        /// <param name="unit">THe unit of pressure.</param>
        public Pressure(int pressure, Units.Pressure unit)
        {
            switch (unit)
            {
                case Units.Pressure.Pascal:
                default:
                    this.pressure = pressure;
                    break;
            }
        }

        public static bool operator ==(Pressure left, Pressure right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Pressure left, Pressure right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public int GetPressure(Units.Pressure unit)
        {
            return this.pressure;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is Pressure pressure && this.Equals(pressure);
        }

        /// <inheritdoc/>
        public bool Equals(Pressure other)
        {
            return this.pressure == other.pressure;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.pressure.GetHashCode();
        }
    }
}
