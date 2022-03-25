namespace Level31_FountainOfObjects;

internal class Player : IPlayer
{
    public string? Name { get; }
    public int ColumnPosition { get; private set; }
    public int RowPosition { get; private set; }
    private MainRoom MainRoom { get; }
    private readonly Controls _control;

    internal Player(string? name, MainRoom mainRoom)
    {
        _control = new Controls();
        Name = name;
        MainRoom = mainRoom;
        RowPosition = 0;
        ColumnPosition = 0;
        MainRoom.LocateSenses();
    }

    public void Move()
    {
        var direction = _control.Go();
        switch (direction)
        {
            case HeadingTypes.North when RowPosition > 0:
                RowPosition--;
                break;
            case HeadingTypes.South when RowPosition < MainRoom.Rows - 1:
                RowPosition++;
                break;
            case HeadingTypes.West when ColumnPosition > 0:
                ColumnPosition--;
                break;
            case HeadingTypes.East when ColumnPosition < MainRoom.Columns - 1:
                ColumnPosition++;
                break;
        }
    }

    public SenseTypes Position()
    {
        var position = MainRoom.SenseCoords[RowPosition, ColumnPosition];
        return position;
    }

    public void Score()
    {
    }
}