using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal abstract class SubRoom : MainRoom, ISubRoom
{
    protected SubRoom(int rows, int columns, int rowOffset, int colOffset) : base(rows, columns)
    {
        Location = new IMainRoom.Coordinate(rows - rowOffset, columns - colOffset);

        ItemCoords = new List<IMainRoom.Coordinate>();
        EdgeCoords = new List<IMainRoom.Coordinate>();
        FieldCoords = new List<IMainRoom.Coordinate>();
        OuterFieldCoords = new List<IMainRoom.Coordinate>();

        ItemColor = ConsoleColor.Black;
        EdgeColor = ItemColor;
        FieldColor = EdgeColor;
        OuterFieldColor = FieldColor;

        ItemSymbol = 'x';
        EdgeSymbol = ItemSymbol;
        FieldSymbol = EdgeSymbol;
        OuterFieldSymbol = EdgeSymbol;

        LocateSenses();
        IsOn = true;
    }


    public IMainRoom.Coordinate Location { get; protected init; }
    public List<IMainRoom.Coordinate> ItemCoords { get; }
    public List<IMainRoom.Coordinate> EdgeCoords { get; }
    public List<IMainRoom.Coordinate> FieldCoords { get; }
    public List<IMainRoom.Coordinate> OuterFieldCoords { get; }
    internal bool IsOn { get; set; }
    bool ISubRoom.IsOn() => IsOn;

    public ConsoleColor ItemColor { get; protected init; }
    public ConsoleColor EdgeColor { get; protected init; }
    public ConsoleColor FieldColor { get; protected init; }
    public ConsoleColor OuterFieldColor { get; protected init; }
    public char ItemSymbol { get; protected init; }
    public char EdgeSymbol { get; protected init; }
    public char FieldSymbol { get; protected init; }
    public char OuterFieldSymbol { get; protected init; }

    private void BuildAdjSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, Location, EdgeCoords);
    }

    protected virtual void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 0, 0, ItemCoords);
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

    private void SenseCoordinateAdjacent(int i, int j, IMainRoom.Coordinate itemCoord,
        List<IMainRoom.Coordinate> coordList)
    {
        var (row, column) = (itemCoord.Row, itemCoord.Column);
        if (((i != row + 1 || j != column) && (i != row - 1 || j != column) &&
             (i != row || j != column + 1) && (i != row || j != column - 1))) return;
        var senseTypeCoordinates = SenseTypeSelector(coordList);
        SenseCoords[i, j] = senseTypeCoordinates;
        coordList.Add(item: new IMainRoom.Coordinate(i, j));
    }

    protected virtual IMainRoom.Coordinate FromCenter(int i, int j, IMainRoom.Coordinate targetItemCoordinate)
    {
        var (row, column) = targetItemCoordinate;
        var checkI = Math.Abs(row - i);
        var checkJ = Math.Abs(column - j);
        return new IMainRoom.Coordinate(checkI, checkJ);
    }

    protected void LocateSenses()
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
        {
            BuildSenseCoordinates(i, j);
            BuildAdjSenseCoordinates(i, j);
        }
    }

    protected virtual SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate>? coordList) => SenseTypes.Nothing;
}