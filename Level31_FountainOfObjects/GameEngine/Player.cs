using Level31_FountainOfObjects.RoomsEnemies;

namespace Level31_FountainOfObjects.GameEngine;

internal class Player : IPlayer
{
    public string? Name { get; }
    public int ColumnPosition { get; private set; }
    public int RowPosition { get; private set; }
    private MainRoom MainRoom { get; }
    private FountainRoom FountainRoom { get; }
    private PitRoom PitRoom { get; }
    private Maelstrom Maelstrom { get; }
    private Amarok Amarok { get; }
    private readonly Controls _control;

    internal Player(string? name, MainRoom mainRoom, FountainRoom fountainRoom, PitRoom pitRoom, Maelstrom maelstrom,
        Amarok amarok)
    {
        _control = new Controls();
        Name = name;
        MainRoom = mainRoom;
        FountainRoom = fountainRoom;
        PitRoom = pitRoom;
        Maelstrom = maelstrom;
        Amarok = amarok;
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

    public SenseTypes PositionItems()
    {
        var mainPos = MainRoom.SenseCoords[RowPosition, ColumnPosition];
        var amarokPos = Amarok.SenseCoords[RowPosition, ColumnPosition];
        var fountainPos = FountainRoom.SenseCoords[RowPosition, ColumnPosition];
        var pitPos = PitRoom.SenseCoords[RowPosition, ColumnPosition];
        var maelstromPos = Maelstrom.SenseCoords[RowPosition, ColumnPosition];
        if (amarokPos != SenseTypes.Nothing) return amarokPos;
        if (maelstromPos != SenseTypes.Nothing)
        {
            if (maelstromPos == SenseTypes.Blown)
            {
                RowPosition = 10;
                ColumnPosition = 5;
            } //move that fool
            else return maelstromPos;
        }

        if (pitPos != SenseTypes.Nothing) return pitPos;
        if (fountainPos != SenseTypes.Nothing) return fountainPos;
        return mainPos;
    }

    public void Score()
    {
    }
}