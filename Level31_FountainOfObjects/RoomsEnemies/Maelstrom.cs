using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class Maelstrom : SubRoom
{
    public Maelstrom(int rows, int columns, int rowOffset, int colOffset) : base(rows, columns, rowOffset, colOffset)
    {
        Location = new IMainRoom.Coordinate(Rows - rowOffset, Columns - colOffset);
        LocateSenses();
        IsOn = true;
        ItemColor = ConsoleColor.Gray;
        EdgeColor = ConsoleColor.DarkGray;
        FieldColor = ConsoleColor.DarkGray;
        ItemSymbol = 'M';
        EdgeSymbol = '>';
        FieldSymbol = '/';
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 4, 4, FieldCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate>? coordList)
    {
        SenseTypes senseType;
        if (coordList == ItemCoords) senseType = SenseTypes.Blown;
        else if (coordList == FieldCoords) senseType = SenseTypes.Chill;
        else if (coordList == EdgeCoords) senseType = SenseTypes.Alert;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}