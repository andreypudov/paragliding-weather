// <copyright file="Direction.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core.Test.Types
{
    using NUnit.Framework;

    /// <summary>
    /// Represents a test class for <see cref="Core.Types.Direction"/>.
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// Represents a test case for <see cref="Core.Types.Direction.Direction(double)"/> method.
        /// </summary>
        /// <param name="degree">The value of the compass degree.</param>
        [TestCase(10.0)]
        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        public void Constructor(double degree)
        {
            var instance = new Core.Types.Direction(degree);
            Assert.AreEqual(degree, instance.Degree);
        }
    }
}
