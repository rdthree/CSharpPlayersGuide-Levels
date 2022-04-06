namespace Level31_FountainOfObjects.Rooms;

internal interface ISubRoom : IMainRoom
{
    Coordinate Location { get; }
    bool IsOn();
    ConsoleColor CenterColor { get; }
    char CenterSymbol { get; }
}