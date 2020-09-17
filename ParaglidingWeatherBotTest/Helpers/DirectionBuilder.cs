// <copyright file="DirectionBuilder.cs" company="Andrey Pudov">
// Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeatherBotTest.Helpers
{
    using NUnit.Framework;
    using ParaglidingWeatherBot.Core;

    /// <summary>
    /// Represents a test class for <see cref="ParaglidingWeatherBot.Helpers.DirectionBuilder"/>.
    /// </summary>
    public class DirectionBuilder
    {
        /// <summary>
        /// Represents a test case for <see cref="ParaglidingWeatherBot.Helpers.DirectionBuilder.Get8WindDirection"/> method.
        /// </summary>
        /// <param name="direction">The expected value of direction.</param>
        /// <param name="left">The left boundary of direction in degrees.</param>
        /// <param name="right">The right boundary of direction in degrees.</param>
        [TestCase(Direction.North, 337.5, 22.4)]
        [TestCase(Direction.Northeast, 22.5, 67.4)]
        [TestCase(Direction.East, 67.5, 112.4)]
        [TestCase(Direction.Southeast, 112.5, 157.4)]
        [TestCase(Direction.South, 157.5, 202.4)]
        [TestCase(Direction.Southwest, 202.5, 247.4)]
        [TestCase(Direction.West, 247.5, 292.4)]
        [TestCase(Direction.Northwest, 292.5, 337.4)]
        public void Get8WindDirection(Direction direction, decimal left, decimal right)
        {
            if (left > right)
            {
                this.Get8WindDirection(direction, left, 360M);
                this.Get8WindDirection(direction, 0M, right);

                return;
            }

            while (left <= right)
            {
                Assert.AreEqual(direction, ParaglidingWeatherBot.Helpers.DirectionBuilder.Get8WindDirection((double)left));
                left += 0.1M;
            }
        }

        /// <summary>
        /// Represents a test case for <see cref="ParaglidingWeatherBot.Helpers.DirectionBuilder.Get16WindDirection"/> method.
        /// </summary>
        /// <param name="direction">The expected value of direction.</param>
        /// <param name="left">The left boundary of direction in degrees.</param>
        /// <param name="right">The right boundary of direction in degrees.</param>
        [TestCase(Direction.North, 348.75, 11.24)]
        [TestCase(Direction.NorthNortheast, 11.25, 33.74)]
        [TestCase(Direction.Northeast, 33.75, 56.24)]
        [TestCase(Direction.EastNortheast, 56.25, 78.74)]
        [TestCase(Direction.East, 78.75, 101.24)]
        [TestCase(Direction.EastSoutheast, 101.25, 123.74)]
        [TestCase(Direction.Southeast, 123.75, 146.24)]
        [TestCase(Direction.SouthSoutheast, 146.25, 168.74)]
        [TestCase(Direction.South, 168.75, 191.24)]
        [TestCase(Direction.SouthSouthwest, 191.25, 213.74)]
        [TestCase(Direction.Southwest, 213.75, 236.24)]
        [TestCase(Direction.WestSouthwest, 236.25, 258.74)]
        [TestCase(Direction.West, 258.75, 281.24)]
        [TestCase(Direction.WestNorthwest, 281.25, 303.74)]
        [TestCase(Direction.Northwest, 303.75, 326.24)]
        [TestCase(Direction.NorthNorthwest, 326.25, 348.74)]
        public void Get16WindDirection(Direction direction, decimal left, decimal right)
        {
            if (left > right)
            {
                this.Get16WindDirection(direction, left, 360M);
                this.Get16WindDirection(direction, 0M, right);

                return;
            }

            while (left <= right)
            {
                Assert.AreEqual(direction, ParaglidingWeatherBot.Helpers.DirectionBuilder.Get16WindDirection((double)left));
                left += 0.01M;
            }
        }

        /// <summary>
        /// Represents a test case for <see cref="ParaglidingWeatherBot.Helpers.DirectionBuilder.Get32WindDirection"/> method.
        /// </summary>
        /// <param name="direction">The expected value of direction.</param>
        /// <param name="left">The left boundary of direction in degrees.</param>
        /// <param name="right">The right boundary of direction in degrees.</param>
        [TestCase(Direction.North, 354.375, 5.624)]
        [TestCase(Direction.NorthByEast, 5.625, 16.874)]
        [TestCase(Direction.NorthNortheast, 16.875, 28.124)]
        [TestCase(Direction.NortheastByNorth, 28.125, 39.374)]
        [TestCase(Direction.Northeast, 39.375, 50.624)]
        [TestCase(Direction.NortheastByEast, 50.625, 61.874)]
        [TestCase(Direction.EastNortheast, 61.875, 73.124)]
        [TestCase(Direction.EastByNorth, 73.125, 84.374)]
        [TestCase(Direction.East, 84.375, 95.624)]
        [TestCase(Direction.EastBySouth, 95.625, 106.874)]
        [TestCase(Direction.EastSoutheast, 106.875, 118.124)]
        [TestCase(Direction.SoutheastByEast, 118.125, 129.374)]
        [TestCase(Direction.Southeast, 129.375, 140.624)]
        [TestCase(Direction.SoutheastBySouth, 140.625, 151.874)]
        [TestCase(Direction.SouthSoutheast, 151.875, 163.124)]
        [TestCase(Direction.SouthByEast, 163.125, 174.374)]
        [TestCase(Direction.South, 174.375, 185.624)]
        [TestCase(Direction.SouthByWest, 185.625, 196.874)]
        [TestCase(Direction.SouthSouthwest, 196.875, 208.124)]
        [TestCase(Direction.SouthwestBySouth, 208.125, 219.374)]
        [TestCase(Direction.Southwest, 219.375, 230.624)]
        [TestCase(Direction.SouthwestByWest, 230.625, 241.874)]
        [TestCase(Direction.WestSouthwest, 241.875, 253.124)]
        [TestCase(Direction.WestBySouth, 253.125, 264.374)]
        [TestCase(Direction.West, 264.375, 275.624)]
        [TestCase(Direction.WestByNorth, 275.625, 286.874)]
        [TestCase(Direction.WestNorthwest, 286.875, 298.124)]
        [TestCase(Direction.NorthwestByWest, 298.125, 309.374)]
        [TestCase(Direction.Northwest, 309.375, 320.624)]
        [TestCase(Direction.NorthwestByNorth, 320.625, 331.874)]
        [TestCase(Direction.NorthNorthwest, 331.875, 343.124)]
        [TestCase(Direction.NorthByWest, 343.125, 354.374)]
        public void Get32WindDirection(Direction direction, decimal left, decimal right)
        {
            if (left > right)
            {
                this.Get32WindDirection(direction, left, 360M);
                this.Get32WindDirection(direction, 0M, right);

                return;
            }

            while (left <= right)
            {
                Assert.AreEqual(direction, ParaglidingWeatherBot.Helpers.DirectionBuilder.Get32WindDirection((double)left));
                left += 0.001M;
            }
        }
    }
}