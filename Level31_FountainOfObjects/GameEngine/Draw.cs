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
        if (DrawPlayerColor(_player.RowPosition, _player.ColumnPosition, i, j, '@')) return;
        if (DrawItemLocation(coord, _game.FountainRoom, ConsoleColor.Red, '#')) return;
        if (DrawItemLocation(coord, _game.Maelstrom, ConsoleColor.Gray, 'W')) return;
        if (DrawItemLocation(coord, _game.PitRoom, ConsoleColor.Magenta, 'P')) return;
        if (DrawItemLocation(coord, _game.Amarok, ConsoleColor.White, 'O')) return;
        if (DrawSense(coord, _game.Amarok.AmarokEdges, ConsoleColor.White, 'x')) return;
        if (DrawSense(coord, _game.Amarok.AmarokSmellCoords, ConsoleColor.White, 's')) return;
        //if (DrawSense(coord, _game.PitRoom.PitCoords, ConsoleColor.Cyan, '%')) return;
        if (DrawSense(coord, _game.PitRoom.PitEdgeCoords, ConsoleColor.DarkGray, '%')) return;
        if (DrawSense(coord, _game.Maelstrom.MaelstromEdges, ConsoleColor.Gray, '>')) return;
        if (DrawSense(coord, _game.Maelstrom.MaelstromWinds, ConsoleColor.DarkYellow, '/')) return;
        if (DrawSense(coord, _game.FountainRoom.SeeingCoords, ConsoleColor.Blue, '!')) return;
        if (DrawSense(coord, _game.FountainRoom.SmellingCoords, ConsoleColor.Black, '~')) return;
        if (DrawSense(coord, _game.FountainRoom.HearingCoords, ConsoleColor.Green, '?')) return;
        DrawRoomGrid(ConsoleColor.Yellow, ':');
    }


    private static bool DrawPlayerColor(int rowPos, int colPos, int i, int j, char c = '+')
    {
        if (rowPos != i || colPos != j) return false;
        WriteResetChar(c, ConsoleColor.Red);
        return true;
    }

    private static void DrawRoomGrid(ConsoleColor color, char c = '+') => WriteResetChar(c, color);

    private static bool DrawItemLocation(IMainRoom.Coordinate coord, ISubRoom place, ConsoleColor color,
        char c = '+')
    {
        // fix these so all info is derived from the SubRoom class...then include bool to show that it is alive or dead based on if it got shots
        //if (coord != _fountainRoom.Fountain) return false;
        if (coord != place.Location) return false;
        WriteResetChar(c, color);
        return true;
    }

    private static bool DrawSense(IMainRoom.Coordinate coord, IEnumerable<IMainRoom.Coordinate> listSense,
        ConsoleColor color,
        char c = '+')
    {
        if (listSense.All(coordinate => coord != coordinate)) return false;
        WriteResetChar(c, color);
        return true;
    }

    private static void WriteResetChar(char c = '+', ConsoleColor color = ConsoleColor.Black)
    {
        Console.ForegroundColor = color;
        Console.Write(c.ToString());
        Console.ResetColor();
    }

    private static string Message(SenseTypes sense) => sense switch
    {
        SenseTypes.Amarok => "eaten. over",
        SenseTypes.Alert => "uh oh",
        SenseTypes.Blown => "the maelstrom sends you across the plains",
        SenseTypes.Chill => "a chill fills the air",
        SenseTypes.Fountain => "you have reached the fountain",
        SenseTypes.Hear => "the sound of water rushing",
        SenseTypes.Maelstrom => "the maelstrom rushes around you",
        SenseTypes.Nothing => "on the move",
        SenseTypes.See => "you see the fountain",
        SenseTypes.Smell => "the smell of fountain water fills your nostrils",
        _ => "on the move"
    };
}