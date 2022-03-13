// See https://aka.ms/new-console-template for more information

//var dude = new Player();
//dude.Choose();

var go = new RockPaperScissorsGame(10);
go.Play();


// player one: choose
// player two: choose
// game engine: result
// dashboard : stats


internal class RockPaperScissorsGame
{
    private int Round { get; set; }
    private readonly int _maxRounds;
    private readonly Player _playerOne;
    private readonly Player _playerTwo;

    internal RockPaperScissorsGame(int maxRounds)
    {
        _maxRounds = maxRounds;
        Console.WriteLine("Player 1");
        _playerOne = new Player();
        Console.WriteLine("Player 2");
        _playerTwo = new Player();
    }

    public void Play()
    {
        Console.WriteLine($"Best out of {_maxRounds} Rounds");
        while (Round < 10)
        {
            PlayRound();
            Stats();
        }

        FinalStats();
    }

    private void PlayRound()
    {
        _playerOne.Choose();
        _playerTwo.Choose();

        RoundResults();

        Round++;
    }

    private void RoundResults()
    {
        if (_playerOne.Choice != _playerTwo.Choice)
        {
            if (_playerOne.Choice == RockPaperScissors.Rock & _playerTwo.Choice == RockPaperScissors.Scissors)
                _playerOne.WinRound = true;
            else if (_playerOne.Choice == RockPaperScissors.Scissors & _playerTwo.Choice == RockPaperScissors.Paper)
                _playerOne.WinRound = true;
            else if (_playerOne.Choice == RockPaperScissors.Paper & _playerTwo.Choice == RockPaperScissors.Rock)
                _playerOne.WinRound = true;
            else _playerTwo.WinRound = true;

            WinLose();
        }

        if (_playerOne.Choice != _playerTwo.Choice) return;
        _playerOne.Draws++;
        _playerTwo.Draws++;
    }

    private void WinLose()
    {
        if (_playerOne.WinRound)
        {
            _playerOne.Wins++;
            _playerTwo.WinRound = false;
            _playerTwo.Losses++;
        }
        else if (_playerTwo.WinRound)
        {
            _playerTwo.Wins++;
            _playerOne.WinRound = false;
            _playerOne.Losses++;
        }
    }

    private void FinalStats()
    {
        Console.WriteLine("__________________________");

        if (_playerOne.Wins == _playerTwo.Wins)
            Console.WriteLine("ITS A DRAW");
        else if (_playerOne.Wins > _playerTwo.Wins)
            Console.WriteLine($"{_playerOne.Name} WINS BY {_playerOne.Wins - _playerTwo.Wins} POINTS");
        if (_playerOne.Wins < _playerTwo.Wins)
            Console.WriteLine($"{_playerTwo.Name} WINS BY {_playerTwo.Wins - _playerOne.Wins} POINTS");
    }

    private void Stats()
    {
        Console.WriteLine($"Rounds: {Round}");
        Console.WriteLine($"Draws: {_playerOne.Draws}");
        Console.WriteLine("__________________________");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{_playerOne.Name}");
        Console.WriteLine($"Wins: {_playerOne.Wins}");
        Console.WriteLine($"Losses: {_playerOne.Losses}");
        Console.ResetColor();
        Console.WriteLine("__________________________");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{_playerTwo.Name}");
        Console.WriteLine($"Wins: {_playerTwo.Wins}");
        Console.WriteLine($"Losses: {_playerTwo.Losses}");
        Console.ResetColor();
    }
}

internal class Player
{
    public string? Name { get; init; }
    public int Wins { get; internal set; }
    public bool WinRound { get; internal set; }
    public int Losses { get; internal set; }
    public int Draws { get; internal set; }
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
        string? input = Console.ReadLine();
        Choice = input switch
        {
            "r" => RockPaperScissors.Rock,
            "p" => RockPaperScissors.Paper,
            "s" => RockPaperScissors.Scissors,
            _ => throw new ArgumentOutOfRangeException()
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