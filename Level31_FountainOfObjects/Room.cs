namespace Level31_FountainOfObjects;

internal class Room : IRoom
{
    public Room(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _fountainRow = Rows - 2;
        _fountainColumn = Columns - 1;

        Places = new Sense[Rows, Columns];

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
                Places[i, j] = Sense.Nothing;
        }
    }

    public int Rows { get; }
    public int Columns { get; }
    public Sense[,] Places { get; }

    private readonly int _fountainRow;
    private readonly int _fountainColumn;

    public void Entrance()
    {
    }

    public void FountainRoom()
    {
        Places[_fountainRow, _fountainColumn] = Sense.See;
    }

    public void SenseRoom()
    {
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var checkI = Math.Abs(_fountainRow - i);
                var checkJ = Math.Abs(_fountainRow - j);
                if (checkI <= 5 && checkJ <= 5) Places[i, j] = Sense.Hear;
                if (checkI <= 3 && checkJ <= 3) Places[i, j] = Sense.Smell;
                if (i == _fountainRow && j == _fountainColumn) Places[i, j] = Sense.See;
            }
        }
    }

    public void RoomSize()
    {
    }
}