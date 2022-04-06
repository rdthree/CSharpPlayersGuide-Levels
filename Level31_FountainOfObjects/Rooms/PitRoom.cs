using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.Rooms;

internal class PitRoom : SubRoom
{
    public PitRoom(int rows, int columns, int rowOffset, int colOffset) : base(rows, columns, rowOffset, colOffset)
    {
        Location = new IMainRoom.Coordinate(Rows - rowOffset, Columns - colOffset);
        CenterColor = ConsoleColor.Green;
        EdgeColor = ConsoleColor.DarkGreen;
        FieldColor = ConsoleColor.DarkCyan;
        CenterSymbol = 'P';
        EdgeSymbol = '%';
        FieldSymbol = 's';
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, 2, 2, FieldCoordList);
        SenseCoordinate(i, j, 1, 1, EdgeCoordList);
        base.BuildSenseCoordinates(i,j);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate> senseCoordList)
    {
        if (senseCoordList == CenterCoordList) return SenseTypes.Pit;
        if (senseCoordList == EdgeCoordList) return SenseTypes.Chill;
        return senseCoordList == FieldCoordList ? SenseTypes.ChangedGround : SenseTypes.Nothing;
    }
    
}