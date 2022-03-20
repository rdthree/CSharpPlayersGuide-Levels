var game = new Game();
game.Run();

internal class Game
{
    // ticTacToe
    private readonly TicTacToe _ticTacToe;
    private readonly GameState _gameState;
    private readonly Player _player1;
    private readonly Player _player2;

    // state
    // ui stats
    // run loop
    internal Game()
    {
        _ticTacToe = new TicTacToe();
        _player1 = new Player(XO.X);
        _player2 = new Player(XO.O);
        _gameState = new GameState(_ticTacToe);
    }

    public void Run()
    {
        while ((_gameState.XWin + _gameState.YWin + _gameState.Cat) < 5)
        {
            Stats();
            Console.WriteLine($"Player One, choose a tile:");
            _ticTacToe.PlayerMoveIndex(_player1);
            _ticTacToe.Board();
            _gameState.WinConditions();

            Stats();
            Console.WriteLine($"Player Two, choose a tile:");
            _ticTacToe.PlayerMoveIndex(_player2);
            _ticTacToe.Board();
            _gameState.WinConditions();
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Stats();
        Console.ResetColor();
        _gameState.EndGame();
    }

    public void Stats()
    {
        Console.WriteLine(
            $"Best out of 5. X:{_gameState.XWin}, Y:{_gameState.YWin}," +
            $" CAT:{_gameState.Cat}, Remaining Moves: {9 - _gameState.CatCounter} ");
    }
}

internal class TicTacToe
{
    public string[] Squares { get; private set; } = new string[9];

    internal TicTacToe()
    {
        Reset();
    }

    internal void Board()
    {
        var indexer = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(Squares[indexer]);
                indexer++;
            }

            Console.WriteLine();
        }
    }

    internal void PlayerMoveIndex(Player player)
    {
        var move = player.MakeMove();
        if (Squares[move] != "-")
        {
            Console.WriteLine("that's already taken");
            PlayerMoveIndex(player);
        }

        // a little safeguard to an incorrect move doesn't overwrite the previous move
        if (Squares[move] == "-")
        {
            Squares[move] = player.Mark switch
            {
                XO.X => "X",
                XO.O => "O",
                _ => "!"
            };
        }
    }

    internal void Reset()
    {
        var indexer = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Squares[indexer] = "-";
                indexer++;
            }
        }
    }
}

internal class GameState
{
    private readonly TicTacToe _ticTacToe;
    public int XWin { get; private set; }
    public int YWin { get; private set; }
    public int Cat { get; private set; }
    public int CatCounter { get; private set; }
    internal GameState(TicTacToe ticTacToe) => _ticTacToe = ticTacToe;

    internal bool WinConditions()
    {
        // cat game
        CatCounter = 0;
        foreach (var square in _ticTacToe.Squares)
            if (square != "-")
                CatCounter++;
        if (CatCounter == 9)
        {
            Cat++;
            _ticTacToe.Reset();
            return true;
        }

        // horizontal win
        for (int i = 0; i < 7; i++)
        {
            if (i % 3 == 0)
            {
                if (_ticTacToe.Squares[i] == _ticTacToe.Squares[i + 1] &&
                    _ticTacToe.Squares[i + 1] == _ticTacToe.Squares[i + 2])
                {
                    WhoWon(i);
                    //Console.WriteLine("horizontal win");
                    return true;
                }
            }
        }

        //vertical win
        for (int i = 0; i < 3; i++)
        {
            if (_ticTacToe.Squares[i] == _ticTacToe.Squares[i + 3] &&
                _ticTacToe.Squares[i + 3] == _ticTacToe.Squares[i + 6])
            {
                WhoWon(i);
                //Console.WriteLine("vertical win");
                return true;
            }
        }

        //diagonal win
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                if (_ticTacToe.Squares[i] == _ticTacToe.Squares[i + 4] &&
                    _ticTacToe.Squares[i + 4] == _ticTacToe.Squares[i + 8])
                {
                    WhoWon(i);
                    //Console.WriteLine("diagonal win");
                    return true;
                }
            }

            if (i == 2)
            {
                if (_ticTacToe.Squares[i] == _ticTacToe.Squares[i + 2] &&
                    _ticTacToe.Squares[i + 2] == _ticTacToe.Squares[i + 4])
                {
                    WhoWon(i);
                    //Console.WriteLine("diagonal win");
                    return true;
                }
            }
        }

        return false;
    }

    private void WhoWon(int i)
    {
        if (_ticTacToe.Squares[i] == "-") return;
        if (_ticTacToe.Squares[i] == "X")
        {
            Console.WriteLine("X Wins");
            XWin++;
            _ticTacToe.Reset();
        }
        else
        {
            Console.WriteLine("Y Wins");
            YWin++;
            _ticTacToe.Reset();
        }
    }

    internal void EndGame()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (XWin > YWin) Console.WriteLine("X Wins Game");
        else if (XWin < YWin) Console.WriteLine("Y Wins Game");
        else if (XWin == YWin) Console.WriteLine("Tie Game");
    }
}

internal class Player
{
    public XO Mark { get; private set; }
    private int Move { get; set; }
    internal Player(XO xo) => Mark = xo;

    internal int MakeMove()
    {
        Console.WriteLine("choose an available tile from 1 - 9");
        if (!int.TryParse(Console.ReadLine(), out var move)) MakeMove();
        Move = move - 1;
        if (move is > 9 or < 1) MakeMove();
        return Move;
    }
}

// ReSharper disable once InconsistentNaming
internal enum XO
{
    X,
    O
}