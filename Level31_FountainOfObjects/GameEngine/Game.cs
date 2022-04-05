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
    internal List<PitRoom> PitRooms { get; }
    internal List<Maelstrom> Maelstroms { get; }
    internal List<Amarok> Amaroks { get; }

    public Game(int rows, int columns)
    {
        int gameRows, gameColumns;
        switch (rows)
        {
            case < 5 when columns < 10:
                gameRows = 5;
                gameColumns = 10;
                break;
            case > 30 when columns > 80:
                gameRows = 30;
                gameColumns = 80;
                break;
            default:
                gameRows = 25;
                gameColumns = 90;
                break;
        }

        var rndRow = new Random(gameRows);
        var rndCol = new Random(gameColumns);

        // places and things
        if (gameRows < 20 || gameColumns < 40)
        {
            const int maxAmaroks = 3;
            MainRoom = new MainRoom(gameRows, gameColumns);
            FountainRoom = new FountainRoom(gameRows, gameColumns, 5, 4);
            PitRooms = new List<PitRoom>() { new PitRoom(gameRows, gameColumns, 5, 12) };
            Maelstroms = new List<Maelstrom>() { new Maelstrom(gameRows, gameColumns, 10, 23) };
            Amaroks = new List<Amarok>();
            for (var i = 0; i < maxAmaroks; i++)
                Amaroks.Add(new Amarok(gameRows, gameColumns, rndRow.Next(gameRows), rndCol.Next(gameColumns)));
        }
        else
        {
            const int maxAmaroks = 6;
            MainRoom = new MainRoom(gameRows, gameColumns);
            FountainRoom = new FountainRoom(gameRows, gameColumns, 5, 4);
            PitRooms = new List<PitRoom>() { new PitRoom(gameRows, gameColumns, 5, 12) };
            Maelstroms = new List<Maelstrom>() { new Maelstrom(gameRows, gameColumns, 10, 23) };
            Amaroks = new List<Amarok>();
            for (var i = 0; i < maxAmaroks; i++)
                Amaroks.Add(new Amarok(gameRows, gameColumns, rndRow.Next(gameRows), rndCol.Next(gameColumns)));
        }

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
        const int maxMoves = 100;
        while (counter < maxMoves)
        {
            if (_dasPlayer.Control.ShowMap) _dasDraw.DrawRoom();
            Console.WriteLine($"ShowMap is {_dasPlayer.Control.ShowMap}");
            Console.WriteLine(
                $"You are headed {_dasPlayer.Control.Direction} and " +
                $"currently at ({_dasPlayer.PlayerRow}, {_dasPlayer.PlayerColumn})" +
                $"map size: ({MainRoom.Rows},{MainRoom.Columns})");

            var messages = Messages.Senses(_dasPlayer.PlayerInteractions());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"you have made {_dasPlayer.Moves} moves, {maxMoves - _dasPlayer.Moves} remaining.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"shoot status: {_dasPlayer.Control.IsShoot}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(messages);
            Console.ResetColor();

            _dasPlayer.Move();
            Console.Clear();
            counter++;
        }
    }
}