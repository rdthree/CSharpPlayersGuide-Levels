using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class Maelstrom : MainRoom, ISubRoom
{
    public Maelstrom(int rows, int columns) : base(rows, columns)
    {
        MaelstromCoord = new IMainRoom.Coordinate(Rows - 9, Columns - 22);
        LocateSenses();
    }

    internal IMainRoom.Coordinate MaelstromCoord { get; }
    internal List<IMainRoom.Coordinate> MaelstromCoords { get; } = new();
    internal List<IMainRoom.Coordinate> MaelstromWinds { get; } = new();

    protected override void ItemSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, MaelstromCoord, MaelstromCoords);
    }

    protected override void AllSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, MaelstromCoord, 4, 4, MaelstromWinds);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> sense)
    {
        SenseTypes senseType;
        if (sense == MaelstromCoords) senseType = SenseTypes.Blown;
        else if (sense == MaelstromWinds) senseType = SenseTypes.Fear;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}