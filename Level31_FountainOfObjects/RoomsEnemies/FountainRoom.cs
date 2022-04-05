using Level31_FountainOfObjects.GameEngine;

namespace Level31_FountainOfObjects.RoomsEnemies;

internal class FountainRoom : SubRoom
{
    public FountainRoom(int rows, int columns, int rowOffset, int colOffset) : base(rows, columns, rowOffset, colOffset)
    {
        Location = new IMainRoom.Coordinate(Rows - rowOffset, Columns - colOffset);
        LocateSenses();
        IsOn = true;
        ItemColor = ConsoleColor.Cyan;
        EdgeColor = ConsoleColor.Blue;
        FieldColor = ConsoleColor.DarkBlue;
        OuterFieldColor = ConsoleColor.DarkCyan;
        ItemSymbol = 'F';
        EdgeSymbol = '~';
        FieldSymbol = '-';
        OuterFieldSymbol = '*';
    }

    protected override void BuildSenseCoordinates(int i, int j)
    {
        SenseCoordinate(i, j, Location, 3, 3, FieldCoords);
        SenseCoordinate(i, j, Location, 5, 5, OuterFieldCoords);
    }

    protected override SenseTypes SenseTypeSelector(List<IMainRoom.Coordinate>? coordList)
    {
        SenseTypes senseType;
        if (coordList == OuterFieldCoords) senseType = SenseTypes.Hear;
        else if (coordList == EdgeCoords) senseType = SenseTypes.See;
        else if (coordList == FieldCoords) senseType = SenseTypes.Smell;
        else if (coordList == ItemCoords) senseType = SenseTypes.Fountain;
        else senseType = SenseTypes.Nothing;
        return senseType;
    }
}