using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class Amarok : MainRoom, ISubRoom
{
    public Amarok(int rows, int columns) : base(rows, columns)
    {
        Location = new IMainRoom.Coordinate(Rows - 12, Columns - 46);
        LocateSenses();
        IsOn = true;
        ItemColor = ConsoleColor.Red;
        EdgeColor = ConsoleColor.DarkRed;
        FieldColor = ConsoleColor.Magenta;
        OuterFieldColor = FieldColor;
        ItemSymbol = 'A';
        EdgeSymbol = 'S';
        FieldSymbol = 'x';
        OuterFieldSymbol = FieldSymbol;
    }

    internal bool IsOn { get; set; }
    bool ISubRoom.IsOn() => IsOn;
    public ConsoleColor ItemColor { get; }
    public ConsoleColor EdgeColor { get; }
    public ConsoleColor FieldColor { get; }
    public ConsoleColor OuterFieldColor { get; }
    public char ItemSymbol { get; }
    public char EdgeSymbol { get; }
    public char FieldSymbol { get; }
    public char OuterFieldSymbol { get; }
    public IMainRoom.Coordinate Location { get; }
    public List<IMainRoom.Coordinate> ItemCoords { get; } = new();
    public List<IMainRoom.Coordinate> EdgeCoords { get; } = new();
    public List<IMainRoom.Coordinate> FieldCoords { get; } = new();
    public List<IMainRoom.Coordinate> OuterFieldCoords { get; } = new();

    protected override void BuildAdjSenseCoordinates(int i, int j)
    {
        SenseCoordinateAdjacent(i, j, Location, EdgeCoords);
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 1, 1, FieldCoords);
        SenseCoordinate(i, j, Location, 0, 0, ItemCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> coordList)
    {
        SenseTypes senseType;
        if (coordList == ItemCoords) senseType = SenseTypes.Amarok;
        else if (coordList == EdgeCoords) senseType = SenseTypes.Alert;
        else if (coordList == FieldCoords) senseType = SenseTypes.Chill;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}