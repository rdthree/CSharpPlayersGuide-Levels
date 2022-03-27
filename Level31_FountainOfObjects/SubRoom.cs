namespace Level31_FountainOfObjects;

internal class SubRoom : ISubRoom
{
    public SubRoom(IMainRoom mainRoom)
    {
        _mainRoom = mainRoom;
        SenseCoords = new SenseTypes[_mainRoom.Rows, _mainRoom.Columns];
    }

    private readonly IMainRoom _mainRoom;
    public SenseTypes[,] SenseCoords { get; set; }

    public List<List<IMainRoom.Coordinate>> SubRoomItemList { get; } = new();
    public virtual IMainRoom.Coordinate Location { get; }
    public List<IMainRoom.Coordinate> HearingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SmellingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SeeingCoords { get; } = new();
    private static List<IMainRoom.Coordinate> RoomCoords => new();

    public void LocateSenses()
    {
        for (var i = 0; i < _mainRoom.Rows; i++)
        for (var j = 0; j < _mainRoom.Columns; j++)
        {
            var ijCoord = new IMainRoom.Coordinate(i, j);
            RoomCoords.Add(ijCoord);
        }
    }

    void ISubRoom.SubRoomCoordinates(IMainRoom.Coordinate ijCoord, IMainRoom.Coordinate ijCoordTarget)
    {
        SenseCoordinate(ijCoord, ijCoordTarget, 5, 5, SenseTypes.Hear, HearingCoords);
        SenseCoordinate(ijCoord, ijCoordTarget, 3, 3, SenseTypes.Smell, SmellingCoords);
    }

    protected void SenseCoordinate(IMainRoom.Coordinate coord, IMainRoom.Coordinate coordTarget, int rowDist, int colDist,
        SenseTypes senseType, List<IMainRoom.Coordinate> sense)
    {
        if (coordTarget.Row > rowDist || coordTarget.Column > colDist) return;
        SenseCoords[coord.Row, coord.Column] = senseType;
        sense.Add(item: new(coord.Row, coord.Column));
    }

    private void SenseCoordinateAdjacent(IMainRoom.Coordinate ijCoord, IMainRoom.Coordinate ijCoordTarget,
        SenseTypes senseType, List<IMainRoom.Coordinate> sense)
    {
        if (((ijCoord.Row != ijCoordTarget.Row + 1 || ijCoord.Column != ijCoordTarget.Column) &&
             (ijCoord.Row != ijCoordTarget.Row - 1 || ijCoord.Column != ijCoordTarget.Column) &&
             (ijCoord.Row != ijCoordTarget.Row || ijCoord.Column != ijCoordTarget.Column + 1) &&
             (ijCoord.Row != ijCoordTarget.Row || ijCoord.Column != ijCoordTarget.Column - 1))) return;
        SenseCoords[ijCoord.Row, ijCoord.Column] = senseType;
        sense.Add(item: new(ijCoord.Row, ijCoord.Column));
    }
}