// <copyright file = "DirectionBuilder.cs" company = "Andrey Pudov" >
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeatherBot.Helpers
{
    using System;
    using ParaglidingWeatherBot.Core;

    /// <summary>
    /// Provides a set of methods to create <see cref="Direction" />.
    /// </summary>
    public static class DirectionBuilder
    {
        /// <summary>
        /// Returns the 8-wind compase rose direction for a given degree.
        /// </summary>
        /// <param name="degree">The value of the compass degree.</param>
        /// <returns>The direction for a give degree.</returns>
        public static Direction Get8WindDirection(double degree)
        {
            var directions = new Direction[]
            {
                Direction.North, Direction.Northeast,
                Direction.East, Direction.Southeast,
                Direction.South, Direction.Southwest,
                Direction.West, Direction.Northwest,
                Direction.North,
            };

            return directions[(int)Math.Round(degree / (360.0 / (directions.Length - 1)), MidpointRounding.AwayFromZero)];
        }

        /// <summary>
        /// Returns the 16-wind compase rose direction for a given degree.
        /// </summary>
        /// <param name="degree">The value of the compass degree.</param>
        /// <returns>The direction for a give degree.</returns>
        public static Direction Get16WindDirection(double degree)
        {
            var directions = new Direction[]
            {
                Direction.North, Direction.NorthNortheast, Direction.Northeast, Direction.EastNortheast,
                Direction.East, Direction.EastSoutheast, Direction.Southeast, Direction.SouthSoutheast,
                Direction.South, Direction.SouthSouthwest, Direction.Southwest, Direction.WestSouthwest,
                Direction.West, Direction.WestNorthwest, Direction.Northwest, Direction.NorthNorthwest,
                Direction.North,
            };

            return directions[(int)Math.Round(degree / (360.0 / (directions.Length - 1)), MidpointRounding.AwayFromZero)];
        }

        /// <summary>
        /// Returns the 32-wind compase rose direction for a given degree.
        /// </summary>
        /// <param name="degree">The value of the compass degree.</param>
        /// <returns>The direction for a give degree.</returns>
        public static Direction Get32WindDirection(double degree)
        {
            var directions = new Direction[]
            {
                Direction.North, Direction.NorthByEast, Direction.NorthNortheast, Direction.NortheastByNorth,
                Direction.Northeast, Direction.NortheastByEast, Direction.EastNortheast, Direction.EastByNorth,
                Direction.East, Direction.EastBySouth, Direction.EastSoutheast, Direction.SoutheastByEast,
                Direction.Southeast, Direction.SoutheastBySouth, Direction.SouthSoutheast, Direction.SouthByEast,
                Direction.South, Direction.SouthByWest, Direction.SouthSouthwest, Direction.SouthwestBySouth,
                Direction.Southwest, Direction.SouthwestByWest, Direction.WestSouthwest, Direction.WestBySouth,
                Direction.West, Direction.WestByNorth, Direction.WestNorthwest, Direction.NorthwestByWest,
                Direction.Northwest, Direction.NorthwestByNorth, Direction.NorthNorthwest, Direction.NorthByWest,
                Direction.North,
            };

            return directions[(int)Math.Round(degree / (360.0 / (directions.Length - 1)), MidpointRounding.AwayFromZero)];
        }
    }
}
