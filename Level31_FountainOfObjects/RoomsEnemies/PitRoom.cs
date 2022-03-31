using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

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
        SenseCoordinate(i, j, Pit, 2, 2, PitEdgeCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> sense)
    {
        SenseTypes senseType;
        if (sense == PitCoords) senseType = SenseTypes.Death;
        else if (sense == PitEdgeCoords) senseType = SenseTypes.Fear;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}