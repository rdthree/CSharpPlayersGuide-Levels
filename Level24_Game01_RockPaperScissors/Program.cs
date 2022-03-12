// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

// player one: choose
// player two: choose
// game engine: result
// dashboard : stats


internal class RockPaperScissorsGame
{
}

internal class Player
{
    private int Score { get; }

    internal RockPaperScissors Choose()
    {
        Console.Write("your choice: 'r', 'p', 's': ");
        string input = Console.ReadLine();
        RockPaperScissors choice = input switch
        {
            "r" => RockPaperScissors.Rock,
            "p" => RockPaperScissors.Paper,
            "s" => RockPaperScissors.Scissors
        };
        Console.WriteLine($"you have chosen {choice}");
        return choice;
    }
}

internal enum RockPaperScissors
{
    Rock,
    Paper,
    Scissors
}