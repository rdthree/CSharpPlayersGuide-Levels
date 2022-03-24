namespace Level31_FountainOfObjects;

internal interface IPlayer
{
    string? Name { get; }
    int ColumnPosition { get; }
    int RowPosition { get; }

    void Move();

    SenseTypes Position();

    void Score();
}