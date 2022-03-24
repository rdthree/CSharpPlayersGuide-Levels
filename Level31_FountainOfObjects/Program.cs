using Level31_FountainOfObjects;
// TODO: use records as coordinates
// TODO: get coordinate data from each see/hear/smell room (use it for GUI or other stuff)
// TODO: place the coordinate data into a list
// TODO: organize the lists into groups of senses, pits, monsters, etc

var dasRoom = new Room(8, 8);
var dasPlayer = new Player("Dopey", dasRoom);
var dasDraw = new Draw(dasRoom, dasPlayer);

Console.WriteLine(dasPlayer.Name);
while (true)
{
    dasDraw.DrawRoom();
    Console.WriteLine($"Currently at ({dasPlayer.RowPosition}, {dasPlayer.ColumnPosition})");
    Console.WriteLine($"{dasPlayer.Position()}");
    dasPlayer.Move();
    Console.Clear();
}

internal class Draw
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
                if (_player.RowPosition == i && _player.ColumnPosition == j)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write("+");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}

internal interface IDraw
{
    void DrawRoom();
}