using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class Amarok : MainRoom, ISubRoom
{
    public Amarok(int rows, int columns) : base(rows, columns)
    {
        Location = new IMainRoom.Coordinate(Rows - 12, Columns - 46);
        LocateSenses();
    }

    public IMainRoom.Coordinate Location { get; }
    internal List<IMainRoom.Coordinate> AmarokEdges { get; } = new();
    internal List<IMainRoom.Coordinate> AmarokSmellCoords { get; } = new();

    protected override void AdjacentSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, Location, AmarokEdges);
    }

    protected override void AllSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 1, 1, AmarokSmellCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> sense)
    {
        SenseTypes senseType;
        if (sense == AmarokEdges) senseType = SenseTypes.Death;
        else if (sense == AmarokSmellCoords) senseType = SenseTypes.Fear;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}