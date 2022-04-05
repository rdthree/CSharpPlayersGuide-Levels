using Level31_FountainOfObjects.RoomsEnemies;

namespace Level31_FountainOfObjects.GameEngine;

internal class Game : IGame
{
    // player and ui
    private readonly Player _dasPlayer;
    private readonly Draw _dasDraw;

    // places and things
    internal MainRoom MainRoom { get; }

    internal FountainRoom FountainRoom { get; }
    //internal PitRoom PitRoom { get; }
    //internal Maelstrom Maelstrom { get; }
    //internal Amarok Amarok { get; }

    internal List<PitRoom> PitRooms { get; }
    internal List<Maelstrom> Maelstroms { get; }
    internal List<Amarok> Amaroks { get; }

    public Game(int rows, int columns)
    {
        if (rows < 10 && columns < 10)
        {
            rows = 15;
            columns = 30;
        }

        // places and things
        MainRoom = new MainRoom(rows, columns);
        FountainRoom = new FountainRoom(rows, columns, 5, 4);
        PitRooms = new List<PitRoom>() { new PitRoom(rows, columns, 5, 12) };
        Maelstroms = new List<Maelstrom>() { new Maelstrom(rows, columns, 9, 22) };
        Amaroks = new List<Amarok>()
        {
            new Amarok(rows, columns, rows - 2, columns - 5),
            new Amarok(rows, columns, rows - 8, columns - 9),
        };

        // start game
        Console.WriteLine("what is your name?");
        var name = Console.ReadLine();
        _dasPlayer = new Player(name, this);
        _dasDraw = new Draw(_dasPlayer, this);
    }


    public void Run()
    {
        Console.WriteLine(_dasPlayer.Name);
        var counter = 0;
        var maxMoves = 100;
        while (counter < maxMoves)
        {
            if (_dasPlayer.Control.ShowMap) _dasDraw.DrawRoom();
            Console.WriteLine($"ShowMap is {_dasPlayer.Control.ShowMap}");
            Console.WriteLine(
                $"You are headed {_dasPlayer.Control.Direction} and " +
                $"currently at ({_dasPlayer.PlayerRow}, {_dasPlayer.PlayerColumn})");

            var messages = Messages.Senses(_dasPlayer.PlayerInteractions());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"you have made {_dasPlayer.Moves} moves, {maxMoves - _dasPlayer.Moves} remaining.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"shoot status: {_dasPlayer.Control.IsShoot}");
            Console.WriteLine($"{FountainRoom.GetType().Name} room is: {FountainRoom.IsOn}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(messages);
            Console.ResetColor();

            _dasPlayer.Move();
            Console.Clear();
            counter++;
        }
    }
}