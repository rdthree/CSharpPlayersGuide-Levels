using Level31_FountainOfObjects.Rooms;

namespace Level31_FountainOfObjects.GameEngine;

internal class Player : IPlayer
{
    public string? Name { get; }
    public int PlayerColumn { get; private set; }
    public int PlayerRow { get; private set; }
    public IMainRoom.Coordinate PlayerLocation { get; private set; }
    public int Moves { get; internal set; }
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
            case HeadingTypes.North when PlayerRow <= 0:
                PlayerRow = _game.MainRoom.Rows - 1;
                break;
            case HeadingTypes.South when PlayerRow < _game.MainRoom.Rows - 1:
                PlayerRow++;
                break;
            case HeadingTypes.South when PlayerRow >= _game.MainRoom.Rows - 1:
                PlayerRow = 0;
                break;
            case HeadingTypes.West when PlayerColumn > 0:
                PlayerColumn--;
                break;
            case HeadingTypes.West when PlayerColumn <= 0:
                PlayerColumn = _game.MainRoom.Columns - 1;
                break;
            case HeadingTypes.East when PlayerColumn < _game.MainRoom.Columns - 1:
                PlayerColumn++;
                break;
            case HeadingTypes.East when PlayerColumn >= _game.MainRoom.Columns - 1:
                PlayerColumn = 0;
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

        foreach (var amarokPos in _game.Amaroks.Select(amarok => amarok.SenseCoords[PlayerRow, PlayerColumn])
                     .Where(amarokPos => amarokPos != SenseTypes.Nothing))
            return amarokPos;

        foreach (var pitPos in _game.PitRooms.Select(pitRoom => pitRoom.SenseCoords[PlayerRow, PlayerColumn])
                     .Where(pitPos => pitPos != SenseTypes.Nothing))
            return pitPos;

        foreach (var maelstromPos in _game.Maelstroms
                     .Select(maelstrom => maelstrom.SenseCoords[PlayerRow, PlayerColumn])
                     .Where(maelstromPos => maelstromPos != SenseTypes.Nothing))
        {
            if (maelstromPos != SenseTypes.Blown) return maelstromPos;
            var rndRowMove = new Random(DateTime.Now.Millisecond);
            var rndColMove = new Random(DateTime.Now.Millisecond);
            var playerRowMove = PlayerRow + rndRowMove.Next(-5, 5);
            var playerColMove = PlayerRow + rndColMove.Next(-5, 5);

            if (playerRowMove < 0) PlayerRow = _game.MainRoom.Rows + playerRowMove;
            else if (playerRowMove > _game.MainRoom.Rows - 1) PlayerRow = playerRowMove - _game.MainRoom.Rows;
            else PlayerRow = playerRowMove;

            if (playerColMove < 0) PlayerColumn = _game.MainRoom.Columns + playerColMove;
            else if (playerColMove > _game.MainRoom.Columns - 1) PlayerColumn = playerColMove - _game.MainRoom.Columns;
            else PlayerColumn = playerColMove;

            //PlayerRow -= 2;
            //PlayerColumn -= 2;

            for (var i = 0; i < _game.Maelstroms.Count - 1; i++)
            {
                var rnd = new Random(DateTime.Now.Millisecond);
                //var newRow = _game.Maelstroms[i].Location.Row + rnd.Next(_game.MainRoom.Rows);
                //var newCol = _game.Maelstroms[i].Location.Column + rnd.Next();
                _game.Maelstroms[i] = new Maelstrom(_game.MainRoom.Rows, _game.MainRoom.Columns,
                    _game.Maelstroms[i].Location.Row + rnd.Next(2),
                    _game.Maelstroms[i].Location.Column + rnd.Next(2));
            }

            return maelstromPos;
        }

        return fountainPos != SenseTypes.Nothing ? fountainPos : mainPos;
    }
}