namespace Level31_FountainOfObjects;

internal interface IPlayer
{
    string? Name { get; }
    IMainRoom.Coordinate? Position { get; }

    void Move();

    void Score();
}