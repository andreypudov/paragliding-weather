// <copyright file="IWind.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types
{
    /// <summary>
    /// Represents a wind entity.
    /// </summary>
    public interface IWind
    {
        /// <summary>
        /// Gets the value of wind speed.
        /// </summary>
        ISpeed Speed { get; }

        /// <summary>
        /// Gets the value of wind direction.
        /// </summary>
        IDirection Direction { get; }

        /// <summary>
        /// Gets the value of wind gust.
        /// </summary>
        ISpeed Gust { get; }
    }
}
