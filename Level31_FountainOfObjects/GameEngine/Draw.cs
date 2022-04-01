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
        if (DrawItemLocation(coord, _game.FountainRoom.Fountain, ConsoleColor.Red, '#')) return;
        if (DrawItemLocation(coord, _game.Maelstrom.MaelstromCoord, ConsoleColor.Gray, 'W')) return;
        if (DrawItemLocation(coord, _game.PitRoom.Pit, ConsoleColor.Magenta, 'P')) return;
        if (DrawItemLocation(coord, _game.Amarok.AmarokLocation, ConsoleColor.White, 'O')) return;
        if (DrawSense(coord, _game.Amarok.AmarokCoords, ConsoleColor.White, 'x')) return;
        if (DrawSense(coord, _game.Amarok.AmarokSmellCoords, ConsoleColor.White, 's')) return;
        if (DrawSense(coord, _game.PitRoom.PitCoords, ConsoleColor.Cyan, '%')) return;
        if (DrawSense(coord, _game.PitRoom.PitEdgeCoords, ConsoleColor.DarkGray, '%')) return;
        if (DrawSense(coord, _game.Maelstrom.MaelstromCoords, ConsoleColor.Gray, '>')) return;
        if (DrawSense(coord, _game.Maelstrom.MaelstromWinds, ConsoleColor.DarkYellow, '/')) return;
        if (DrawSense(coord, _game.FountainRoom.SeeingCoords, ConsoleColor.Blue, '!')) return;
        if (DrawSense(coord, _game.FountainRoom.SmellingCoords, ConsoleColor.Black, '~')) return;
        if (DrawSense(coord, _game.FountainRoom.HearingCoords, ConsoleColor.Green, '?')) return;
        DrawRoomGrid(ConsoleColor.Yellow, ':');
    }

    private bool DrawSense(IMainRoom.Coordinate coord, List<IMainRoom.Coordinate> listSense, ConsoleColor color,
        char c = '+')
    {
        if (listSense.All(coordinate => coord != coordinate)) return false;
        writeResetChar(c, color);
        return true;
    }

    private bool DrawPlayerColor(int rowPos, int colPos, int i, int j, char c = '+')
    {
        if (rowPos != i || colPos != j) return false;
        writeResetChar(c, ConsoleColor.Red);
        return true;
    }

    private void DrawRoomGrid(ConsoleColor color, char c = '+') => writeResetChar(c, color);

    private bool DrawItemLocation(IMainRoom.Coordinate coord, IMainRoom.Coordinate place, ConsoleColor color,
        char c = '+')
    {
        //if (coord != _fountainRoom.Fountain) return false;
        if (coord != place) return false;
        writeResetChar(c, color);
        return true;
    }

    private void writeResetChar(char c = '+', ConsoleColor color = ConsoleColor.Black)
    {
        Console.ForegroundColor = color;
        Console.Write(c.ToString());
        Console.ResetColor();
    }
}