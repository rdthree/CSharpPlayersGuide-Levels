using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.Rooms;

internal interface IMainRoom
{
    /// <summary>
    /// Basic record to locate items on the game board
    /// </summary>
    /// <param name="Row"></param>
    /// <param name="Column"></param>
    record Coordinate(int Row, int Column);

    SenseTypes[,] SenseCoords { get; }
}