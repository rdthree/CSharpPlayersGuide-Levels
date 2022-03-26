namespace Level31_FountainOfObjects;

internal interface IDraw
{
    IMainRoom.Coordinate? DrawRowColumn { get; protected internal set; }
    void DrawRoom();
}