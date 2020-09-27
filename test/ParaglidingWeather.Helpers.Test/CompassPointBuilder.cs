// <copyright file="CompassPointBuilder.cs" company="Andrey Pudov">
// Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Helpers.Test
{
    using NUnit.Framework;
    using ParaglidingWeather.Core;

    /// <summary>
    /// Represents a test class for <see cref="ParaglidingWeather.Helpers.CompassPointBuilder"/>.
    /// </summary>
    public class CompassPointBuilder
    {
        /// <summary>
        /// Represents a test case for <see cref="ParaglidingWeather.Helpers.CompassPointBuilder.Get8WindCompassPoint"/> method.
        /// </summary>
        /// <param name="point">The expected value of compass point.</param>
        /// <param name="left">The left boundary of direction in degrees.</param>
        /// <param name="right">The right boundary of direction in degrees.</param>
        [TestCase(CompassPoint.North, 337.5, 22.4)]
        [TestCase(CompassPoint.Northeast, 22.5, 67.4)]
        [TestCase(CompassPoint.East, 67.5, 112.4)]
        [TestCase(CompassPoint.Southeast, 112.5, 157.4)]
        [TestCase(CompassPoint.South, 157.5, 202.4)]
        [TestCase(CompassPoint.Southwest, 202.5, 247.4)]
        [TestCase(CompassPoint.West, 247.5, 292.4)]
        [TestCase(CompassPoint.Northwest, 292.5, 337.4)]
        public void Get8WindCompassPoint(CompassPoint point, decimal left, decimal right)
        {
            if (left > right)
            {
                this.Get8WindCompassPoint(point, left, 360M);
                this.Get8WindCompassPoint(point, 0M, right);

                return;
            }

            while (left <= right)
            {
                Assert.AreEqual(point, ParaglidingWeather.Helpers.CompassPointBuilder.Get8WindCompassPoint((double)left));
                left += 0.1M;
            }
        }

        /// <summary>
        /// Represents a test case for <see cref="ParaglidingWeather.Helpers.CompassPointBuilder.Get16WindCompassPoint"/> method.
        /// </summary>
        /// <param name="point">The expected value of compass point.</param>
        /// <param name="left">The left boundary of direction in degrees.</param>
        /// <param name="right">The right boundary of direction in degrees.</param>
        [TestCase(CompassPoint.North, 348.75, 11.24)]
        [TestCase(CompassPoint.NorthNortheast, 11.25, 33.74)]
        [TestCase(CompassPoint.Northeast, 33.75, 56.24)]
        [TestCase(CompassPoint.EastNortheast, 56.25, 78.74)]
        [TestCase(CompassPoint.East, 78.75, 101.24)]
        [TestCase(CompassPoint.EastSoutheast, 101.25, 123.74)]
        [TestCase(CompassPoint.Southeast, 123.75, 146.24)]
        [TestCase(CompassPoint.SouthSoutheast, 146.25, 168.74)]
        [TestCase(CompassPoint.South, 168.75, 191.24)]
        [TestCase(CompassPoint.SouthSouthwest, 191.25, 213.74)]
        [TestCase(CompassPoint.Southwest, 213.75, 236.24)]
        [TestCase(CompassPoint.WestSouthwest, 236.25, 258.74)]
        [TestCase(CompassPoint.West, 258.75, 281.24)]
        [TestCase(CompassPoint.WestNorthwest, 281.25, 303.74)]
        [TestCase(CompassPoint.Northwest, 303.75, 326.24)]
        [TestCase(CompassPoint.NorthNorthwest, 326.25, 348.74)]
        public void Get16WindCompassPoint(CompassPoint point, decimal left, decimal right)
        {
            if (left > right)
            {
                this.Get16WindCompassPoint(point, left, 360M);
                this.Get16WindCompassPoint(point, 0M, right);

                return;
            }

            while (left <= right)
            {
                Assert.AreEqual(point, ParaglidingWeather.Helpers.CompassPointBuilder.Get16WindCompassPoint((double)left));
                left += 0.01M;
            }
        }

        /// <summary>
        /// Represents a test case for <see cref="ParaglidingWeather.Helpers.CompassPointBuilder.Get32WindCompassPoint"/> method.
        /// </summary>
        /// <param name="point">The expected value of compass point.</param>
        /// <param name="left">The left boundary of direction in degrees.</param>
        /// <param name="right">The right boundary of direction in degrees.</param>
        [TestCase(CompassPoint.North, 354.375, 5.624)]
        [TestCase(CompassPoint.NorthByEast, 5.625, 16.874)]
        [TestCase(CompassPoint.NorthNortheast, 16.875, 28.124)]
        [TestCase(CompassPoint.NortheastByNorth, 28.125, 39.374)]
        [TestCase(CompassPoint.Northeast, 39.375, 50.624)]
        [TestCase(CompassPoint.NortheastByEast, 50.625, 61.874)]
        [TestCase(CompassPoint.EastNortheast, 61.875, 73.124)]
        [TestCase(CompassPoint.EastByNorth, 73.125, 84.374)]
        [TestCase(CompassPoint.East, 84.375, 95.624)]
        [TestCase(CompassPoint.EastBySouth, 95.625, 106.874)]
        [TestCase(CompassPoint.EastSoutheast, 106.875, 118.124)]
        [TestCase(CompassPoint.SoutheastByEast, 118.125, 129.374)]
        [TestCase(CompassPoint.Southeast, 129.375, 140.624)]
        [TestCase(CompassPoint.SoutheastBySouth, 140.625, 151.874)]
        [TestCase(CompassPoint.SouthSoutheast, 151.875, 163.124)]
        [TestCase(CompassPoint.SouthByEast, 163.125, 174.374)]
        [TestCase(CompassPoint.South, 174.375, 185.624)]
        [TestCase(CompassPoint.SouthByWest, 185.625, 196.874)]
        [TestCase(CompassPoint.SouthSouthwest, 196.875, 208.124)]
        [TestCase(CompassPoint.SouthwestBySouth, 208.125, 219.374)]
        [TestCase(CompassPoint.Southwest, 219.375, 230.624)]
        [TestCase(CompassPoint.SouthwestByWest, 230.625, 241.874)]
        [TestCase(CompassPoint.WestSouthwest, 241.875, 253.124)]
        [TestCase(CompassPoint.WestBySouth, 253.125, 264.374)]
        [TestCase(CompassPoint.West, 264.375, 275.624)]
        [TestCase(CompassPoint.WestByNorth, 275.625, 286.874)]
        [TestCase(CompassPoint.WestNorthwest, 286.875, 298.124)]
        [TestCase(CompassPoint.NorthwestByWest, 298.125, 309.374)]
        [TestCase(CompassPoint.Northwest, 309.375, 320.624)]
        [TestCase(CompassPoint.NorthwestByNorth, 320.625, 331.874)]
        [TestCase(CompassPoint.NorthNorthwest, 331.875, 343.124)]
        [TestCase(CompassPoint.NorthByWest, 343.125, 354.374)]
        public void Get32WindCompassPoint(CompassPoint point, decimal left, decimal right)
        {
            if (left > right)
            {
                this.Get32WindCompassPoint(point, left, 360M);
                this.Get32WindCompassPoint(point, 0M, right);

                return;
            }

            while (left <= right)
            {
                Assert.AreEqual(point, ParaglidingWeather.Helpers.CompassPointBuilder.Get32WindCompassPoint((double)left));
                left += 0.001M;
            }
        }
    }
}