// See https://aka.ms/new-console-template for more information

// var game = new Game();

var board = new Board();
var bui = new BoardUI(board);
Console.WriteLine($"board size: {board.Size}");
while (true)
{
    bui.BoardKey();
    bui.ShowBoard();
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

    // what row?
    // what column?
    // left/right/up/down?

    // tiles
    // matrix
    // random layout
    // movement logic
}

internal class BoardUI
{
    private readonly Board _gameBoard;
    private int _indexer;
    private readonly int[] _boardFlat;
    private readonly Random _rnd = new Random();

    internal BoardUI(Board gameBoard)
    {
        _gameBoard = gameBoard;
        _boardFlat = Enumerable.Range(0, gameBoard.GameBoard.Length).OrderBy(c => _rnd.Next()).ToArray();
    }

    public void ShowBoard()
    {
        _indexer = 0; // reset for multiple runs
        for (var i = 0; i < _gameBoard.Size; i++)
        {
            for (var j = 0; j < _gameBoard.Size; j++)
            {
                var value = _boardFlat[_indexer];
                _gameBoard.GameBoard[i, j] = value;
                var k = _gameBoard.GameBoard[i, j];
                Console.Write(value == 0 ? "   " : $"{k:00} ");
                _indexer++;
            }

            Console.WriteLine();
        }
    }

    public void SelectIndices()
    {
        Console.WriteLine(
            $"input matrix location (i,j)\nstarting index is 0, max rows or cols is {_gameBoard.Size - 1}");
        Console.Write("i: ");
        var i = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("j: ");
        var j = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine($"you have selected tile {i},{j} = {_gameBoard.GameBoard[i, j]:00}");
    }

    public void SelectTile()
    {
        // select the tile number instead of the indices
    }
    
    // currently selected is red?
    // possible moves are red?

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