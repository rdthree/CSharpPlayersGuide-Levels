using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.Rooms;

internal class Amarok : SubRoom
{
    public Amarok(int rows, int columns, int rowOffset, int colOffset) : base(rows, columns, rowOffset, colOffset)
    {
        Location = new IMainRoom.Coordinate(Rows - rowOffset, Columns - colOffset);
        CenterColor = ConsoleColor.Red;
        EdgeColor = ConsoleColor.DarkRed;
        FieldColor = ConsoleColor.Magenta;
        CenterSymbol = 'A';
        EdgeSymbol = '!';
        FieldSymbol = 'x';
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, 1, 1, FieldCoordList);
        base.BuildSenseCoordinates(i,j);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> senseCoordList)
    {
        
        if (senseCoordList == CenterCoordList) return SenseTypes.Amarok;
        if (senseCoordList == EdgeCoordList) return SenseTypes.Alert;
        return senseCoordList == FieldCoordList ? SenseTypes.Chill : SenseTypes.Nothing;
    }
}