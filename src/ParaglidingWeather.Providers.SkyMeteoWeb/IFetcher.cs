// <copyright file="IFetcher.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb;

using HtmlAgilityPack;

/// <summary>
/// Provides a methods to fetch content from the web resource.
/// </summary>
public interface IFetcher
{
    /// <summary>
    /// Returns the web page from the specified address.
    /// </summary>
    /// <returns>The web page document.</returns>
    HtmlDocument Fetch();

    /// <summary>
    /// Returns the web page from the specified address.
    /// </summary>
    /// <returns>The web page document.</returns>
    Task<HtmlDocument> FetchAsync();
}