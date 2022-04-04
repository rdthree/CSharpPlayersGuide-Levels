using Level31_FountainOfObjects.RoomsEnemies;

namespace Level31_FountainOfObjects.GameEngine;

internal class Player : IPlayer
{
    public string? Name { get; }
    public int ColumnPosition { get; private set; }
    public int RowPosition { get; private set; }
    public IMainRoom.Coordinate Location { get; private set; }
    public int Moves { get; private set; }

    public Controls Control { get; }
    private readonly Game _game;

    internal Player(string? name, Game game)
    {
        Name = name;
        Control = new Controls();
        _game = game;
        RowPosition = 0;
        ColumnPosition = 0;
        Location = new IMainRoom.Coordinate(RowPosition, ColumnPosition);
        Moves = 0;
    }

    public void Move()
    {
        var direction = Control.Go();
        switch (direction)
        {
            case HeadingTypes.North when RowPosition > 0:
                RowPosition--;
                break;
            case HeadingTypes.South when RowPosition < _game.MainRoom.Rows - 1:
                RowPosition++;
                break;
            case HeadingTypes.West when ColumnPosition > 0:
                ColumnPosition--;
                break;
            case HeadingTypes.East when ColumnPosition < _game.MainRoom.Columns - 1:
                ColumnPosition++;
                break;
            case HeadingTypes.None:
            default:
                break;
        }

        Moves++;
        Location = new IMainRoom.Coordinate(RowPosition, ColumnPosition);
    }

    public SenseTypes PlayerInteractions()
    {
        var mainPos = _game.MainRoom.SenseCoords[RowPosition, ColumnPosition];
        var amarokPos = _game.Amarok.SenseCoords[RowPosition, ColumnPosition];
        var fountainPos = _game.FountainRoom.SenseCoords[RowPosition, ColumnPosition];
        var pitPos = _game.PitRoom.SenseCoords[RowPosition, ColumnPosition];
        var maelstromPos = _game.Maelstrom.SenseCoords[RowPosition, ColumnPosition];
        if (amarokPos != SenseTypes.Nothing) return amarokPos;
        if (maelstromPos != SenseTypes.Nothing)
        {
            if (maelstromPos == SenseTypes.Blown)
            {
                RowPosition = 10;
                ColumnPosition = 5;
            } 
            else return maelstromPos;
        }

        if (pitPos != SenseTypes.Nothing) return pitPos;
        return fountainPos != SenseTypes.Nothing ? fountainPos : mainPos;
    }
}