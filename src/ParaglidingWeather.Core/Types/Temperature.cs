// <copyright file="Temperature.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types;

/// <summary>
/// Represents a temperature entity.
/// </summary>
public struct Temperature : ITemperature, IEquatable<Temperature>
{
    private readonly double temperature;

    /// <summary>
    /// Initializes a new instance of the <see cref="Temperature"/> struct.
    /// </summary>
    /// <param name="temperature">The value of temperature.</param>
    /// <param name="unit">The unit of temperature.</param>
    public Temperature(double temperature, Units.Temperature unit)
    {
        switch (unit)
        {
            case Units.Temperature.Celsius:
            default:
                this.temperature = temperature;
                break;
        }
    }

    /// <summary>
    /// Determines whether two specified strings have the same value.
    /// </summary>
    /// <param name="left">The first <see cref="Temperature"/> to compare, or <c>null</c>.</param>
    /// <param name="right">The second <see cref="Temperature"/> to compare, or <c>null</c>.</param>
    /// <returns><c>true</c> if the value of a is the same as the value of b; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Temperature left, Temperature right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two specified strings have different values.
    /// </summary>
    /// <param name="left">The first <see cref="Temperature"/> to compare, or <c>null</c>.</param>
    /// <param name="right">The second <see cref="Temperature"/> to compare, or <c>null</c>.</param>
    /// <returns><c>true</c> if the value of a is different from the value of b; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Temperature left, Temperature right)
    {
        return !(left == right);
    }

    /// <inheritdoc/>
    public double GetTemperature(Units.Temperature unit)
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

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"{this.temperature:0.0}";
    }
}