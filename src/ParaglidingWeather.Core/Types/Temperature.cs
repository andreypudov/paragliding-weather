// <copyright file="Temperature.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    using System;

    /// <summary>
    /// Represents a temperature entity.
    /// </summary>
    public struct Temperature : ITemperature, IEquatable<Temperature>
    {
        private int temperature;

        /// <summary>
        /// Initializes a new instance of the <see cref="Temperature"/> struct.
        /// </summary>
        /// <param name="temperature">The value of temperature.</param>
        /// <param name="unit">THe unit of temperature.</param>
        public Temperature(int temperature, Units.Temperature unit)
        {
            switch (unit)
            {
                case Units.Temperature.Celsius:
                default:
                    this.temperature = temperature;
                    break;
            }
        }

        public static bool operator ==(Temperature left, Temperature right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Temperature left, Temperature right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public int GetTemperature(Units.Temperature unit)
        {
            return this.temperature;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is Temperature temperature && this.Equals(temperature);
        }

        /// <inheritdoc/>
        public bool Equals(Temperature other)
        {
            return this.temperature == other.temperature;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.temperature.GetHashCode();
        }
    }
}
