namespace Level31_FountainOfObjects;

internal interface IRoom
{
    int Rows { get; }
    int Columns { get; }
    SenseTypes[,] Places { get; }

    record Coordinate(int Row, int Column);
    List<Coordinate> Hearing { get; }
    List<Coordinate> Smelling { get; }
    List<Coordinate> Seeing { get; }
    Coordinate Fountain { get; }
    void Entrance();
    void FountainRoom();
    void SenseRoom();
    void RoomSize();
}