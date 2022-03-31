﻿namespace Level31_FountainOfObjects;

internal interface IMainRoom
{
    int Rows { get; }
    int Columns { get; }

    record Coordinate(int Row, int Column);
    
}

internal interface ISubRoom : IMainRoom
{
    SenseTypesCoordinates[,]? SenseCoords { get; }
}