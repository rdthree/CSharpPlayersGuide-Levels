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

var pt = new ImmutableStructPoint(2, 3);
Console.WriteLine($"{pt.X},{pt.Y}");
Console.WriteLine(pt.ToString());
//pt.Y = 4;
//pt.X = 6;
pt = pt with { X = 4 };
Console.WriteLine($"{pt.X},{pt.Y}");
Console.WriteLine(pt.ToString());

var iPt = new ImmutableRecordStructPoint(3, 4);
Console.WriteLine(iPt.ToString());
//iPt.X = 5;
iPt = iPt with { X = 4 };
Console.WriteLine(iPt.ToString());

var rPt = new RecordPoint(4, 5);
Console.WriteLine(rPt.ToString());
rPt.X = 6;
rPt.Y = 8;
Console.WriteLine(rPt.ToString());

public record struct RecordPoint(float X, float Y);

public readonly record struct ImmutableRecordStructPoint(float X, float Y);

public struct ImmutableStructPoint
{
    public float X { get; init; }
    public float Y { get; init; }

    public ImmutableStructPoint(float x, float y)
    {
        X = x;
        Y = y;
    }
}
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