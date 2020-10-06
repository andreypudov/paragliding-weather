// <copyright file="ITemperature.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    /// <summary>
    /// Represents a temperature entity.
    /// </summary>
    public interface ITemperature
    {
        /// <summary>
        /// Returns the value of temperature in specified units.
        /// </summary>
        /// <param name="unit">The unit system to use.</param>
        /// <returns>Returns the value of temperature.</returns>
        double GetTemperature(Units.Temperature unit);
    }
}
