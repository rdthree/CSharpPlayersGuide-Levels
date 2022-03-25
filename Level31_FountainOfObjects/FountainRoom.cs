namespace Level31_FountainOfObjects;

internal class FountainRoom : MainRoom, ISubRoom
{
    public FountainRoom(int rows, int columns) : base(rows, columns)
    {
        Rows = rows;
        Columns = columns;
        Fountain = new IMainRoom.Coordinate(Rows - 2, Columns - 1);
        SenseCoords = new SenseTypes[Rows, Columns];
    }

    public new int Rows { get; }
    public new int Columns { get; }
    public SenseTypes[,] SenseCoords { get; }
    public List<IMainRoom.Coordinate> HearingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SmellingCoords { get; } = new();
    public List<IMainRoom.Coordinate> SeeingCoords { get; } = new();
    private List<IMainRoom.Coordinate> FountainCoords { get; } = new();
    public IMainRoom.Coordinate Fountain { get; }
    private static List<IMainRoom.Coordinate> RoomCoords => new();

    #region fountain

    public void LocateSenses()
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
        {
            RoomCoords.Add(new(Row: i, j));
            var (row, column) = FromCenter(i: i, j: j);
            AllSenseCoordinates(i, j, row, column);
        }
    }

    private void AllSenseCoordinates(int i, int j, int row, int column)
    {
        SenseCoordinate(i, j, row, column, 5, 5, SenseCoords, SenseTypes.Hear, HearingCoords);
        SenseCoordinate(i, j, row, column, 3, 3, SenseCoords, SenseTypes.Smell, SmellingCoords);
        SenseCoordinateAdjacent(i, j, Fountain.Row, Fountain.Column, SenseCoords, SenseTypes.See, SeeingCoords);
        SenseCoordinate(i, j, row, column, 1, 1, SenseCoords, SenseTypes.Fountain, FountainCoords);
    }

    private IMainRoom.Coordinate FromCenter(int i, int j)
    {
        var checkI = Math.Abs(Fountain.Row - i);
        var checkJ = Math.Abs(Fountain.Column - j);
        return new IMainRoom.Coordinate(checkI, checkJ);
    }

    private void SenseCoordinate(int i, int j, int row, int column, int rowDist, int colDist,
        SenseTypes[,] senseCoordinates, SenseTypes senseType, List<IMainRoom.Coordinate> sense)
    {
        if (row > rowDist || column > colDist) return;
        senseCoordinates[i, j] = senseType;
        sense.Add(item: new(i, j));
    }

    private void SenseCoordinateAdjacent(int i, int j, int row, int column, SenseTypes[,] senseCoordinates,
        SenseTypes senseType, List<IMainRoom.Coordinate> sense)
    {
        if ((i == row + 1 && j == column || i == row - 1 && j == column ||
             i == row && j == column + 1 || i == row && j == column - 1))
        {
            senseCoordinates[i, j] = senseType;
            sense.Add(item: new(i, j));
        }
    }

    #endregion
}