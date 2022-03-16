// See https://aka.ms/new-console-template for more information

// var game = new Game();

var board = new Board();
var bui = new BoardUI(board);
Console.WriteLine($"board size: {board.Size}");
bui.BoardKey();
bui.CorrectBoard();
bui.ShowBoard();
while (true)
{
    bui.SelectIndices();
}

internal class Game
{
    // board
    // game state
    // player
    // UI + stats

    // game loop
}

internal class Board
{
    internal int Size { get; }
    internal readonly int[,] GameBoard;

    internal Board(int size = 4)
    {
        Size = size;
        GameBoard = new int[Size, Size];
    }

    // left/right/up/down?
    // movement logic
}

internal class BoardUI
{
    private readonly Board _gameBoard;
    private readonly int _indexer;
    private readonly Random _rnd = new Random();

    internal BoardUI(Board gameBoard)
    {
        _gameBoard = gameBoard;
        var boardFlat = Enumerable.Range(1, gameBoard.GameBoard.Length).OrderBy(_ => _rnd.Next()).ToArray();
        // build 2D matrix game board with i rows and j cols
        for (var i = 0; i < _gameBoard.Size; i++)
        {
            for (var j = 0; j < _gameBoard.Size; j++)
            {
                var value = boardFlat[_indexer];
                _gameBoard.GameBoard[i, j] = value;
                _indexer++;
            }
        }
    }

    public void ShowBoard(int iSelected = default, int jSelected = default)
    {
        int iZeroIndex = default;
        int jZeroIndex = default;

        // save the indices of the tile that equals zero
        for (var i = 0; i < _gameBoard.Size; i++)
        {
            for (var j = 0; j < _gameBoard.Size; j++)
            {
                var k = _gameBoard.GameBoard[i, j];
                if (k == _gameBoard.GameBoard.Length)
                {
                    iZeroIndex = i;
                    jZeroIndex = j;
                }
            }
        }

        Console.WriteLine($"blank tile: ({iZeroIndex},{jZeroIndex})");
        var selectedTileValue = _gameBoard.GameBoard[iSelected, jSelected];
        Console.WriteLine(
            $"you have selected tile ({iSelected},{jSelected}) = {selectedTileValue:00}");

        if (Math.Abs(iSelected - iZeroIndex) == 1 && Math.Abs(jSelected - jZeroIndex) == 0 ||
            Math.Abs(iSelected - iZeroIndex) == 0 && Math.Abs(jSelected - jZeroIndex) == 1)
        {
            _gameBoard.GameBoard[iZeroIndex, jZeroIndex] = selectedTileValue;
            _gameBoard.GameBoard[iSelected, jSelected] = _gameBoard.GameBoard.Length;
            iZeroIndex = iSelected;
            jZeroIndex = jSelected;
        }

        // next the game board with selected tile in red
        for (var i = 0; i < _gameBoard.Size; i++)
        {
            for (var j = 0; j < _gameBoard.Size; j++)
            {
                var k = _gameBoard.GameBoard[i, j];

                if (Math.Abs(i - iZeroIndex) == 1 && Math.Abs(j - jZeroIndex) == 0 ||
                    Math.Abs(i - iZeroIndex) == 0 && Math.Abs(j - jZeroIndex) == 1)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                if (k == selectedTileValue)
                    Console.ForegroundColor = ConsoleColor.Red;

                //Console.Write(k == 0 ? "   " : $"{k:00} ");
                Console.Write(k == _gameBoard.GameBoard.Length ? "   " : $"{k:00} ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }

    public void SelectIndices()
    {
        Console.WriteLine(
            $"input matrix location (i,j)");
        Console.Write($"(0 to {_gameBoard.Size - 1}) i: ");
        var i = int.Parse(Console.ReadLine() ?? string.Empty);
        if (i > _gameBoard.Size - 1) i = _gameBoard.Size - 1;
        if (i < 0) i = 0;

        Console.Write($"(0 to {_gameBoard.Size - 1}) j: ");
        var j = int.Parse(Console.ReadLine() ?? string.Empty);
        if (j > _gameBoard.Size - 1) j = _gameBoard.Size - 1;
        if (j < 0) j = 0;

        ShowBoard(i, j);
        Console.WriteLine();
    }

    public void CorrectBoard()
    {
        Console.WriteLine("this is a correct game board");
        var indexer = 1;
        var correctBoard = new int[_gameBoard.Size,_gameBoard.Size];
        for (var i = 0; i < _gameBoard.Size; i++)
        {
            for (var j = 0; j < _gameBoard.Size; j++)
            {
                correctBoard[i, j] = indexer;
                var k = correctBoard[i, j];
                Console.Write(k == correctBoard.Length ? "   " : $"{k:00} ");
                indexer++;
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }


    public void BoardKey()
    {
        Console.WriteLine("(i,j) key for the game board");
        for (var i = 0; i < _gameBoard.Size; i++)
        {
            for (var j = 0; j < _gameBoard.Size; j++)
            {
                Console.Write($"{i}{j} ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}

internal class BoardState
{
    // win / restart
}

internal class Player
{
    // move logic
    // total moves
    // wins
}