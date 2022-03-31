using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class Amarok : MainRoom, ISubRoom
{
    public Amarok(int rows, int columns) : base(rows, columns)
    {
        AmarokLocation = new IMainRoom.Coordinate(Rows - 12, Columns - 46);
        LocateSenses();
    }

    internal IMainRoom.Coordinate AmarokLocation { get; }
    internal List<IMainRoom.Coordinate> AmarokCoords { get; } = new();
    internal List<IMainRoom.Coordinate> AmarokSmellCoords { get; } = new();

    protected override void ItemSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, AmarokLocation, AmarokCoords);
    }

    protected override void AllSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, AmarokLocation, 1, 1, AmarokSmellCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> sense)
    {
        SenseTypes senseType;
        if (sense == AmarokCoords) senseType = SenseTypes.Death;
        else if (sense == AmarokSmellCoords) senseType = SenseTypes.Fear;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}