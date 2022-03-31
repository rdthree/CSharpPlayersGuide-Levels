using Level31_FountainOfObjects.RoomsEnemies;

namespace Level31_FountainOfObjects.GameEngine;

internal class Game : IGame
{
    private readonly Player _dasPlayer;
    private readonly Draw _dasDraw;
    private readonly MainRoom _mainRoom;

    public Game(int rows, int columns)
    {
        _mainRoom = new MainRoom(rows, columns);
        var fountainRoom = new FountainRoom(_mainRoom.Rows, _mainRoom.Columns);
        var pitRoom = new PitRoom(_mainRoom.Rows, _mainRoom.Columns);
        var maelstrom = new Maelstrom(_mainRoom.Rows, _mainRoom.Columns);
        var amarok = new Amarok(_mainRoom.Rows, _mainRoom.Columns);
        Console.WriteLine("what is your name?");
        var name = Console.ReadLine();
        _dasPlayer = new Player(name, _mainRoom, fountainRoom, pitRoom, maelstrom, amarok);
        _dasDraw = new Draw(_mainRoom, _dasPlayer, fountainRoom, pitRoom, maelstrom, amarok);
    }


    public void Run()
    {
        Console.WriteLine(_dasPlayer.Name);
        var counter = 0;
        while (counter < _mainRoom.Rows * _mainRoom.Columns)
        {
            _dasDraw.DrawRoom();
            Console.WriteLine($"Currently at ({_dasPlayer.RowPosition}, {_dasPlayer.ColumnPosition})");
            Console.WriteLine($"{_dasPlayer.PositionItems()}");
            _dasPlayer.Move();
            counter++;
        }
    }
}