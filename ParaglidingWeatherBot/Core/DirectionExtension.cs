// <copyright file = "DirectionExtension.cs" company = "Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeatherBot.Core
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Extends <see cref="Direction"/> enumration by adding factory methods.
    /// </summary>
    public static class DirectionExtension
    {
        /// <summary>
        /// Returns the localized abbreviation for the value of direction.
        /// </summary>
        /// <param name="direction">The instance of <see cref="Direction"/> enum.</param>
        /// <param name="culture">An object that represents the culture for which the resource is localized.</param>
        /// <returns>Returns the localized abbreviation name.</returns>
        public static string GetAbbreviation(this Direction direction, CultureInfo culture)
        {
            var abbreviation = Resources.Directions.ResourceManager.GetString(direction.ToString(), culture);

            return abbreviation ?? string.Empty;
        }
    }
}
