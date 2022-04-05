namespace Level31_FountainOfObjects.RoomsEnemies;

internal interface ISubRoom : IMainRoom
{
    Coordinate Location { get; }
    List<Coordinate> CenterCoordList { get; }
    List<Coordinate> EdgeCoordList { get; }
    List<Coordinate> FieldCoordList { get; }
    List<Coordinate> OuterFieldCoordList { get; }
    bool IsOn();
    ConsoleColor CenterColor { get; }
    ConsoleColor EdgeColor { get; }
    ConsoleColor FieldColor { get; }
    ConsoleColor OuterFieldColor { get; }
    char CenterSymbol { get; }
    char EdgeSymbol { get; }
    char FieldSymbol { get; }
    char OuterFieldSymbol { get; }
}