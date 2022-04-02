using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class Maelstrom : MainRoom, ISubRoom
{
    public Maelstrom(int rows, int columns) : base(rows, columns)
    {
        Location = new IMainRoom.Coordinate(Rows - 9, Columns - 22);
        LocateSenses();
    }

    public IMainRoom.Coordinate Location { get; }
    internal List<IMainRoom.Coordinate> MaelstromEdges { get; } = new();
    internal List<IMainRoom.Coordinate> MaelstromWinds { get; } = new();

    protected override void AdjacentSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, Location, MaelstromEdges);
    }

    protected override void AllSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 4, 4, MaelstromWinds);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> sense)
    {
        SenseTypes senseType;
        if (sense == MaelstromEdges) senseType = SenseTypes.Blown;
        else if (sense == MaelstromWinds) senseType = SenseTypes.Fear;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}