namespace Level31_FountainOfObjects;

internal class FountainRoom : MainRoom, ISubRoom
{
    public FountainRoom(int rows, int columns) : base(rows, columns)
    {
        Fountain = new IMainRoom.Coordinate(Rows - 2, Columns - 1);
        LocateSenses(Fountain);
    }

    public IMainRoom.Coordinate Fountain { get; }
    public List<IMainRoom.Coordinate> FountainCoords { get; } = new();


    protected override void ItemSenseCoordinates(int i, int j, int row, int column)
    {
        SenseCoordinateAdjacent(i, j, Fountain.Row, Fountain.Column, SeeingCoords);
    }

    protected override void AllSenseCoordinates(int i, int j, int row, int column)
    {
        SenseCoordinate(i, j, row, column, 5, 5, HearingCoords);
        SenseCoordinate(i, j, row, column, 3, 3, SmellingCoords);
        SenseCoordinate(i, j, row, column, 0, 0, FountainCoords);
    }
}