namespace Level31_FountainOfObjects;

internal class Draw : IDraw
{
    private readonly Room _room;
    private readonly Player _player;

    internal Draw(Room room, Player player)
    {
        _room = room;
        _player = player;
    }

    public void DrawRoom()
    {
        for (var i = 0; i < _room.Rows; i++)
        {
            for (var j = 0; j < _room.Columns; j++)
                SpriteDrawOrder(i, j);

            Console.WriteLine();
        }
    }

    private void SpriteDrawOrder(int i, int j)
    {
        // the upper methods will overwrite the lower methods graphically. it works like a typewriter
        var coord = new IRoom.Coordinate(i, j);
        if (DrawPlayerColor(_player.RowPosition, _player.ColumnPosition, i, j, '@')) return;
        if (DrawFountainLocation(coord, ConsoleColor.Red, '#')) return;
        if (DrawSense(coord, _room.Seeing, ConsoleColor.Blue, '!')) return;
        if (DrawSense(coord, _room.Smelling, ConsoleColor.Black, '~')) return;
        if (DrawSense(coord, _room.Hearing, ConsoleColor.Green, '?')) return;
        DrawRoomGrid(ConsoleColor.Yellow, ':');
    }

    private bool DrawSense(IRoom.Coordinate coord, List<IRoom.Coordinate> listSense, ConsoleColor color, char c = '+')
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

    private bool DrawFountainLocation(IRoom.Coordinate coord, ConsoleColor color, char c = '+')
    {
        if (coord != _room.Fountain) return false;
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