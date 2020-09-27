// <copyright file = "CompassPointBuilder.cs" company = "Andrey Pudov" >
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Helpers
{
    using System;
    using ParaglidingWeather.Core;

    /// <summary>
    /// Provides a set of methods to create <see cref="CompassPoint" />.
    /// </summary>
    public static class CompassPointBuilder
    {
        /// <summary>
        /// Returns the 8-wind compase rose direction for a given degree.
        /// </summary>
        /// <param name="degree">The value of the compass degree.</param>
        /// <returns>The compass point for a give degree.</returns>
        public static CompassPoint Get8WindCompassPoint(double degree)
        {
            var directions = new CompassPoint[]
            {
                CompassPoint.North, CompassPoint.Northeast,
                CompassPoint.East,  CompassPoint.Southeast,
                CompassPoint.South, CompassPoint.Southwest,
                CompassPoint.West,  CompassPoint.Northwest,
                CompassPoint.North,
            };

            return directions[(int)Math.Round(degree / (360.0 / (directions.Length - 1)), MidpointRounding.AwayFromZero)];
        }

        /// <summary>
        /// Returns the 16-wind compase rose direction for a given degree.
        /// </summary>
        /// <param name="degree">The value of the compass degree.</param>
        /// <returns>The compass point for a give degree.</returns>
        public static CompassPoint Get16WindCompassPoint(double degree)
        {
            var directions = new CompassPoint[]
            {
                CompassPoint.North, CompassPoint.NorthNortheast, CompassPoint.Northeast, CompassPoint.EastNortheast,
                CompassPoint.East,  CompassPoint.EastSoutheast,  CompassPoint.Southeast, CompassPoint.SouthSoutheast,
                CompassPoint.South, CompassPoint.SouthSouthwest, CompassPoint.Southwest, CompassPoint.WestSouthwest,
                CompassPoint.West,  CompassPoint.WestNorthwest,  CompassPoint.Northwest, CompassPoint.NorthNorthwest,
                CompassPoint.North,
            };

            return directions[(int)Math.Round(degree / (360.0 / (directions.Length - 1)), MidpointRounding.AwayFromZero)];
        }

        /// <summary>
        /// Returns the 32-wind compase rose direction for a given degree.
        /// </summary>
        /// <param name="degree">The value of the compass degree.</param>
        /// <returns>The compass point for a give degree.</returns>
        public static CompassPoint Get32WindCompassPoint(double degree)
        {
            var directions = new CompassPoint[]
            {
                CompassPoint.North,     CompassPoint.NorthByEast,      CompassPoint.NorthNortheast, CompassPoint.NortheastByNorth,
                CompassPoint.Northeast, CompassPoint.NortheastByEast,  CompassPoint.EastNortheast,  CompassPoint.EastByNorth,
                CompassPoint.East,      CompassPoint.EastBySouth,      CompassPoint.EastSoutheast,  CompassPoint.SoutheastByEast,
                CompassPoint.Southeast, CompassPoint.SoutheastBySouth, CompassPoint.SouthSoutheast, CompassPoint.SouthByEast,
                CompassPoint.South,     CompassPoint.SouthByWest,      CompassPoint.SouthSouthwest, CompassPoint.SouthwestBySouth,
                CompassPoint.Southwest, CompassPoint.SouthwestByWest,  CompassPoint.WestSouthwest,  CompassPoint.WestBySouth,
                CompassPoint.West,      CompassPoint.WestByNorth,      CompassPoint.WestNorthwest,  CompassPoint.NorthwestByWest,
                CompassPoint.Northwest, CompassPoint.NorthwestByNorth, CompassPoint.NorthNorthwest, CompassPoint.NorthByWest,
                CompassPoint.North,
            };

            return directions[(int)Math.Round(degree / (360.0 / (directions.Length - 1)), MidpointRounding.AwayFromZero)];
        }
    }
}
