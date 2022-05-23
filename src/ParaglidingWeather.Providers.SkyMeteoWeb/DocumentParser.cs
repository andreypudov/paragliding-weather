// <copyright file="DocumentParser.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb;

using HtmlAgilityPack;
using ParaglidingWeather.Core;

/// <summary>
/// Provides methods to parse HTML document.
/// </summary>
public class DocumentParser
{
    private readonly HtmlDocument document;

    /// <summary>
    /// Initializes a new instance of the <see cref="DocumentParser"/> class.
    /// </summary>
    /// <param name="document">The HTML document to parse.</param>
    public DocumentParser(HtmlDocument document)
    {
        this.document = document;
    }

    /// <summary>
    /// Parses the document and returns weather information.
    /// </summary>
    /// <param name="date">The date of the forecast.</param>
    /// <returns>The list of weather reports.</returns>
    public List<IWeatherReport> Parse(DateTime date)
    {
        var entries = this.document.DocumentNode.SelectNodes("(//table[@id='forecast']//tr)");
        var reports = (List<IWeatherReport>)entries
            .Select(node => new NodeParser(node).Parse(ref date))
            .Where(report => report != null)
            .ToList()!;

        return reports;
    }
}