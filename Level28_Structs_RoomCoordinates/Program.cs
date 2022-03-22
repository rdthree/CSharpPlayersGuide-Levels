/* Struct Coordinate, room coordinate with a row and a column
 Coordinate must be immutable
 Method to determine if one coordinate is adjacent to another
 Create a few coordinates and test if the struct works
*/

var pt1 = new Coordinate(3, 4);
var pt2 = new Coordinate(4, 6);
var pt3 = new Coordinate(15, 9);

pt1.Adjacent(pt2);
pt1.Adjacent(pt3);
pt3.Adjacent(pt2);

Coordinate.CheckAdjacent(pt1, pt2);
Coordinate.CheckAdjacent(pt1, pt3);
Coordinate.CheckAdjacent(pt3, pt2);

internal readonly struct Coordinate
{
    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    private int Row { get; }
    private int Column { get; }


    public bool Adjacent(Coordinate testCoord)
    {
        if (Math.Abs(Row - testCoord.Row) == 1 || Math.Abs(Column - testCoord.Column) == 1)
        {
            Console.WriteLine($"{true}");
            return true;
        }

        Console.WriteLine($"{false}");
        return false;
    }

    public static bool CheckAdjacent(Coordinate a, Coordinate b)
    {
        if (Math.Abs(a.Row - b.Row) == 1 || Math.Abs(a.Column - b.Column) == 1)
        {
            Console.WriteLine($"{true}");
            return true;
        }

        Console.WriteLine($"{false}");
        return false;
    }
}