namespace Level31_FountainOfObjects;

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
        Console.WriteLine("what is your name?");
        var name = Console.ReadLine();
        _dasPlayer = new Player(name, _mainRoom, fountainRoom, pitRoom);
        _dasDraw = new Draw(_mainRoom, _dasPlayer, fountainRoom, pitRoom);
    }


    public void Run()
    {
        Console.WriteLine(_dasPlayer.Name);
        var counter = 0;
        while (counter < _mainRoom.Rows * _mainRoom.Columns)
        {
            _dasDraw.DrawRoom();
            Console.WriteLine($"Currently at ({_dasPlayer.RowPosition}, {_dasPlayer.ColumnPosition})");
            Console.WriteLine($"{_dasPlayer.Position()}");
            _dasPlayer.Move();
            counter++;
        }
    }
}