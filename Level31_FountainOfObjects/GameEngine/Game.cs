using Level31_FountainOfObjects.Rooms;

namespace Level31_FountainOfObjects.GameEngine;

internal class Game : IGame
{
    // player and ui
    private readonly Player _dasPlayer;
    private readonly Draw _dasDraw;

    // places and things
    internal MainRoom MainRoom { get; private set; } = new(0, 0);
    internal FountainRoom FountainRoom { get; private set; } = new(0, 0, 0, 0);
    internal List<PitRoom> PitRooms { get; private set; } = new();
    internal List<Maelstrom> Maelstroms { get; private set; } = new();
    internal List<Amarok> Amaroks { get; private set; } = new();

    internal Game()
    {
        GameType();

        // start game
        Console.WriteLine("what is your name?");
        var name = Console.ReadLine();
        _dasPlayer = new Player(name, this);
        _dasDraw = new Draw(_dasPlayer, this);
    }

    private void GameType()
    {
        Console.WriteLine("what type of game?\n(1) small\n(2) medium\n(3) large");
        var gameType = Console.ReadKey(true).KeyChar;
        var gameTypeConvert = int.TryParse(gameType.ToString(), out var gameTypeNum);
        if (!gameTypeConvert) gameTypeNum = 1;
        var gameSize = (GameSize) gameTypeNum;
        Console.WriteLine($"game size is {gameSize}");

        int rows, columns, maxAmaroks, maxMaelstroms, maxPitRooms;
        var (rndRow, rndCol) = (new Random(), new Random());
        switch (gameSize)
        {
            case GameSize.Small:
                (rows, columns) = (15, 45);
                maxAmaroks = 3;
                maxMaelstroms = 1;
                maxPitRooms = 1;
                break;
            case GameSize.Medium:
                (rows, columns) = (20, 60);
                maxAmaroks = 5;
                maxMaelstroms = 2;
                maxPitRooms = 6;
                break;
            case GameSize.Large:
                (rows, columns) = (25, 75);
                maxAmaroks = 8;
                maxMaelstroms = 3;
                maxPitRooms = 8;
                break;
            default:
                (rows, columns) = (15, 45);
                maxAmaroks = 3;
                maxMaelstroms = 1;
                maxPitRooms = 1;
                break;
        }

        MainRoom = new MainRoom(rows, columns);
        FountainRoom = new FountainRoom(rows, columns, 5, 4);
        PitRooms = new List<PitRoom>();
        for (var i = 0; i < maxPitRooms; i++)
            PitRooms.Add(new PitRoom(rows, columns, rndRow.Next(rows), rndCol.Next(columns)));
        Maelstroms = new List<Maelstrom>();
        for (var i = 0; i < maxMaelstroms; i++)
            Maelstroms.Add(new Maelstrom(rows, columns, rndRow.Next(rows), rndCol.Next(columns)));
        Amaroks = new List<Amarok>();
        for (var i = 0; i < maxAmaroks; i++)
            Amaroks.Add(new Amarok(rows, columns, rndRow.Next(rows), rndCol.Next(columns)));
    }

    internal void Run()
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
            Console.WriteLine(
                $"shoot status: {_dasPlayer.Control.IsShoot} and {_dasPlayer.Control.Bow.Ammo} arrows");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(messages);
            Console.ResetColor();

            _dasPlayer.Move();
            Console.Clear();
            counter++;
        }
    }


    private enum GameSize
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
}