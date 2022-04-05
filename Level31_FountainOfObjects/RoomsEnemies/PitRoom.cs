using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class PitRoom : SubRoom
{
    public PitRoom(int rows, int columns, int rowOffset, int colOffset) : base(rows, columns, rowOffset, colOffset)
    {
        Location = new IMainRoom.Coordinate(Rows - rowOffset, Columns - colOffset);
        LocateSenses();
        IsOn = true;
        ItemColor = ConsoleColor.Green;
        EdgeColor = ConsoleColor.DarkGreen;
        FieldColor = ConsoleColor.DarkCyan;
        ItemSymbol = 'P';
        EdgeSymbol = '%';
        FieldSymbol = 's';
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 2, 2, EdgeCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate>? coordList)
    {
        SenseTypes senseType;
        if (coordList == new List<IMainRoom.Coordinate?>() { Location }) senseType = SenseTypes.End;
        else if (coordList == EdgeCoords) senseType = SenseTypes.Chill;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}