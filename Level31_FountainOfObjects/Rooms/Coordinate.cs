using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.Rooms;

internal class Coordinate : ICoordinate
{
    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
        SenseCoords = new SenseTypes[Row, Column];
        SetupRoom();
    }

    public int Row { get; }
    public int Column { get; }
    public SenseTypes[,] SenseCoords { get; }

    public void SetupRoom()
    {
        for (var i = 0; i < Row; i++)
        for (var j = 0; j < Column; j++)
            SenseCoords[i, j] = SenseTypes.Nothing;
    }
}