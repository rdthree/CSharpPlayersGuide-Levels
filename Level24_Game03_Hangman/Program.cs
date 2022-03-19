// See https://aka.ms/new-console-template for more information


var guessWords = new List<string>() { "test", "password", "hangman", "boring" };

var game = new Game(guessWords);
game.Run();

internal class Game
{
    private readonly Hangman _hangman;
    private readonly GameState _gameState;
    private readonly Player _player;

    internal Game(List<string> words)
    {
        _hangman = new Hangman(words);
        _player = new Player();
        _gameState = new GameState(_hangman, _player);
    }

    internal void Run()
    {
        while (true)
        {
            // setup
            Console.WriteLine($"Guesses: {_gameState.Guesses} |" +
                              $" Correct Guesses: {_gameState.CorrectGuesses} |" +
                              $" Incorrect Guesses: {_gameState.WrongGuesses}");
            Console.WriteLine($"Letters Remaining: {_gameState.LettersRemaining} |" +
                              $" Current Letter: {_gameState.CurrentLetter}");
            if (_hangman.WordProgress != null)
            {
                Console.WriteLine($"guess the word, it has {_hangman.WordProgress.Length}: letters.  " +
                                  $"You have {_hangman.MaxGuesses - _gameState.Guesses} guesses remaining.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{_hangman.WordProgress}\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("guess a letter:");

                // input
                var c = _player.InputChar();

                // checking logic
                Console.ResetColor();
                if (_hangman.WordChecker(c))
                {
                    Console.WriteLine($"{_hangman.WordProgress}\n");
                }
                else
                {
                    Console.WriteLine($"guess again");
                }
            }

            _gameState.WinLoseProgress();

            if (_gameState.Win)
            {
                Console.WriteLine("you win mang!");
                break;
            }
            if (_gameState.Lose)
            {
                Console.WriteLine("you lose mang!");
                break;
            }
        }
    }
}

internal class Hangman
{
    private List<string> Words { get; set; }
    private readonly string? _word;
    public int MaxGuesses { get; } = 20;
    public int CorrectGuess { get; private set; }
    internal string? WordProgress { get; set; }

    private readonly char[] _wordProgressChars;

    internal Hangman(List<string> words)
    {
        Words = words;
        var rnd = new Random();
        _word = Words[rnd.Next(Words.Count)];
        WordProgress = new string('_', _word.Length);
        _wordProgressChars = WordProgress.ToCharArray();

        // char array
        var wordChars = new char[_word.Length];
        for (int i = 0; i < _word.Length; i++)
        {
            wordChars[i] = _word[i];
        }
    }

    internal bool WordChecker(char c)
    {
        if (_word != null && _word.Contains(c))
        {
            for (int i = 0; i < _word.Length; i++)
            {
                if (_word[i] == c)
                    _wordProgressChars[i] = c;

                WordProgress = new string(_wordProgressChars);
            }

            CorrectGuess++;
            return true;
        }

        return false;
    }
}

internal class GameState
{
    private readonly Hangman _hangman;
    private readonly Player _player;
    public bool Win { get; private set; }
    public bool Lose { get; private set; }
    public int Guesses { get; private set; }
    public int CorrectGuesses { get; private set; }
    public int WrongGuesses { get; private set; }
    public int LettersRemaining { get; private set; }
    public char CurrentLetter { get; private set; }


    internal GameState(Hangman hangman, Player player)
    {
        _hangman = hangman;
        _player = player;
    }

    internal void WinLoseProgress()
    {
        Guesses++;
        CurrentLetter = _player.C;
        LettersRemaining = 0;
        if (_hangman.WordProgress != null)
            foreach (var c in _hangman.WordProgress)
            {
                if (c == '_') LettersRemaining++;
            }

        CorrectGuesses = _hangman.CorrectGuess;
        WrongGuesses = Guesses - CorrectGuesses;

        if (Guesses > _hangman.MaxGuesses) Lose = true;
        else if (LettersRemaining == 0) Win = true;
    }
}

internal class Player
{
    public char C { get; private set; }

    public char InputChar()
    {
        C = Console.ReadKey().KeyChar;
        Console.WriteLine();
        return C;
    }
}