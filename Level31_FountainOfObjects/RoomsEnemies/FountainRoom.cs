using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class FountainRoom : MainRoom, ISubRoom
{
    public FountainRoom(int rows, int columns) : base(rows, columns)
    {
        Location = new IMainRoom.Coordinate(Rows - 2, Columns - 1);
        LocateSenses();
    }
    
    public IMainRoom.Coordinate Location { get; }

    private List<IMainRoom.Coordinate> FountainCoords { get; } = new();
    public List<IMainRoom.Coordinate> HearingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SmellingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SeeingCoords { get; } = new();


    protected override void AdjacentSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, Location, SeeingCoords);
    }

    protected override void AllSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 5, 5, HearingCoords);
        SenseCoordinate(i, j, Location, 3, 3, SmellingCoords);
        SenseCoordinate(i, j, Location, 0, 0, FountainCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> sense)
    {
        SenseTypes senseType;
        if (sense == HearingCoords) senseType = SenseTypes.Hear;
        else if (sense == SeeingCoords) senseType = SenseTypes.See;
        else if (sense == SmellingCoords) senseType = SenseTypes.Smell;
        else if (sense == FountainCoords) senseType = SenseTypes.Fountain;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }

}