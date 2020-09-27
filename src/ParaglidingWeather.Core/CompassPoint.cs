// <copyright file = "CompassPoint.cs" company = "Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.Core
{
    /// <summary>
    /// Represents the set of 32 compass points. Each point has an angular range of 11.250 degrees where: middle
    /// azimuth is the horizontal angular direction (from north) of the given compass bearing; minimum is the lower
    /// angular limit of the compass point; and maximum is the upper angular limit of the compass point.
    /// </summary>
    public enum CompassPoint
    {
        /// <summary>
        /// North, N, Tramontana, 354.375°, 0.000°, 5.625°
        /// </summary>
        North,

        /// <summary>
        /// North by east, NbE, Quarto di Tramontana verso Greco, 5.625°, 11.250°, 16.875°
        /// </summary>
        NorthByEast,

        /// <summary>
        /// North-northeast, NNE, Greco-Tramontana, 16.875°, 22.500°, 28.125°
        /// </summary>
        NorthNortheast,

        /// <summary>
        /// Northeast by north, NEbN, Quarto di Greco verso Tramontana, 28.125°, 33.750°, 39.375
        /// </summary>
        NortheastByNorth,

        /// <summary>
        /// Northeast, NE, Greco, 39.375°, 45.000°, 50.625°
        /// </summary>
        Northeast,

        /// <summary>
        /// Northeast by east, NEbE, Quarto di Greco verso Levante, 50.625°, 56.250°, 61.875°
        /// </summary>
        NortheastByEast,

        /// <summary>
        /// East-northeast, ENE, Greco-Levante, 61.875°, 67.500°, 73.125°
        /// </summary>
        EastNortheast,

        /// <summary>
        /// East by north, EbN, Quarto di Levante verso Greco, 73.125°, 78.750°, 84.375°
        /// </summary>
        EastByNorth,

        /// <summary>
        /// East, E, Levante, 84.375°, 90.000°, 95.625°
        /// </summary>
        East,

        /// <summary>
        /// East by south, EbS, Quarto di Levante verso Scirocco, 95.625°, 101.250°, 106.875°
        /// </summary>
        EastBySouth,

        /// <summary>
        /// East-southeast, ESE, Levante-Scirocco, 106.875°, 112.500°, 118.125°
        /// </summary>
        EastSoutheast,

        /// <summary>
        /// Southeast by east, SEbE, Quarto di Scirocco verso Levante, 118.125°, 123.750°, 129.375°
        /// </summary>
        SoutheastByEast,

        /// <summary>
        /// Southeast, SE, Scirocco, 129.375°, 135.000°, 140.625°
        /// </summary>
        Southeast,

        /// <summary>
        /// Southeast by south, SEbS, Quarto di Scirocco verso Ostro, 140.625°, 146.250°, 151.875°
        /// </summary>
        SoutheastBySouth,

        /// <summary>
        /// South-southeast, SSE, Ostro-Scirocco, 151.875°, 157.500°, 163.125°
        /// </summary>
        SouthSoutheast,

        /// <summary>
        /// South by east, SbE, Quarto di Ostro verso Scirocco, 163.125°, 168.750°, 174.375°
        /// </summary>
        SouthByEast,

        /// <summary>
        /// South, S, Ostro, 174.375°, 180.000°, 185.625°
        /// </summary>
        South,

        /// <summary>
        /// South by west, SbW, Quarto di Ostro verso Libeccio, 185.625°, 191.250°, 196.875°
        /// </summary>
        SouthByWest,

        /// <summary>
        /// South-southwest, SSW, Ostro-Libeccio, 196.875°, 202.500°, 208.125°
        /// </summary>
        SouthSouthwest,

        /// <summary>
        /// Southwest by south, SWbS, Quarto di Libeccio verso Ostro, 208.125°, 213.750°, 219.375°
        /// </summary>
        SouthwestBySouth,

        /// <summary>
        /// Southwest, SW, Libeccio, 219.375°, 225.000°, 230.625°
        /// </summary>
        Southwest,

        /// <summary>
        /// Southwest by west, SWbW, Quarto di Libeccio verso Ponente, 230.625°, 236.250°, 241.875°
        /// </summary>
        SouthwestByWest,

        /// <summary>
        /// West-southwest, WSW, Ponente-Libeccio, 241.875°, 247.500°, 253.125°
        /// </summary>
        WestSouthwest,

        /// <summary>
        /// West by south, WbS, Quarto di Ponente verso Libeccio, 253.125°, 258.750°, 264.375°
        /// </summary>
        WestBySouth,

        /// <summary>
        /// West, W, Ponente, 264.375°, 270.000°, 275.625°
        /// </summary>
        West,

        /// <summary>
        /// West by north, WbN, Quarto di Ponente verso Maestro, 275.625°, 281.250°, 286.875°
        /// </summary>
        WestByNorth,

        /// <summary>
        /// West-northwest, WNW, Maestro-Ponente, 286.875°, 292.500°, 298.125°
        /// </summary>
        WestNorthwest,

        /// <summary>
        /// Northwest by west, NWbW, Quarto di Maestro verso Ponente, 298.125°, 303.750°, 309.375°
        /// </summary>
        NorthwestByWest,

        /// <summary>
        /// Northwest, NW, Maestro, 309.375°, 315.000°, 320.625°
        /// </summary>
        Northwest,

        /// <summary>
        /// Northwest by north, NWbN, Quarto di Maestro verso Tramontana, 320.625°, 326.250°, 331.875°
        /// </summary>
        NorthwestByNorth,

        /// <summary>
        /// North-northwest, NNW, Maestro-Tramontana, 331.875°, 337.500°, 343.125°
        /// </summary>
        NorthNorthwest,

        /// <summary>
        /// North by west, NbW, Quarto di Tramontana verso Maestro, 343.125°, 348.750°, 354.375°
        /// </summary>
        NorthByWest,
    }
}