using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class Maelstrom : MainRoom, ISubRoom
{
    public Maelstrom(int rows, int columns) : base(rows, columns)
    {
        Location = new IMainRoom.Coordinate(Rows - 9, Columns - 22);
        LocateSenses();
        IsOn = true;
        ItemColor = ConsoleColor.Gray;
        EdgeColor = ConsoleColor.DarkGray;
        FieldColor = ConsoleColor.DarkGray;
        OuterFieldColor = FieldColor;
        ItemSymbol = 'M';
        EdgeSymbol = '>';
        FieldSymbol = '/';
        OuterFieldSymbol = FieldSymbol;
    }

    public bool IsOn { get; set; }
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
        SenseCoordinate(i, j, Location, 0, 0, ItemCoords);
        SenseCoordinate(i, j, Location, 4, 4, FieldCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> coordList)
    {
        SenseTypes senseType;
        if (coordList == ItemCoords) senseType = SenseTypes.Blown;
        else if (coordList == FieldCoords) senseType = SenseTypes.Chill;
        else if (coordList == EdgeCoords) senseType = SenseTypes.Alert;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}