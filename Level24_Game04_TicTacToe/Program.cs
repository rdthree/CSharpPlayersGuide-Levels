using Microsoft.VisualBasic;

var game = new Game();
game.Run();

internal class Game
{
    // ticTacToe
    private TicTacToe _ticTacToe;
    private GameState _gameState;
    private Player _player1;
    private Player _player2;

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
        while (true)
        {
            Console.WriteLine($"Player One, choose a tile:");
            _ticTacToe.PlayerMoveIndex(_player1);
            _ticTacToe.Board();
            _gameState.WinConditions();

            Console.WriteLine($"Player Two, choose a tile:");
            _ticTacToe.PlayerMoveIndex(_player2);
            _ticTacToe.Board();
            _gameState.WinConditions();
        }
    }
}

internal class TicTacToe
{
    // game board
    public string[] Squares { get; private set; } = new string[9];
    // locations 1-9
    // compare current selected
    // best out of 5

    internal TicTacToe()
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
            };
        }
    }
}

internal class GameState
{
    private TicTacToe _ticTacToe;
    public int XWin { get; private set; }
    public int YWin { get; private set; }

    internal GameState(TicTacToe ticTacToe)
    {
        _ticTacToe = ticTacToe;
    }

    internal bool WinConditions()
    {
        var xWins = "X wins";
        var yWins = "X wins";
        var vert = 0;
        var horiz = 0;
        var diag = 0;

        // horiz
        for (int i = 0; i < 7; i++)
        {
            if (0 % 3 == 0)
            {
                if (_ticTacToe.Squares[i] == _ticTacToe.Squares[i + 1] &&
                    _ticTacToe.Squares[i + 1] == _ticTacToe.Squares[i + 2])
                {
                    whoWon(i);
                    //Console.WriteLine($"{_ticTacToe.Squares[i]}, {_ticTacToe.Squares[i+1]}, {_ticTacToe.Squares[i+2]}");
                    return true;
                }
            }
        }

        //vert
        for (int i = 0; i < 3; i++)
        {
            if (_ticTacToe.Squares[i] == _ticTacToe.Squares[i + 3] &&
                _ticTacToe.Squares[i + 3] == _ticTacToe.Squares[i + 6])
            {
                whoWon(i);
                return true;
            }
        }

        //diag
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                if (_ticTacToe.Squares[i] == _ticTacToe.Squares[i + 4] &&
                    _ticTacToe.Squares[i + 4] == _ticTacToe.Squares[i + 8])
                {
                    whoWon(i);
                    return true;
                }
            }

            if (i == 2)
            {
                if (_ticTacToe.Squares[i] == _ticTacToe.Squares[i + 2] &&
                    _ticTacToe.Squares[i + 2] == _ticTacToe.Squares[i + 4])
                {
                    whoWon(i);
                    return true;
                }
            }
        }

        return false;
    }
    // win / lose / cat

    private void whoWon(int i)
    {
        if (_ticTacToe.Squares[i] == "-") return;
        if (_ticTacToe.Squares[i] == "X")
        {
            Console.WriteLine("X Wins");
            XWin++;
        }
        else
        {
            Console.WriteLine("Y Wins");
            YWin++;
        }
    }
}

internal class Player
{
    public XO Mark { get; private set; }

    public int Move { get; private set; }

    // player one or two
    // make a choice 1-9
    // wins
    // losses
    // CAT
    internal Player(XO xo)
    {
        Mark = xo;
    }

    internal int MakeMove()
    {
        Console.WriteLine("select an available tile from 1 - 9");
        Move = Int32.Parse(Console.ReadLine());
        Move--;
        if (Move > 8) MakeMove();
        return Move;
    }
}

enum XO
{
    X,
    O
}