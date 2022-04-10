namespace Level31_FountainOfObjects.Rooms;

internal interface ISubRoom : IMainRoom
{
    Coordinate Location { get; }
    bool CanBeShot { get; }

    /// <summary>
    /// Property and Method to turn SubRooms on and off
    /// </summary>
    bool IsOn { get; }

    IMainRoom.Coordinate BoundaryCoords { get; }

    /// <summary>
    /// chars used for drawing sprites
    /// </summary>
    char CenterSymbol { get; }

    char EdgeSymbol { get; }
    char FieldSymbol { get; }
    char OuterFieldSymbol { get; }
}