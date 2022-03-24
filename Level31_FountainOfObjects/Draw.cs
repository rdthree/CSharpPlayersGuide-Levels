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
            {
                var coord = new IRoom.Coordinate(i, j);
                

                foreach (var coordinate in _room.Hearing)
                    if (coord == coordinate) Console.ForegroundColor = ConsoleColor.Green;

                foreach (var coordinate in _room.Smelling)
                    if (coord == coordinate) Console.ForegroundColor = ConsoleColor.Magenta;
                
                foreach (var coordinate in _room.Seeing)
                                    if (coord == coordinate) Console.ForegroundColor = ConsoleColor.Blue;

                if (coord == _room.Fountain) Console.ForegroundColor = ConsoleColor.Cyan;
                
                if (_player.RowPosition == i && _player.ColumnPosition == j)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write("+");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}