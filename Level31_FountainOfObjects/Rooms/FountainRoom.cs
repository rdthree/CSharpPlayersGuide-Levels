using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.Rooms;

internal class FountainRoom : SubRoom
{
    public FountainRoom(int row, int column, int rowOffset, int colOffset) : base(row, column, rowOffset, colOffset)
    {
        Location = new Coordinate(Row - rowOffset, Column - colOffset);
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

    protected override SenseTypes SenseTypeSelector(List<Coordinate> senseCoordList)
    {
        if (senseCoordList == CenterCoordList) return SenseTypes.Fountain;
        if (senseCoordList == EdgeCoordList) return SenseTypes.SeeFountain;
        if (senseCoordList == FieldCoordList) return SenseTypes.SmellFountain;
        return senseCoordList == OuterFieldCoordList ? SenseTypes.HearFountain : SenseTypes.Nothing;
    }
}