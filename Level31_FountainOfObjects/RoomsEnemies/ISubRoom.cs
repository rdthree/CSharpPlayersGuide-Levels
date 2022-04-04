namespace Level31_FountainOfObjects.RoomsEnemies;

internal interface ISubRoom : IMainRoom
{
    Coordinate Location { get; }
    List<Coordinate> ItemCoords { get; }
    List<Coordinate> EdgeCoords { get; }
    List<Coordinate> FieldCoords { get; }
    List<Coordinate> OuterFieldCoords { get; }
    bool IsOn();
    ConsoleColor ItemColor { get; }
    ConsoleColor EdgeColor { get; }
    ConsoleColor FieldColor { get; }
    ConsoleColor OuterFieldColor { get; }
    char ItemSymbol { get; }
    char EdgeSymbol { get; }
    char FieldSymbol { get; }
    char OuterFieldSymbol { get; }
}