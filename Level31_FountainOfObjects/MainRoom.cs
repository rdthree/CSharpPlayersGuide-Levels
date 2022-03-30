namespace Level31_FountainOfObjects;

internal class MainRoom : IMainRoom
{
    public MainRoom(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        SenseCoords = new SenseTypesCoordinates[Rows, Columns];
        SetupRoom();
    }

    public int Rows { get; }
    public int Columns { get; }
    public SenseTypesCoordinates[,] SenseCoords { get; }
    public List<IMainRoom.Coordinate> HearingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SmellingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SeeingCoords { get; } = new();

    private void SetupRoom()
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
            SenseCoords[i, j] = SenseTypesCoordinates.Nothing;
    }

    protected void SenseCoordinate(int i, int j, int row, int column, int rowDist, int colDist,
        List<IMainRoom.Coordinate> sense)
    {
        var senseTypeCoordinates = SenseTypeSelector(sense);
        if (row > rowDist || column > colDist) return;
        SenseCoords[i, j] = senseTypeCoordinates;
        sense.Add(item: new(i, j));
    }

    protected void SenseCoordinateAdjacent(int i, int j, int row, int column, List<IMainRoom.Coordinate> sense)
    {
        if (((i != row + 1 || j != column) && (i != row - 1 || j != column) &&
             (i != row || j != column + 1) &&
             (i != row || j != column - 1))) return;

        var senseTypeCoordinates = SenseTypeSelector(sense);
        SenseCoords[i, j] = senseTypeCoordinates;
        sense.Add(item: new(i, j));
    }

    protected virtual IMainRoom.Coordinate FromCenter(int i, int j, IMainRoom.Coordinate item)
    {
        var checkI = Math.Abs(item.Row - i);
        var checkJ = Math.Abs(item.Column - j);
        return new IMainRoom.Coordinate(checkI, checkJ);
    }

    protected void LocateSenses(IMainRoom.Coordinate item)
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
        {
            var (row, column) = FromCenter(i: i, j: j, item);
            AllSenseCoordinates(i, j, row, column);
            ItemSenseCoordinates(i, j, row, column);
        }
    }

    protected virtual void AllSenseCoordinates(int i, int j, int row, int column)
    {
    }

    protected virtual void ItemSenseCoordinates(int i, int j, int row, int column)
    {
    }

    private SenseTypesCoordinates SenseTypeSelector(List<IMainRoom.Coordinate> sense)
    {
        SenseTypesCoordinates senseTypeCoordinates;
        if (sense == HearingCoords) senseTypeCoordinates = SenseTypesCoordinates.Hear;
        else if (sense == SeeingCoords) senseTypeCoordinates = SenseTypesCoordinates.See;
        else if (sense == SmellingCoords) senseTypeCoordinates = SenseTypesCoordinates.Smell;
        else senseTypeCoordinates = SenseTypesCoordinates.Nothing; // TODO: this causes an issue with the item location
        return senseTypeCoordinates;
    }
}