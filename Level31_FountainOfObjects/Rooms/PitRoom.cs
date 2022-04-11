using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.Rooms;

internal class PitRoom : SubRoom
{
    public PitRoom(int row, int column, int rowOffset, int colOffset) : base(row, column, rowOffset, colOffset)
    {
        Location = new Coordinate(Row - rowOffset, Column - colOffset);
        CenterColor = ConsoleColor.Green;
        EdgeColor = ConsoleColor.DarkGreen;
        FieldColor = ConsoleColor.DarkCyan;
        CenterSymbol = 'P';
        EdgeSymbol = '%';
        FieldSymbol = 's';

        BoundaryCoords = new Coordinate(2, 2);
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, BoundaryCoords.Row, BoundaryCoords.Column, FieldCoordList);
        SenseCoordinate(i, j, 1, 1, EdgeCoordList);
        base.BuildSenseCoordinates(i, j);
    }

    protected override SenseTypes SenseTypeSelector(List<Coordinate> senseCoordList)
    {
        if (senseCoordList == CenterCoordList) return SenseTypes.Pit;
        if (senseCoordList == EdgeCoordList) return SenseTypes.Chill;
        return senseCoordList == FieldCoordList ? SenseTypes.ChangedGround : SenseTypes.Nothing;
    }
}