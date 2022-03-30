namespace Level31_FountainOfObjects;

internal class Player : IPlayer
{
    public string? Name { get; }
    public IMainRoom.Coordinate? Position { get; private set; }
    private MainRoom? MainRoom { get; }
    private readonly Controls _control;
    private int _row;
    private int _column;

    internal Player(string? name, MainRoom? mainRoom)
    {
        _control = new Controls();
        Name = name;
        MainRoom = mainRoom;
        Position = new IMainRoom.Coordinate(0, 0);
    }

    public void Move()
    {
        var direction = _control.Go();
        switch (direction)
        {
            case HeadingTypes.North when _row > 0:
                _row--;
                break;
            case HeadingTypes.South when MainRoom != null && _row < MainRoom.Rows - 1:
                _row++;
                break;
            case HeadingTypes.West when _column > 0:
                _column--;
                break;
            case HeadingTypes.East when MainRoom != null && _column < MainRoom.Columns - 1:
                _column++;
                break;
            case HeadingTypes.None:
                break;
        }

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (Position != null) Position = Position with { Row = _row, Column = _column };
    }

    public void Score()
    {
    }
}