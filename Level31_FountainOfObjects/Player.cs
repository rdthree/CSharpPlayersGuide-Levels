namespace Level31_FountainOfObjects;

internal class Player : IPlayer
{
    public string? Name { get; }
    public int ColumnPosition { get; private set; }
    public int RowPosition { get; private set; }
    private MainRoom MainRoom { get; }
    private FountainRoom FountainRoom { get; }
    private PitRoom PitRoom { get; }
    private readonly Controls _control;

    internal Player(string? name, MainRoom mainRoom, FountainRoom fountainRoom, PitRoom pitroom)
    {
        _control = new Controls();
        Name = name;
        MainRoom = mainRoom;
        FountainRoom = fountainRoom;
        PitRoom = pitroom;
        RowPosition = 0;
        ColumnPosition = 0;
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

    public SenseTypesCoordinates Position()
    {
        var mainPos = MainRoom.SenseCoords[RowPosition, ColumnPosition];
        var fountainPos = FountainRoom.SenseCoords[RowPosition, ColumnPosition];
        var pitPos = PitRoom.SenseCoords[RowPosition, ColumnPosition];
        if (pitPos != SenseTypesCoordinates.Nothing) return pitPos;
        if (fountainPos != SenseTypesCoordinates.Nothing) return fountainPos;
        return mainPos;
    }

    public void Score()
    {
    }
}