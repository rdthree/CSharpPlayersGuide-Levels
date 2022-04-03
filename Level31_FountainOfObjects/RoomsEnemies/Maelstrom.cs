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
    internal List<IMainRoom.Coordinate> MaelstromBlown { get; } = new();

    protected override void BuildAdjSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, Location, MaelstromEdges);
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 4, 4, MaelstromWinds);
        SenseCoordinate(i, j, Location, 0, 0, MaelstromBlown);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> coordList)
    {
        SenseTypes senseType;
        if (coordList == MaelstromBlown) senseType = SenseTypes.Blown;
        else if (coordList == MaelstromEdges) senseType = SenseTypes.Chill;
        else if (coordList == MaelstromWinds) senseType = SenseTypes.Alert;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}