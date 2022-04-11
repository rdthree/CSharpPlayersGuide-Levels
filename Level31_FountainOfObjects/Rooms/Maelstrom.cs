using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.Rooms;

internal class Maelstrom : SubRoom
{
    public Maelstrom(int row, int column, int rowOffset, int colOffset) : base(row, column, rowOffset, colOffset)
    {
        Location = new Coordinate(Row - rowOffset, Column - colOffset);
        CenterColor = ConsoleColor.White;
        EdgeColor = ConsoleColor.Gray;
        FieldColor = ConsoleColor.DarkGray;
        OuterFieldColor = ConsoleColor.DarkYellow;
        CenterSymbol = 'M';
        EdgeSymbol = '>';
        FieldSymbol = '/';
        OuterFieldSymbol = '\\';

        BoundaryCoords = new Coordinate(4, 4);
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, BoundaryCoords.Row, BoundaryCoords.Column, OuterFieldCoordList);
        SenseCoordinate(i, j, 3, 3, FieldCoordList);
        base.BuildSenseCoordinates(i, j);
    }

    protected override SenseTypes SenseTypeSelector(List<Coordinate> senseCoordList)
    {
        if (senseCoordList == CenterCoordList) return SenseTypes.Blown;
        if (senseCoordList == EdgeCoordList) return SenseTypes.Alert;
        if (senseCoordList == FieldCoordList) return SenseTypes.Chill;
        return senseCoordList == OuterFieldCoordList ? SenseTypes.ChangedGround : SenseTypes.Nothing;
    }
}