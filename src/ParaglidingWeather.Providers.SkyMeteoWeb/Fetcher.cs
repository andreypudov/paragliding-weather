// <copyright file="Fetcher.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb;

using HtmlAgilityPack;

/// <summary>
/// Provides a methods to fetch content from the web resource.
/// </summary>
public sealed class Fetcher : IFetcher
{
    private readonly Uri uri;

    /// <summary>
    /// Initializes a new instance of the <see cref="Fetcher"/> class.
    /// </summary>
    /// <param name="uri">The address of the web page.</param>
    public Fetcher(Uri uri)
    {
        this.uri = uri;
    }

    /// <summary>
    /// Returns the web page from the specified address.
    /// </summary>
    /// <returns>The web page document.</returns>
    public HtmlDocument Fetch()
    {
        var web = new HtmlWeb();

        return web.Load(this.uri);
    }

    /// <summary>
    /// Returns the web page from the specified address.
    /// </summary>
    /// <returns>The web page document.</returns>
    public Task<HtmlDocument> FetchAsync()
    {
        var web = new HtmlWeb();

        return web.LoadFromWebAsync(this.uri.AbsolutePath);
    }
}