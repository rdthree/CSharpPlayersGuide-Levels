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
    /// <summary>
    /// The list of "senses" as part of a 2D array representing locations on a game board
    /// </summary>
    public SenseTypes[,] SenseCoords { get; }
    protected bool IsAlive { get; set; } = true;

    private void SetupRoom()
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
            SenseCoords[i, j] = SenseTypes.Nothing;
    }

    protected void SenseCoordinate(int i, int j, IMainRoom.Coordinate itemCoord, int rowDist, int colDist,
        List<IMainRoom.Coordinate> coordList)
    {
        var (row, column) = FromCenter(i: i, j: j, itemCoord);
        var senseTypeCoordinates = SenseTypeSelector(coordList);
        if (row > rowDist || column > colDist) return;
        SenseCoords[i, j] = senseTypeCoordinates;
        coordList.Add(item: new IMainRoom.Coordinate(i, j));
    }

    protected void SenseCoordinateAdjacent(int i, int j, IMainRoom.Coordinate itemCoord,
        List<IMainRoom.Coordinate> coordList)
    {
        var (row, column) = (itemCoord.Row, itemCoord.Column);
        if (((i != row + 1 || j != column) && (i != row - 1 || j != column) &&
             (i != row || j != column + 1) && (i != row || j != column - 1))) return;
        var senseTypeCoordinates = SenseTypeSelector(coordList);
        SenseCoords[i, j] = senseTypeCoordinates;
        coordList.Add(item: new IMainRoom.Coordinate(i, j));
    }
    

    /// <summary>
    /// Get an items distance based on the center coordinates of another item.  Used to locate "senses"
    /// that are relative to the target item (subclass of MainRoom).  Used as part of an i,j for loop.
    /// </summary>
    /// <param name="i">i in i,j for loop</param>
    /// <param name="j">j in i,j for loop</param>
    /// <param name="targetItemCoordinate"></param>
    /// <returns></returns>
    protected virtual IMainRoom.Coordinate FromCenter(int i, int j, IMainRoom.Coordinate targetItemCoordinate)
    {
        var (row, column) = targetItemCoordinate;
        var checkI = Math.Abs(row - i);
        var checkJ = Math.Abs(column - j);
        return new IMainRoom.Coordinate(checkI, checkJ);
    }

    /// <summary>
    /// Final method uses to locate all "senses" on the game board.  Takes other methods as input that
    /// were responsible for building a the locations of "senses".  Uses an i,j for loop based on Rows and
    /// Columns to work with the builder methods.
    /// </summary>
    protected void LocateSenses()
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
        {
            BuildSenseCoordinates(i, j);
            BuildAdjSenseCoordinates(i, j);
        }
    }

    
    /// <summary>
    /// Locate "sense" enums based on the item location.  Uses other methods as input and is part of a
    /// finalizing method that locates all "senses" using an i, j loop.
    /// </summary>
    /// <param name="i">i in i,j for loop</param>
    /// <param name="j">j in i,j for loop</param>
    protected virtual void BuildSenseCoordinates(int i, int j)
    {
    }

    /// <summary>
    /// Locate "sense" enums directly adjacent to the item location.  Uses other methods as input and is part of a
    /// finalizing method that locates all "senses" using an i,j loop.
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    protected virtual void BuildAdjSenseCoordinates(int i, int j)
    {
    }

    /// <summary>
    /// Input method that the builder methods use to locate "senses" on the game board.  Each
    /// subclass has rules that locate "senses".
    /// </summary>
    /// <param name="coordList"></param>
    /// <returns></returns>
    protected virtual SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> coordList)
    {
        return SenseTypes.Nothing;
    }
}