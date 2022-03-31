﻿namespace Level31_FountainOfObjects;

internal class PitRoom : MainRoom, ISubRoom
{
    public PitRoom(int rows, int columns) : base(rows, columns)
    {
        Pit = new IMainRoom.Coordinate(Rows - 5, Columns - 12);
        LocateSenses();
    }

    internal IMainRoom.Coordinate Pit { get; }
    internal List<IMainRoom.Coordinate> PitCoords { get; } = new();
    internal List<IMainRoom.Coordinate> PitEdgeCoords { get; } = new();

    protected override void ItemSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, Pit, PitCoords);
    }

    protected override void AllSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Pit, 3, 3, PitEdgeCoords);
    }

    protected override SenseTypesCoordinates SenseTypeSelector(List<IMainRoom.Coordinate> sense)
    {
        SenseTypesCoordinates senseTypeCoordinates;
        if (sense == PitCoords) senseTypeCoordinates = SenseTypesCoordinates.Death;
        else if (sense == PitEdgeCoords) senseTypeCoordinates = SenseTypesCoordinates.Fear;
        else senseTypeCoordinates = SenseTypesCoordinates.Nothing;
        return senseTypeCoordinates;
    }
}