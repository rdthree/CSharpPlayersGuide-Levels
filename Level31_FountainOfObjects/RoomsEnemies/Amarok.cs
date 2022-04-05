using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class Amarok : SubRoom
{
    public Amarok(int rows, int columns, int rowOffset, int colOffset) : base(rows, columns, rowOffset, colOffset)
    {
        Location = new IMainRoom.Coordinate(Rows - rowOffset, Columns - colOffset);
        LocateSenses();
        IsOn = true;
        ItemColor = ConsoleColor.Red;
        EdgeColor = ConsoleColor.DarkRed;
        FieldColor = ConsoleColor.Magenta;
        ItemSymbol = 'A';
        EdgeSymbol = '!';
        FieldSymbol = 'x';
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 1, 1, FieldCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate>? coordList)
    {
        SenseTypes senseType;
        if (coordList == ItemCoords) senseType = SenseTypes.Amarok;
        else if (coordList == EdgeCoords) senseType = SenseTypes.Alert;
        else if (coordList == FieldCoords) senseType = SenseTypes.Chill;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}