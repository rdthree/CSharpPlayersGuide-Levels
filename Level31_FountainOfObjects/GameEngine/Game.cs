using System.Diagnostics;
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
    internal PitRoom PitRoom { get; }
    internal Maelstrom Maelstrom { get; }
    internal Amarok Amarok { get; }

    public Game(int rows, int columns)
    {
        // places and things
        MainRoom = new MainRoom(rows, columns);
        FountainRoom = new FountainRoom(rows, columns);
        PitRoom = new PitRoom(rows, columns);
        Maelstrom = new Maelstrom(rows, columns);
        Amarok = new Amarok(rows, columns);

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
                $"currently at ({_dasPlayer.RowPosition}, {_dasPlayer.ColumnPosition})");

            var messages = Messages.Senses(_dasPlayer.PlayerInteractions());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"you have made {_dasPlayer.Moves} moves, {maxMoves - _dasPlayer.Moves} remaining.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(messages);
            Console.ResetColor();

            _dasPlayer.Move();
            Console.Clear();
            counter++;
        }
    }
}