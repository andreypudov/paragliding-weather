// <copyright file="IPressure.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types;

/// <summary>
/// Represents a pressure entity.
/// </summary>
public interface IPressure
{
    /// <summary>
    /// Returns the value of pressure in specified units.
    /// </summary>
    /// <param name="unit">The unit system to use.</param>
    /// <returns>Returns the value of pressure.</returns>
    double GetPressure(Units.Pressure unit);
}