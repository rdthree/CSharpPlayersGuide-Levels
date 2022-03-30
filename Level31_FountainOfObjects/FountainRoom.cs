namespace Level31_FountainOfObjects;

internal class FountainRoom : SubRoom
{
    public FountainRoom(IMainRoom? mainRoom) : base(mainRoom)
    {
        _mainRoom = mainRoom;
        Location = new IMainRoom.Coordinate(_mainRoom.Rows - 2, _mainRoom.Columns - 1);
        SenseCoords = new SenseTypes[_mainRoom.Rows, _mainRoom.Columns];
        SubRoomItemList = new List<List<IMainRoom.Coordinate>?>
        {
            HearingCoords,
            SmellingCoords,
            SeeingCoords
        };
    }

    private readonly IMainRoom? _mainRoom;
    public override IMainRoom.Coordinate? Location { get; }
    private static List<IMainRoom.Coordinate> RoomCoords => new();
    public List<IMainRoom.Coordinate>? FountainCoords { get; } = new();

    public new List<List<IMainRoom.Coordinate>?> SubRoomItemList { get; private set; }
    public List<IMainRoom.Coordinate> SmellingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SeeingCoords { get; } = new();
    public List<IMainRoom.Coordinate> HearingCoords { get; } = new();


    public new void LocateSenses()
    {
        if (_mainRoom == null) return;
        for (var i = 0; i < _mainRoom.Rows; i++)
        for (var j = 0; j < _mainRoom.Columns; j++)
        {
            var ijCoord = new IMainRoom.Coordinate(i, j);
            var ijCoordTarget = LocationFromCenter(ijCoord);
            RoomCoords.Add(ijCoord);
            ((ISubRoom)this).SubRoomCoordinates(ijCoord, ijCoordTarget);
        }
    }

    internal void SubRoomCoordinates(IMainRoom.Coordinate ijCoord, IMainRoom.Coordinate? ijCoordTarget)
    {
        SenseCoordinateAdjacent(ijCoord, Location, SenseTypes.See, SeeingCoords);
        //SenseCoordinate(ijCoord, ijCoordTarget, 1, 1, SenseTypes.Fountain, FountainCoords);
        SenseCoordinate(ijCoord, ijCoordTarget, 5, 5, SenseTypes.Hear, HearingCoords);
    }

    private IMainRoom.Coordinate? LocationFromCenter(IMainRoom.Coordinate ijCoordinate)
    {
        if (Location == null) return null;
        var checkI = Math.Abs(Location.Row - ijCoordinate.Row);
        var checkJ = Math.Abs(Location.Column - ijCoordinate.Column);
        return new IMainRoom.Coordinate(checkI, checkJ);
    }

    private void SenseCoordinateAdjacent(IMainRoom.Coordinate ijCoord, IMainRoom.Coordinate? ijCoordTarget,
        SenseTypes senseType, List<IMainRoom.Coordinate>? sense)
    {
        if (ijCoordTarget != null &&
            ((ijCoord.Row != ijCoordTarget.Row + 1 || ijCoord.Column != ijCoordTarget.Column) &&
             (ijCoord.Row != ijCoordTarget.Row - 1 || ijCoord.Column != ijCoordTarget.Column) &&
             (ijCoord.Row != ijCoordTarget.Row || ijCoord.Column != ijCoordTarget.Column + 1) &&
             (ijCoord.Row != ijCoordTarget.Row || ijCoord.Column != ijCoordTarget.Column - 1))) return;
        SenseCoords[ijCoord.Row, ijCoord.Column] = senseType;
        sense?.Add(item: new IMainRoom.Coordinate(ijCoord.Row, ijCoord.Column));
    }
}