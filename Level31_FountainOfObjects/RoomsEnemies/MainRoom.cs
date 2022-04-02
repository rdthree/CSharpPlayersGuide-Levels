using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class MainRoom : IMainRoom
{
    public MainRoom(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        SenseCoords = new SenseTypes[Rows, Columns];
        SetupRoom();
    }

    public int Rows { get; }
    public int Columns { get; }
    public SenseTypes[,] SenseCoords { get; }
    protected bool IsAlive { get; set; } = true;

    private void SetupRoom()
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
            SenseCoords[i, j] = SenseTypes.Nothing;
    }

    protected void SenseCoordinate(int i, int j, IMainRoom.Coordinate item, int rowDist, int colDist,
        List<IMainRoom.Coordinate> sense)
    {
        var (row, column) = FromCenter(i: i, j: j, item);
        var senseTypeCoordinates = SenseTypeSelector(sense);
        if (row > rowDist || column > colDist) return;
        SenseCoords[i, j] = senseTypeCoordinates;
        sense.Add(item: new IMainRoom.Coordinate(i, j));
    }

    protected void SenseCoordinateAdjacent(int i, int j, IMainRoom.Coordinate item, List<IMainRoom.Coordinate> sense)
    {
        var (row1, column1) = item;
        var (row, column) = (Row: row1, Column: column1);
        if (((i != row + 1 || j != column) && (i != row - 1 || j != column) &&
             (i != row || j != column + 1) && (i != row || j != column - 1))) return;
        var senseTypeCoordinates = SenseTypeSelector(sense);
        SenseCoords[i, j] = senseTypeCoordinates;
        sense.Add(item: new IMainRoom.Coordinate(i, j));
    }

    protected virtual IMainRoom.Coordinate FromCenter(int i, int j, IMainRoom.Coordinate item)
    {
        var (row, column) = item;
        var checkI = Math.Abs(row - i);
        var checkJ = Math.Abs(column - j);
        return new IMainRoom.Coordinate(checkI, checkJ);
    }

    protected void LocateSenses()
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
        {
            AllSenseCoordinates(i, j);
            AdjacentSenseCoordinates(i, j);
        }
    }

    protected virtual void AllSenseCoordinates(int i, int j)
    {
    }

    protected virtual void AdjacentSenseCoordinates(int i, int j)
    {
    }

    protected virtual SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> sense)
    {
        return SenseTypes.Nothing;
    }
}