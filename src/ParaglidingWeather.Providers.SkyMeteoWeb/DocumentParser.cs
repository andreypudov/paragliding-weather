// <copyright file="DocumentParser.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb
{
    using System.Collections.Generic;
    using System.Linq;
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
        /// <returns>The list of weather reports.</returns>
        public List<IWeatherReport> Parse()
        {
            var entries = this.document.DocumentNode.SelectNodes("(//table[@id='forecast']//tr)");
            var reports = (List<IWeatherReport>)entries
                .Select(n => new NodeParser(n).Parse())
                .Where(w => w != null)
                .ToList() !;

            return reports;
        }
    }
}
