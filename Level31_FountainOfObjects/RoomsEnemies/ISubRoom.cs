using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal interface ISubRoom : IMainRoom
{
    SenseTypes[,]? SenseCoords { get; }
    Coordinate Location { get; }
}