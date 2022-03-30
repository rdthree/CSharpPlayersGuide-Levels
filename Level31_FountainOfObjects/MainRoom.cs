﻿namespace Level31_FountainOfObjects;

internal class MainRoom : IMainRoom
{
    public MainRoom(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        SenseCoords = new SenseTypes[Rows, Columns];
        SetupRoom();
    }

    public int Rows { get; }
    public int Columns { get; }

    private SenseTypes[,] SenseCoords { get; }

    private void SetupRoom()
    {
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
                SenseCoords[i, j] = SenseTypes.Nothing;
        }
    }
}