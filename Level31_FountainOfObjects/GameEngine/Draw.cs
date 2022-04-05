using Level31_FountainOfObjects.RoomsEnemies;

namespace Level31_FountainOfObjects.GameEngine;

internal class Draw : IDraw
{
    private readonly Game _game;
    private readonly Player _player;

    internal Draw(Player player, Game game)
    {
        _game = game;
        _player = player;
    }

    public void DrawRoom()
    {
        for (var i = 0; i < _game.MainRoom.Rows; i++)
        {
            for (var j = 0; j < _game.MainRoom.Columns; j++)
                SpriteDrawOrder(i, j);

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Draw console text sprites in order of appearance on a list of `if` `bool` methods.
    /// `true` methods higher up the list will overwrite methods with overlapping coordinates lower down the list.  
    /// Designed to be inserted into a nested i,j for loop.
    /// </summary>
    /// <param name="i">int i in a nested i,j for loop</param>
    /// <param name="j">int j in a nested i,j for loop</param>
    private void SpriteDrawOrder(int i, int j)
    {
        var coord = new IMainRoom.Coordinate(i, j);
        if (DrawPlayer(coord, _player.Location, '@')) return;

        if (_game.FountainRoom.IsOn)
        {
            if (DrawItemLocation(coord, _game.FountainRoom)) return;
            if (DrawSense(coord, _game.FountainRoom.EdgeCoords, ConsoleColor.Blue, '!')) return;
            if (DrawSense(coord, _game.FountainRoom.FieldCoords, ConsoleColor.Black, '~')) return;
            if (DrawSense(coord, _game.FountainRoom.OuterFieldCoords, ConsoleColor.Green, '?')) return;
        }

        _game.Amarok.IsOn = SubRoomOnOff(_player, _game.Amarok);
        if (_game.Amarok.IsOn)
        {
            if (DrawItemLocation(coord, _game.Amarok)) return;
            if (DrawSense(coord, _game.Amarok.EdgeCoords, ConsoleColor.White, 'x')) return;
            if (DrawSense(coord, _game.Amarok.FieldCoords, ConsoleColor.White, 's')) return;
        }

        _game.PitRoom.IsOn = SubRoomOnOff(_player, _game.PitRoom);
        if (_game.PitRoom.IsOn)
        {
            if (DrawItemLocation(coord, _game.PitRoom)) return;
            if (DrawSense(coord, _game.PitRoom.ItemCoords, ConsoleColor.Cyan, '%')) return;
            if (DrawSense(coord, _game.PitRoom.EdgeCoords, ConsoleColor.DarkGray, '%')) return;
        }

        _game.Maelstrom.IsOn = SubRoomOnOff(_player, _game.Maelstrom);
        if (_game.Maelstrom.IsOn)
        {
            if (DrawItemLocation(coord, _game.Maelstrom)) return;
            if (DrawSense(coord, _game.Maelstrom.FieldCoords, ConsoleColor.Gray, '>')) return;
            if (DrawSense(coord, _game.Maelstrom.EdgeCoords, ConsoleColor.DarkYellow, '/')) return;
        }

        DrawRoomGrid(ConsoleColor.Yellow, ':');
    }


    private static bool DrawPlayer(IMainRoom.Coordinate coord, IMainRoom.Coordinate playerCoord, char c = '+')
    {
        if (coord != playerCoord) return false;
        WriteResetChar(c, ConsoleColor.Red);
        return true;
    }

    private static bool DrawItemLocation(IMainRoom.Coordinate coord, ISubRoom place)
    {
        if (coord != place.Location) return false;
        WriteResetChar(place.ItemSymbol, place.ItemColor);
        return true;
    }

    private static bool DrawSense(IMainRoom.Coordinate coord, IEnumerable<IMainRoom.Coordinate>? listSense,
        ConsoleColor color,
        char c = '+')
    {
        if (listSense != null && listSense.All(coordinate => coord != coordinate)) return false;
        WriteResetChar(c, color);
        return true;
    }

    private static void DrawRoomGrid(ConsoleColor color, char c = '+') => WriteResetChar(c, color);

    private static void WriteResetChar(char c = '+', ConsoleColor color = ConsoleColor.Black)
    {
        Console.ForegroundColor = color;
        Console.Write(c.ToString());
        Console.ResetColor();
    }

    private static bool SubRoomOnOff(Player player, ISubRoom subRoom)
    {
        if (!player.Control.IsShoot) return subRoom.IsOn();
        {
            var subRoomRow = subRoom.Location.Row;
            var subRoomCol = subRoom.Location.Column;
            var playerRow = player.Location.Row;
            var playerCol = player.Location.Column;
            var playerDir = player.Control.Direction;

            if (playerDir == HeadingTypes.North && subRoomRow < playerRow && subRoomCol == playerCol) return false;
            if (playerDir == HeadingTypes.South && subRoomRow > playerRow && subRoomCol == playerCol) return false;
            if (playerDir == HeadingTypes.West && subRoomCol < playerCol && subRoomRow == playerRow) return false;
            if (playerDir == HeadingTypes.East && subRoomCol > playerCol && subRoomRow == playerRow) return false;
        }

        return subRoom.IsOn();
    }
}