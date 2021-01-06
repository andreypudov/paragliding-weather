// <copyright file="StringUtilities.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Bot.Helpers
{
    using System;
    using System.Net;
    using System.Text;
    using HtmlAgilityPack;

    /// <summary>
    /// Provides a set of utility methods.
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        /// Returns the string with replaced sequences.
        /// </summary>
        /// <param name="builder">The instance of the string builder.</param>
        /// <returns>The string with escaped sequences.</returns>
        public static string EscapeMarkdown(StringBuilder builder)
        {
            return builder
                .ToString()
                .Replace("_", "\\_", StringComparison.InvariantCulture)
                .Replace("<", "\\<", StringComparison.InvariantCulture)
                .Replace(">", "\\>", StringComparison.InvariantCulture)
                .Replace("+", "\\+", StringComparison.InvariantCulture)
                .Replace("-", "\\-", StringComparison.InvariantCulture)
                .Replace(".", "\\.", StringComparison.InvariantCulture)
                .Replace("|", "\\|", StringComparison.InvariantCulture)
                .Replace("(", "\\(", StringComparison.InvariantCulture)
                .Replace(")", "\\)", StringComparison.InvariantCulture)
                .Replace("=", "\\=", StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Returns the value of the inner text.
        /// </summary>
        /// <param name="node">The HTML node to use.</param>
        /// <returns>Th value of the inner text.</returns>
        public static string GetInnerTextValue(HtmlNode node)
        {
            return WebUtility.HtmlDecode(node.InnerText.Trim());
        }
    }
}
