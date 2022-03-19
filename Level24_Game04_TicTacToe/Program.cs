var game = new Game();
game.Run();

internal class Game
{
    // ticTacToe
    private TicTacToe _ticTacToe;
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
    }

    public void Run()
    {
        //while (true)
        //{
        Console.WriteLine($"Player One, choose a tile:");
        _ticTacToe.PlayerMoveIndex(_player1, _player1.Move, _player1.Mark);

        Console.WriteLine($"Player Two, choose a tile:");
        _ticTacToe.PlayerMoveIndex(_player1, _player2.Move, _player2.Mark);
        //run that game
        _ticTacToe.Board();
        //}
    }
}

internal class TicTacToe
{
    // game board
    private readonly string[] Squares = new string[9];
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

    internal void PlayerMoveIndex(Player player, int move, XO xo)
    {
        move = player.MakeMove();
        if (xo == XO.X)
            Squares[move] = "X";
        if (xo == XO.O)
            Squares[move] = "O";
    }
}

internal class GameState
{
    // moves remaining
    // win / lose / cat
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