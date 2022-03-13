// See https://aka.ms/new-console-template for more information

//var dude = new Player();
//dude.Choose();

var go = new RockPaperScissorsGame(10);
go.Play();


// player one: choose
// player two: choose
// game engine: result
// dashboard : stats

internal class GameRecordTracker
{
    private readonly Player? _playerOne;
    private readonly Player? _playerTwo;
    private readonly GameRoundTracker _gameRound;

    internal GameRecordTracker(Player? playerOne, Player? playerTwo, GameRoundTracker gameRound)
    {
        _playerOne = playerOne;
        _playerTwo = playerTwo;
        _gameRound = gameRound;
    }

    internal void RoundResults()
    {
        if (_playerTwo != null && _playerOne != null && _playerOne.Choice != _playerTwo.Choice)
        {
            if (_playerOne.Choice == RockPaperScissors.Rock & _playerTwo.Choice == RockPaperScissors.Scissors)
                WhoWon(_playerOne);
            else if (_playerOne.Choice == RockPaperScissors.Scissors & _playerTwo.Choice == RockPaperScissors.Paper)
                WhoWon(_playerOne);
            else if (_playerOne.Choice == RockPaperScissors.Paper & _playerTwo.Choice == RockPaperScissors.Rock)
                WhoWon(_playerOne);
            else WhoWon(_playerTwo);

            WinLose();
            return;
        }

        if (_playerOne != null) _playerOne.Draws++;
        if (_playerTwo != null) _playerTwo.Draws++;
    }

    private void WinLose()
    {
        if (_playerTwo == null && _playerOne == null) return;
        if (_playerOne is { WinRound: true })
        {
            if (_playerTwo != null)
            {
                Console.WriteLine($"{_playerOne.Name} wins round, {_playerOne.Choice} beats {_playerTwo.Choice}!");
                _playerOne.Wins++;
                _playerTwo.WinRound = false;
                _playerTwo.Losses++;
            }
        }
        else if (_playerTwo is { WinRound: true })
        {
            Console.WriteLine($"{_playerTwo?.Name} wins round, {_playerTwo.Choice} beats {_playerOne.Choice}!");
            _playerTwo.Wins++;
            _playerOne.WinRound = false;
            _playerOne.Losses++;
        }
    }

    private void WhoWon(Player player)
    {
        if (player == _playerOne)
        {
            _playerOne.WinRound = true;
            if (_playerTwo != null) _playerTwo.WinRound = false;
        }
        else
        {
            if (_playerOne != null) _playerOne.WinRound = false;
            if (_playerTwo != null) _playerTwo.WinRound = true;
        }
    }

    internal void FinalStats()
    {
        Console.WriteLine("__________________________");

        if (_playerTwo != null && _playerOne != null && _playerOne.Wins == _playerTwo.Wins)
            Console.WriteLine("ITS A DRAW");
        else if (_playerTwo != null && _playerOne != null && _playerOne.Wins > _playerTwo.Wins)
            Console.WriteLine($"{_playerOne.Name} WINS BY {_playerOne.Wins - _playerTwo.Wins} POINTS");
        if (_playerTwo != null && _playerOne != null && _playerOne.Wins < _playerTwo.Wins)
            Console.WriteLine($"{_playerTwo.Name} WINS BY {_playerTwo.Wins - _playerOne.Wins} POINTS");
    }

    internal void Stats()
    {
        Console.WriteLine($"Rounds: {_gameRound.Round}");
        if (_playerOne != null)
        {
            Console.WriteLine($"Draws: {_playerOne.Draws}");
            Console.WriteLine("__________________________");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{_playerOne.Name}");
            Console.WriteLine($"Wins: {_playerOne.Wins}");
            Console.WriteLine($"Losses: {_playerOne.Losses}");
        }

        Console.ResetColor();
        Console.WriteLine("__________________________");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{_playerTwo?.Name}");
        if (_playerTwo != null)
        {
            Console.WriteLine($"Wins: {_playerTwo.Wins}");
            Console.WriteLine($"Losses: {_playerTwo.Losses}");
        }

        Console.ResetColor();
    }
}

internal class GameRoundTracker
{
    public int Round { get; internal set; }
    public int MaxRounds { get; }

    internal GameRoundTracker(int maxRounds)
    {
        Round = 0;
        MaxRounds = maxRounds;
    }
}

internal class RockPaperScissorsGame
{
    private GameRoundTracker GameRound { get; }
    private GameRecordTracker GameRecord { get; }
    private readonly Player? _playerOne;
    private readonly Player? _playerTwo;

    internal RockPaperScissorsGame(int maxRounds)
    {
        Console.WriteLine("Player 1");
        _playerOne = new Player();
        Console.WriteLine("Player 2");
        _playerTwo = new Player();
        GameRound = new GameRoundTracker(maxRounds);
        GameRecord = new GameRecordTracker(_playerOne, _playerTwo, GameRound);
    }

    public void Play()
    {
        Console.WriteLine($"Best out of {GameRound.MaxRounds} Rounds");
        while (GameRound.Round < 10)
        {
            PlayRound();
            GameRecord.Stats();
        }

        GameRecord.FinalStats();
    }

    private void PlayRound()
    {
        _playerOne?.Choose();
        _playerTwo?.Choose();
        GameRecord.RoundResults();
        GameRound.Round++;
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

    internal void Choose()
    {
        Console.Write($"{Name}, make a choice: 'r', 'p', 's': ");
        var input = Console.ReadLine();
        Choice = input switch
        {
            "r" => RockPaperScissors.Rock,
            "p" => RockPaperScissors.Paper,
            "s" => RockPaperScissors.Scissors,
            _ => throw new ArgumentOutOfRangeException()
        };
        Console.WriteLine($"you have chosen {Choice}");
    }
}

internal enum RockPaperScissors
{
    Rock,
    Paper,
    Scissors
}