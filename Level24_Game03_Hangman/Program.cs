// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;

var guessWords = new List<string>() { "test", "password", "hangman", "boring" };

var game = new Game(guessWords);
game.Run();

internal class Game
{
    private Hangman _hangman;
    private GameState _gameState;
    private Player _player;

    internal Game(List<string> words)
    {
        _hangman = new Hangman(words);
        _player = new Player();
    }

    internal void Run()
    {
        while (true)
        {
            // setup
            Console.WriteLine($"guess the word, it has {_hangman._wordProgress.Length}: words.  " +
                              $"You have {_hangman.MaxGuesses} guesses.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{_hangman._wordProgress}\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("guess a letter:");

            // input
            var c = _player.InputChar();

            // checking logic
            Console.ResetColor();
            if (_hangman.WordChecker(c))
            {
                Console.WriteLine($"{_hangman._wordProgress}\n");
            }
            else
            {
                Console.WriteLine($"guess again");
            }

            if (_gameState.WinLose) continue;
            else break;
        }
    }
}

internal class Hangman
{
    private List<string> Words { get; set; }
    private readonly string? _word;
    public int MaxGuesses { get; } = 20;
    public int CorrectGuess { get; private set; }
    internal string? _wordProgress { get; set; }

    private char[] _wordChars;

    private char[] _wordProgressChars;

    internal Hangman(List<string> words)
    {
        Words = words;
        var rnd = new Random();
        _word = Words[rnd.Next(Words.Count)];
        _wordProgress = new string('_', _word.Length);
        _wordProgressChars = _wordProgress.ToCharArray();

        // char array
        _wordChars = new char[_word.Length];
        for (int i = 0; i < _word.Length; i++)
        {
            _wordChars[i] = _word[i];
        }
    }

    internal bool WordChecker(char c)
    {
        if (_word.Contains(c))
        {
            for (int i = 0; i < _word.Length; i++)
            {
                if (_word[i] == c)
                    _wordProgressChars[i] = c;

                _wordProgress = new string(_wordProgressChars);
            }

            CorrectGuess++;
            return true;
        }

        return false;
    }
}

internal class GameState
{
    private Hangman _hangman;
    private Player _player;
    public bool WinLose { get; private set; }
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
        foreach (char c in _hangman._wordProgress)
        {
            if (c == '_') LettersRemaining++;
        }

        CorrectGuesses = _hangman.CorrectGuess;
        WrongGuesses = Guesses - CorrectGuesses;

        if (Guesses > _hangman.MaxGuesses) WinLose = false;
        else if (LettersRemaining == 0) WinLose = true;
    }
}

internal class Player
{
    public char C { get; private set; }

    // total losses
    // total wins
    internal Player()
    {
    }

    public char InputChar()
    {
        C = Console.ReadKey().KeyChar;
        Console.WriteLine();
        return C;
    }
}