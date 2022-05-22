// <copyright file = "ICoordinate.cs" company = "Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Types;

/// <summary>
/// Represents a geographic coordinate.
/// </summary>
public interface ICoordinate
{
    /// <summary>
    /// Gets the latitude value of the geographic coordinate.
    /// </summary>
    double Latitude { get; }

    /// <summary>
    /// Gets the longitude value of the geographic coordinate.
    /// </summary>
    double Longitude { get; }
}