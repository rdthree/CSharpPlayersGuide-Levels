namespace Level31_FountainOfObjects;

internal class Game : global::Level31_FountainOfObjects.IGame
{
    private readonly Player _dasPlayer;
    private readonly Draw _dasDraw;

    public Game(int rows, int columns)
    {
        var dasRoom = new MainRoom(rows, columns);
        Console.WriteLine("what is your name?");
        var name = Console.ReadLine();
        _dasPlayer = new Player(name, dasRoom);
        _dasDraw = new Draw(dasRoom, _dasPlayer);
    }


    public void Run()
    {
        Console.WriteLine(_dasPlayer.Name);
        while (true)
        {
            _dasDraw.DrawRoom();
            Console.WriteLine($"Currently at ({_dasPlayer.RowPosition}, {_dasPlayer.ColumnPosition})");
            Console.WriteLine($"{_dasPlayer.Position()}");
            _dasPlayer.Move();
            //Console.Clear();
        }
    }
}