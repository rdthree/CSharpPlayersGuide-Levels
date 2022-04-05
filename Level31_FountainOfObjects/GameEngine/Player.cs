using Level31_FountainOfObjects.RoomsEnemies;

namespace Level31_FountainOfObjects.GameEngine;

internal class Player : IPlayer
{
    public string? Name { get; }
    public int PlayerColumn { get; private set; }
    public int PlayerRow { get; private set; }
    public IMainRoom.Coordinate PlayerLocation { get; private set; }
    public int Moves { get; private set; }
    public Controls Control { get; }
    private readonly Game _game;

    internal Player(string? name, Game game)
    {
        Name = name;
        Control = new Controls();
        _game = game;
        PlayerRow = 0;
        PlayerColumn = 0;
        PlayerLocation = new IMainRoom.Coordinate(PlayerRow, PlayerColumn);
        Moves = 0;
    }

    public void Move()
    {
        var direction = Control.Go();
        switch (direction)
        {
            case HeadingTypes.North when PlayerRow > 0:
                PlayerRow--;
                break;
            case HeadingTypes.South when PlayerRow < _game.MainRoom.Rows - 1:
                PlayerRow++;
                break;
            case HeadingTypes.West when PlayerColumn > 0:
                PlayerColumn--;
                break;
            case HeadingTypes.East when PlayerColumn < _game.MainRoom.Columns - 1:
                PlayerColumn++;
                break;
            case HeadingTypes.None:
            default:
                break;
        }

        Moves++;
        PlayerLocation = new IMainRoom.Coordinate(PlayerRow, PlayerColumn);
    }

    /// <summary>
    /// This returns "sense" messages and locations on the main playing board, based on the player location.
    /// Also includes interactions that may change a players location.
    /// </summary>
    /// <returns></returns>
    public SenseTypes PlayerInteractions()
    {
        var mainPos = _game.MainRoom.SenseCoords[PlayerRow, PlayerColumn];
        var fountainPos = _game.FountainRoom.SenseCoords[PlayerRow, PlayerColumn];

        foreach (var amarok in _game.Amaroks)
        {
            var amarokPos = amarok.SenseCoords[PlayerRow, PlayerColumn];
            if (amarokPos != SenseTypes.Nothing) return amarokPos;
        }

        foreach (var pitRoom in _game.PitRooms)
        {
            var pitPos = pitRoom.SenseCoords[PlayerRow, PlayerColumn];
            if (pitPos != SenseTypes.Nothing) return pitPos;
        }

        foreach (var maelstrom in _game.Maelstroms)
        {
            var maelstromPos = maelstrom.SenseCoords[PlayerRow, PlayerColumn];
            if (maelstromPos != SenseTypes.Nothing)
            {
                if (maelstromPos == SenseTypes.Blown)
                {
                    PlayerRow -= 5;
                    PlayerColumn -= 5;
                    return maelstromPos;
                }

                return maelstromPos;
            }
        }

        return fountainPos != SenseTypes.Nothing ? fountainPos : mainPos;
    }
}