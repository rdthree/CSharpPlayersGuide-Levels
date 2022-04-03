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
    private List<IMainRoom.Coordinate> AmarokCenter { get; } = new();
    
    protected override void BuildAdjSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, Location, AmarokEdges);
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 1, 1, AmarokSmellCoords);
        SenseCoordinate(i, j, Location, 0, 0, AmarokCenter);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> coordList)
    {
        SenseTypes senseType;
        if (coordList == AmarokCenter) senseType = SenseTypes.Amarok;
        else if (coordList == AmarokEdges) senseType = SenseTypes.Alert;
        else if (coordList == AmarokSmellCoords) senseType = SenseTypes.Chill;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
    
    
}