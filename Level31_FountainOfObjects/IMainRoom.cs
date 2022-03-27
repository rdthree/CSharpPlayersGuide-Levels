namespace Level31_FountainOfObjects;

internal interface IMainRoom
{
    int Rows { get; }
    int Columns { get; }

    internal record Coordinate(int Row, int Column);
    
}

internal interface ISubRoom
{
    SenseTypes[,]? SenseCoords { get; }

    abstract IMainRoom.Coordinate Location { get; }
    void SubRoomCoordinates(IMainRoom.Coordinate ijCoord, IMainRoom.Coordinate ijCoordTarget);
}