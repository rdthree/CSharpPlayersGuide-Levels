﻿namespace Level31_FountainOfObjects.Rooms;

internal interface ICoordinate
{
    /// <summary>
    /// Basic record to locate items on the game board
    /// </summary>
    /// <param name="Row"></param>
    /// <param name="Column"></param>
    record Coordinate(int Row, int Column);
}