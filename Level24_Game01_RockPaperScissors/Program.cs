// See https://aka.ms/new-console-template for more information

//var dude = new Player();
//dude.Choose();

var go = new RockPaperScissorsGame();

// player one: choose
// player two: choose
// game engine: result
// dashboard : stats


internal class RockPaperScissorsGame
{
    public int Round { get; private set; }

    internal RockPaperScissorsGame()
    {
        Round = 0;
        
        Console.WriteLine("Player 1");
        var player1 = new Player();
        Console.WriteLine("Player 2");
        var player2 = new Player();
    }

    WinLoseDraw Results()
    {
        
        return WinLoseDraw.Draw;
    }
}

internal class Player
{
    public string? Name { get; init; }
    public int Wins { get; private set; }
    public int Losses { get; private set; }
    public int Draws { get; private set; }
    public RockPaperScissors Choice { get; private set; }

    internal Player()
    {
        Wins = 0;
        Losses = 0;
        Draws = 0;
        
        Console.Write("input player name: ");
        Name = Console.ReadLine();
    }

    internal RockPaperScissors Choose()
    {
        Console.Write($"{Name}, make a choice: 'r', 'p', 's': ");
        string input = Console.ReadLine();
        Choice = input switch
        {
            "r" => RockPaperScissors.Rock,
            "p" => RockPaperScissors.Paper,
            "s" => RockPaperScissors.Scissors
        };
        Console.WriteLine($"you have chosen {Choice}");
        return Choice;
    }
    
    internal class Win
    {
        
    }
}

internal enum RockPaperScissors
{
    Rock,
    Paper,
    Scissors
}

internal enum WinLoseDraw
{
    Win,
    Lose,
    Draw
}