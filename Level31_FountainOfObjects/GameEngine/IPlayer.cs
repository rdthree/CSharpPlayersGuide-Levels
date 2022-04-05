namespace Level31_FountainOfObjects.GameEngine;

internal interface IPlayer
{
    string? Name { get; }
    int PlayerColumn { get; }
    int PlayerRow { get; }
    int Moves { get; }
    SenseTypes PlayerInteractions();
}