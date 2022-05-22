// <copyright file="SkyMeteoForecastProvider.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteo;

using ParaglidingWeather.Core;
using ParaglidingWeather.Core.Types;

/// <summary>
/// Provides a weather forecast using SkyMeteo public API.
/// </summary>
public class SkyMeteoForecastProvider : IForecastProvider
{
    /// <inheritdoc/>
    public List<IWeatherReport> GetForecast(Coordinate coordinate)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<List<IWeatherReport>> GetForecastAsync(Coordinate coordinate)
    {
        throw new System.NotImplementedException();
    }
}