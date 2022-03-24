namespace Level31_FountainOfObjects;

internal interface IRoom
{
    int Rows { get; }
    int Columns { get; }
    Sense[,] Places { get; }
    void Entrance();
    void FountainRoom();
    void SenseRoom();
    void RoomSize();
}