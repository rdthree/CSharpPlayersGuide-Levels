using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.Rooms;

internal class Amarok : SubRoom, IShootable
{
    public Amarok(int row, int column, int rowOffset, int colOffset) : base(row, column, rowOffset, colOffset)
    {
        Location = new Coordinate(Row - rowOffset, Column - colOffset);
        CenterColor = ConsoleColor.Red;
        EdgeColor = ConsoleColor.DarkRed;
        FieldColor = ConsoleColor.Magenta;
        CenterSymbol = 'A';
        EdgeSymbol = '!';
        FieldSymbol = 'x';

        IsShootable = true;
        BoundaryCoords = new Coordinate(1, 1);
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, BoundaryCoords.Row, BoundaryCoords.Column, FieldCoordList);
        base.BuildSenseCoordinates(i, j);
    }

    protected override SenseTypes SenseTypeSelector(List<Coordinate> senseCoordList)
    {
        if (senseCoordList == CenterCoordList) return SenseTypes.Amarok;
        if (senseCoordList == EdgeCoordList) return SenseTypes.Alert;
        return senseCoordList == FieldCoordList ? SenseTypes.Chill : SenseTypes.Nothing;
    }

    public bool IsShootable { get; }
}