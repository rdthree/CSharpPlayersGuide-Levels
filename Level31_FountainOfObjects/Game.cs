namespace Level31_FountainOfObjects;

internal class Game : IGame
{
    private readonly Player _dasPlayer;
    private readonly Draw _dasDraw;
    private readonly MainRoom? _mainRoom;
    public List<SubRoom>? SubRooms { get; }

    public Game(int rows, int columns)
    {
        _mainRoom = new MainRoom(rows, columns);
        var fountainRoom = new SubRoom(_mainRoom);
        SubRooms?.Add(fountainRoom);
        Console.WriteLine("what is your name?");
        var name = Console.ReadLine();
        _dasPlayer = new Player(name, _mainRoom);
        _dasDraw = new Draw(_mainRoom, _dasPlayer);
    }


    public void Run()
    {
        Console.WriteLine(_dasPlayer.Name);
        var counter = 0;
        while (counter < _mainRoom.Rows * _mainRoom.Columns)
        {
            _dasDraw.DrawRoom();
            if (_dasPlayer.Position != null)
            {
                Console.WriteLine($"Currently at ({_dasPlayer.Position.Row}, {_dasPlayer.Position.Column})");
                Console.WriteLine($"{_dasPlayer.Position}");
            }

            _dasPlayer.Move();
            counter++;
        }
    }
}