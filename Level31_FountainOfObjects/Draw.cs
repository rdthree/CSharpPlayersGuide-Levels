namespace Level31_FountainOfObjects;

internal class Draw : IDraw
{
    private readonly MainRoom _mainRoom;
    private readonly Player _player;
    private IMainRoom.Coordinate? _drawRowColumn;
    private readonly List<SubRoom> _subRooms;

    internal Draw(MainRoom mainRoom, Player player)
    {
        _mainRoom = mainRoom;
        _player = player;
        _subRooms.Add(new FountainRoom(_mainRoom));
        var seeingCoords = _subRooms[0].SeeingCoords;
    }

    IMainRoom.Coordinate? IDraw.DrawRowColumn
    {
        get => _drawRowColumn;
        set => _drawRowColumn = value;
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
        _drawRowColumn = new IMainRoom.Coordinate(i, j);
        if (DrawPlayerColor('@')) return;
        if (DrawFountainLocation(ConsoleColor.Red, '#')) return;
        if (DrawSense(_subRooms[0].SeeingCoords, ConsoleColor.Blue, '!')) return;
        if (DrawSense(_subRooms[0].SmellingCoords, ConsoleColor.Black, '~')) return;
        if (DrawSense(_subRooms[0].HearingCoords, ConsoleColor.Green, '?')) return;
        DrawRoomGrid(ConsoleColor.Yellow, ':');
    }

    private bool DrawSense(List<IMainRoom.Coordinate> listSense,
        ConsoleColor color, char c = '+')
    {
        if (listSense.All(coordinate => _drawRowColumn != coordinate)) return false;
        WriteResetChar(c, color);
        return true;
    }

    private bool DrawPlayerColor(char c = '+')
    {
        if (_drawRowColumn != null && (_player.Position.Row != _drawRowColumn.Row ||
                                       _player.Position.Column != _drawRowColumn.Column))
            return false;

        WriteResetChar(c, ConsoleColor.Red);
        return true;
    }

    private static void DrawRoomGrid(ConsoleColor color, char c = '+') => WriteResetChar(c, color);

    private bool DrawFountainLocation(ConsoleColor color, char c = '+')
    {
        if (_drawRowColumn != _subRooms[0]. _fountainRoom.Fountain) return false;
        WriteResetChar(c, color);
        return true;
    }

    private static void WriteResetChar(char c = '+', ConsoleColor color = ConsoleColor.Black)
    {
        Console.ForegroundColor = color;
        Console.Write(c.ToString());
        Console.ResetColor();
    }
}