﻿using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal interface IMainRoom
{
    int Rows { get; }
    int Columns { get; }
    record Coordinate(int Row, int Column);
    SenseTypes[,] SenseCoords { get; }
    
}