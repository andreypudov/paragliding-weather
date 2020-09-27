// <copyright file = "CompassPointExtension.cs" company = "Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core
{
    using System.Globalization;

    /// <summary>
    /// Extends <see cref="CompassPoint"/> enumration by adding factory methods.
    /// </summary>
    public static class CompassPointExtension
    {
        /// <summary>
        /// Returns the localized abbreviation for the value of direction.
        /// </summary>
        /// <param name="point">The instance of <see cref="CompassPoint"/> enum.</param>
        /// <param name="culture">An object that represents the culture for which the resource is localized.</param>
        /// <returns>Returns the localized abbreviation name.</returns>
        public static string GetAbbreviation(this CompassPoint point, CultureInfo culture)
        {
            var abbreviation = Resources.CompassPoints.ResourceManager.GetString(point.ToString(), culture);

            return abbreviation ?? string.Empty;
        }
    }
}
