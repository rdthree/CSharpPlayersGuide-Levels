using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class FountainRoom : SubRoom
{
    public FountainRoom(int rows, int columns, int rowOffset, int colOffset) : base(rows, columns, rowOffset, colOffset)
    {
        Location = new IMainRoom.Coordinate(Rows - rowOffset, Columns - colOffset);
        CenterColor = ConsoleColor.Cyan;
        EdgeColor = ConsoleColor.Blue;
        FieldColor = ConsoleColor.DarkBlue;
        OuterFieldColor = ConsoleColor.DarkCyan;
        CenterSymbol = 'F';
        EdgeSymbol = '~';
        FieldSymbol = '-';
        OuterFieldSymbol = '*';
    }
    
    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, 5, 5, OuterFieldCoordList);
        SenseCoordinate(i, j, 3, 3, FieldCoordList);
        base.BuildSenseCoordinates(i,j);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> senseCoordList)
    {
        if (senseCoordList == CenterCoordList) return SenseTypes.Fountain;
        if (senseCoordList == EdgeCoordList) return SenseTypes.SeeFountain;
        if (senseCoordList == FieldCoordList) return SenseTypes.SmellFountain;
        return senseCoordList == OuterFieldCoordList ? SenseTypes.HearFountain : SenseTypes.Nothing;
    }
}