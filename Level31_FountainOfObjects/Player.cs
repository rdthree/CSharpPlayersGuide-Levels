namespace Level31_FountainOfObjects;

internal class Player : IPlayer
{
    public string? Name { get; }
    public IMainRoom.Coordinate? Position { get; private set; }
    private MainRoom MainRoom { get; }
    private readonly Controls _control;
    private int _row;
    private int _column;

    internal Player(string? name, MainRoom mainRoom)
    {
        _control = new Controls();
        Name = name;
        MainRoom = mainRoom;
        UpdatePosition();
    }

    public void Move()
    {
        var direction = _control.Go();
        switch (direction)
        {
            case HeadingTypes.North when _row > 0:
                _row--;
                break;
            case HeadingTypes.South when _row < MainRoom.Rows - 1:
                _row++;
                break;
            case HeadingTypes.West when _column > 0:
                _column--;
                break;
            case HeadingTypes.East when _column < MainRoom.Columns - 1:
                _column++;
                break;
        }

        UpdatePosition();
    }

    private void UpdatePosition() => Position = Position with {Row = _row, Column = _column};

    public void Score()
    {
    }
}