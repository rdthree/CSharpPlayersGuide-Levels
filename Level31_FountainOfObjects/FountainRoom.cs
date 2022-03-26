namespace Level31_FountainOfObjects;

internal class FountainRoom : ISubRoom
{
    public FountainRoom(IMainRoom mainRoom)
    {
        _mainRoom = mainRoom;
        Fountain = new IMainRoom.Coordinate(_mainRoom.Rows - 2, _mainRoom.Columns - 1);
        SenseCoords = new SenseTypes[_mainRoom.Rows, _mainRoom.Columns];
    }

    private readonly IMainRoom _mainRoom;
    public SenseTypes[,] SenseCoords { get; }
    public List<IMainRoom.Coordinate> HearingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SmellingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SeeingCoords { get; } = new();
    private List<IMainRoom.Coordinate> FountainCoords { get; } = new();
    public IMainRoom.Coordinate Fountain { get; }
    private static List<IMainRoom.Coordinate> RoomCoords => new();

    public void LocateSenses()
    {
        for (var i = 0; i < _mainRoom.Rows; i++)
        for (var j = 0; j < _mainRoom.Columns; j++)
        {
            var ijCoord = new IMainRoom.Coordinate(i, j);
            var ijCoordTarget = FromCenter(ijCoord);
            RoomCoords.Add(ijCoord);
            AllSenseCoordinates(ijCoord, ijCoordTarget);
        }
    }

    private void AllSenseCoordinates(IMainRoom.Coordinate ijCoord, IMainRoom.Coordinate ijCoordTarget)
    {
        SenseCoordinate(ijCoord, ijCoordTarget, 5, 5, SenseTypes.Hear, HearingCoords);
        SenseCoordinate(ijCoord, ijCoordTarget, 3, 3, SenseTypes.Smell, SmellingCoords);
        SenseCoordinateAdjacent(ijCoord, Fountain, SenseTypes.See, SeeingCoords);
        SenseCoordinate(ijCoord, ijCoordTarget, 1, 1, SenseTypes.Fountain, FountainCoords);
    }

    private IMainRoom.Coordinate FromCenter(IMainRoom.Coordinate ijCoordinate)
    {
        var checkI = Math.Abs(Fountain.Row - ijCoordinate.Row);
        var checkJ = Math.Abs(Fountain.Column - ijCoordinate.Column);
        return new IMainRoom.Coordinate(checkI, checkJ);
    }

    private void SenseCoordinate(IMainRoom.Coordinate coord, IMainRoom.Coordinate coordTarget, int rowDist, int colDist,
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