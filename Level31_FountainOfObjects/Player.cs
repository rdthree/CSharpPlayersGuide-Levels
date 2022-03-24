namespace Level31_FountainOfObjects;

internal class Player : IPlayer
{
    public string Name { get; }
    public int ColumnPosition { get; private set; }
    public int RowPosition { get; private set; }
    private Room Room { get; }
    private readonly Controls _control;

    internal Player(string name, Room room)
    {
        _control = new Controls();
        Name = name;
        Room = room;
        RowPosition = 0;
        ColumnPosition = 0;
        Room.SenseRoom();
    }

    public void Move()
    {
        var direction = _control.Go();
        switch (direction)
        {
            case Go.North when RowPosition > 0:
                RowPosition--;
                break;
            case Go.South when RowPosition < Room.Rows - 1:
                RowPosition++;
                break;
            case Go.West when ColumnPosition > 0:
                ColumnPosition--;
                break;
            case Go.East when ColumnPosition < Room.Columns - 1:
                ColumnPosition++;
                break;
        }
    }

    public Sense Position()
    {
        var position = Room.Places[RowPosition, ColumnPosition];
        return position;
    }

    public void Score()
    {
    }
}