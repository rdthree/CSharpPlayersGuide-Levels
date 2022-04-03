using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class PitRoom : MainRoom, ISubRoom
{

    public PitRoom(int rows, int columns) : base(rows, columns)
    {
        Location = new IMainRoom.Coordinate(Rows - 5, Columns - 12);
        LocateSenses();
    }

    public IMainRoom.Coordinate Location { get; }
    internal List<IMainRoom.Coordinate> PitCoords { get; } = new();
    internal List<IMainRoom.Coordinate> PitEdgeCoords { get; } = new();

    protected override void BuildAdjSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, Location, PitCoords);
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 2, 2, PitEdgeCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> coordList)
    {
        SenseTypes senseType;
        if (coordList == new List<IMainRoom.Coordinate>(){Location}) senseType = SenseTypes.End;
        else if (coordList == PitEdgeCoords) senseType = SenseTypes.Chill;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}