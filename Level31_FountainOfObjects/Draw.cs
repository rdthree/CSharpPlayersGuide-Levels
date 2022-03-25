namespace Level31_FountainOfObjects;

internal class Draw : IDraw
{
    private readonly MainRoom _mainRoom;
    private readonly Player _player;
    private readonly FountainRoom _fountainRoom;

    internal Draw(MainRoom mainRoom, Player player, FountainRoom fountainRoom)
    {
        _mainRoom = mainRoom;
        _player = player;
        _fountainRoom = fountainRoom;
    }

    public void DrawRoom()
    {
        for (var i = 0; i < _mainRoom.Rows; i++)
        {
            for (var j = 0; j < _mainRoom.Columns; j++)
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
        if (DrawFountainLocation(coord, ConsoleColor.Red, '#')) return;
        if (DrawSense(coord, _fountainRoom.SeeingCoords, ConsoleColor.Blue, '!')) return;
        if (DrawSense(coord, _fountainRoom.SmellingCoords, ConsoleColor.Black, '~')) return;
        if (DrawSense(coord, _fountainRoom.HearingCoords, ConsoleColor.Green, '?')) return;
        DrawRoomGrid(ConsoleColor.Yellow, ':');
    }

    private bool DrawSense(IMainRoom.Coordinate coord, List<IMainRoom.Coordinate> listSense, ConsoleColor color, char c = '+')
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

    private bool DrawFountainLocation(IMainRoom.Coordinate coord, ConsoleColor color, char c = '+')
    {
        if (coord != _fountainRoom.Fountain) return false;
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