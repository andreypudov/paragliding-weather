// <copyright file = "IDirection.cs" company = "Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    /// <summary>
    /// Represents a compass direction.
    /// </summary>
    public interface IDirection
    {
        /// <summary>
        /// Gets the compass direction in degrees.
        /// </summary>
        double Degree { get; }
    }
}
