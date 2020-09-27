// <copyright file="SkyMeteoWebForecastProvider.cs" company="Andrey Pudov">
// Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Providers.SkyMeteoWeb.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HtmlAgilityPack;
    using Moq;
    using NUnit.Framework;
    using ParaglidingWeather.Core;
    using ParaglidingWeather.Core.Types;
    using ParaglidingWeather.Providers.SkyMeteoWeb;

    /// <summary>
    /// Represents a test class for <see cref="SkyMeteoWeb.SkyMeteoWebForecastProvider"/>.
    /// </summary>
    public class SkyMeteoWebForecastProvider
    {
        /// <summary>
        /// Represents a test case for <see cref="SkyMeteoWeb.SkyMeteoWebForecastProvider.GetForecast"/> method.
        /// </summary>
        [Test]
        public void GetForecast()
        {
            var fetcherMock = new Mock<IFetcher>();
            var document = new HtmlDocument();

            document.LoadHtml(ParaglidingWeather.Providers.SkyMeteoWeb.Test.Resources.TestCase.SkyMeteo_Forecast_NizhnyNovgorod_Valid);
            fetcherMock.Setup(_ => _.Fetch()).Returns(document);

            // the geographic coordinate of Nizhny Novgorod
            var coordintae = new Coordinate(latitude: 56.31, longitude: 44.02);
            var provider = new ParaglidingWeather.Providers.SkyMeteoWeb.SkyMeteoWebForecastProvider(fetcherMock.Object);

            var forecast = provider.GetForecast(coordintae);

            Assert.IsTrue(Enumerable.SequenceEqual(new List<IWeatherReport>(), forecast));
        }
    }
}
