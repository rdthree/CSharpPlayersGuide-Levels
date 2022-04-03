﻿namespace Level31_FountainOfObjects.GameEngine;

internal interface IPlayer
{
    string? Name { get; }
    int ColumnPosition { get; }
    int RowPosition { get; }
    int Moves { get; }
    SenseTypes PlayerInteractions();
}