namespace Level31_FountainOfObjects;

internal class Room : IRoom
{
    public Room(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Fountain = new IRoom.Coordinate(Rows - 2, Columns - 1);

        Places = new SenseTypes[Rows, Columns];

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
                Places[i, j] = SenseTypes.Nothing;
        }
    }

    public int Rows { get; }
    public int Columns { get; }
    public SenseTypes[,] Places { get; }
    public List<IRoom.Coordinate> Hearing { get; } = new();
    public List<IRoom.Coordinate> Smelling { get; } = new();
    public List<IRoom.Coordinate> Seeing { get; } = new();
    public List<IRoom.Coordinate> Nothing { get; } = new();

    public IRoom.Coordinate Fountain { get; }

    private List<IRoom.Coordinate> Coordinates { get; } = new();

    public void Entrance()
    {
    }

    public void FountainRoom()
    {
        throw new NotImplementedException();
    }

    public void SenseRoom()
    {
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                Coordinates.Add(new IRoom.Coordinate(i, j));
                //Places[i, j] = SenseTypes.Nothing;

                var checkI = Math.Abs(Fountain.Row - i);
                var checkJ = Math.Abs(Fountain.Column - j);
                if (checkI <= 5 && checkJ <= 5)
                {
                    Places[i, j] = SenseTypes.Hear;
                    Hearing.Add(new IRoom.Coordinate(i, j));
                }

                if (checkI <= 3 && checkJ <= 3)
                {
                    Places[i, j] = SenseTypes.Smell;
                    Smelling.Add(new IRoom.Coordinate(i, j));
                }

                if ((i == Fountain.Row + 1 && j == Fountain.Column) ||
                    (i == Fountain.Row - 1 && j == Fountain.Column) ||
                    (i == Fountain.Row && j == Fountain.Column + 1) ||
                    (i == Fountain.Row && j == Fountain.Column - 1))
                {
                    Places[i, j] = SenseTypes.See;
                    Seeing.Add(new IRoom.Coordinate(i, j));
                }

                if (i == Fountain.Row && j == Fountain.Column)
                {
                    Places[i, j] = SenseTypes.Fountain;
                }

                // else
                // {
                //     Places[i, j] = SenseTypes.Nothing;
                //     Nothing.Add(new IRoom.Coordinate(i, j));
                // }
            }
        }
    }

    public void RoomSize()
    {
    }
}