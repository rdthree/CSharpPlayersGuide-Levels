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


    private void SetupRoom()
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
            SenseCoords[i, j] = SenseTypesCoordinates.Nothing;
    }

    protected void SenseCoordinate(int i, int j, IMainRoom.Coordinate item, int rowDist, int colDist,
        List<IMainRoom.Coordinate> sense)
    {
        var (row, column) = FromCenter(i: i, j: j, item);
        var senseTypeCoordinates = SenseTypeSelector(sense);
        if (row > rowDist || column > colDist) return;
        SenseCoords[i, j] = senseTypeCoordinates;
        sense.Add(item: new(i, j));
    }

    protected void SenseCoordinateAdjacent(int i, int j, IMainRoom.Coordinate item, List<IMainRoom.Coordinate> sense)
    {
        var (row, column) = (item.Row, item.Column);
        if (((i != row + 1 || j != column) && (i != row - 1 || j != column) &&
             (i != row || j != column + 1) &&
             (i != row || j != column - 1))) return;
        var senseTypeCoordinates = SenseTypeSelector(sense);
        SenseCoords[i, j] = senseTypeCoordinates;
        sense.Add(item: new IMainRoom.Coordinate(i, j));
    }

    protected virtual IMainRoom.Coordinate FromCenter(int i, int j, IMainRoom.Coordinate item)
    {
        var checkI = Math.Abs(item.Row - i);
        var checkJ = Math.Abs(item.Column - j);
        return new IMainRoom.Coordinate(checkI, checkJ);
    }

    protected void LocateSenses()
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
        {
            AllSenseCoordinates(i, j);
            ItemSenseCoordinates(i, j);
        }
    }

    protected virtual void AllSenseCoordinates(int i, int j)
    {
    }

    protected virtual void ItemSenseCoordinates(int i, int j)
    {
    }

    protected virtual SenseTypesCoordinates SenseTypeSelector(List<IMainRoom.Coordinate> sense)
    {
        return SenseTypesCoordinates.Nothing;
    }
}