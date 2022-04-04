using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class FountainRoom : MainRoom, ISubRoom
{
    public FountainRoom(int rows, int columns) : base(rows, columns)
    {
        Location = new IMainRoom.Coordinate(Rows - 2, Columns - 1);
        LocateSenses();
        IsOn = true;
        ItemColor = ConsoleColor.Cyan;
        EdgeColor = ConsoleColor.Blue;
        FieldColor = ConsoleColor.DarkBlue;
        OuterFieldColor = ConsoleColor.DarkCyan;
        ItemSymbol = '!';
        EdgeSymbol = '~';
        FieldSymbol = '-';
        OuterFieldSymbol = '*';
    }

    internal bool IsOn { get; }
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
        SenseCoordinate(i, j, Location, 3, 3, FieldCoords);
        SenseCoordinate(i, j, Location, 5, 5, OuterFieldCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> coordList)
    {
        SenseTypes senseType;
        if (coordList == OuterFieldCoords) senseType = SenseTypes.Hear;
        else if (coordList == EdgeCoords) senseType = SenseTypes.See;
        else if (coordList == FieldCoords) senseType = SenseTypes.Smell;
        else if (coordList == ItemCoords) senseType = SenseTypes.Fountain;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}