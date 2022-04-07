using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.Rooms;

internal class Maelstrom : SubRoom
{
    public Maelstrom(int rows, int columns, int rowOffset, int colOffset) : base(rows, columns, rowOffset, colOffset)
    {
        Location = new IMainRoom.Coordinate(Rows - rowOffset, Columns - colOffset);
        CenterColor = ConsoleColor.White;
        EdgeColor = ConsoleColor.Gray;
        FieldColor = ConsoleColor.DarkGray;
        OuterFieldColor = ConsoleColor.DarkYellow;
        CenterSymbol = 'M';
        EdgeSymbol = '>';
        FieldSymbol = '/';
        OuterFieldSymbol = '\\';
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, 4, 4, OuterFieldCoordList);
        SenseCoordinate(i, j, 3, 3, FieldCoordList);
        base.BuildSenseCoordinates(i, j);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> senseCoordList)
    {
        if (senseCoordList == CenterCoordList) return SenseTypes.Blown;
        if (senseCoordList == EdgeCoordList) return SenseTypes.Alert;
        if (senseCoordList == FieldCoordList) return SenseTypes.Chill;
        return senseCoordList == OuterFieldCoordList ? SenseTypes.ChangedGround : SenseTypes.Nothing;
    }
}