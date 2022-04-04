using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class PitRoom : MainRoom, ISubRoom
{
    public PitRoom(int rows, int columns) : base(rows, columns)
    {
        Location = new IMainRoom.Coordinate(Rows - 5, Columns - 12);
        LocateSenses();
        IsOn = true;
        ItemColor = ConsoleColor.Green;
        EdgeColor = ConsoleColor.DarkGreen;
        FieldColor = ConsoleColor.DarkCyan;
        OuterFieldColor = FieldColor;
        ItemSymbol = 'P';
        EdgeSymbol = '%';
        FieldSymbol = 's';
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
        SenseCoordinateAdjacent(i, j, Location, ItemCoords);
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 2, 2, EdgeCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> coordList)
    {
        SenseTypes senseType;
        if (coordList == new List<IMainRoom.Coordinate>() { Location }) senseType = SenseTypes.End;
        else if (coordList == EdgeCoords) senseType = SenseTypes.Chill;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}