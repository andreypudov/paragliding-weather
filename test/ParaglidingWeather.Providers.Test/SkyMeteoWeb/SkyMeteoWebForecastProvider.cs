// <copyright file="SkyMeteoWebForecastProvider.cs" company="Andrey Pudov">
// Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.Test.SkyMeteoWeb
{
    using NUnit.Framework;
    using ParaglidingWeather.Core.Types;

    /// <summary>
    /// Represents a test class for <see cref="ParaglidingWeather.Providers.SkyMeteoWeb.SkyMeteoWebForecastProvider"/>.
    /// </summary>
    public class SkyMeteoWebForecastProvider
    {
        /// <summary>
        /// Represents a test case for <see cref="ParaglidingWeather.Providers.SkyMeteoWeb.SkyMeteoWebForecastProvider.GetForecast"/> method.
        /// </summary>
        [Test]
        public void GetForecast()
        {
            var coordintae = new Coordinate(latitude: 56.31, longitude: 44.02);
            var provider = new ParaglidingWeather.Providers.SkyMeteoWeb.SkyMeteoWebForecastProvider();

            var result = provider.GetForecast(coordintae);

            Assert.AreEqual(string.Empty, result);
        }
    }
}
