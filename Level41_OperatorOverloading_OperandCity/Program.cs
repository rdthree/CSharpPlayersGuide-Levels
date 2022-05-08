// See https://aka.ms/new-console-template for more information

Console.WriteLine(new BlockCoordinate(1,1) + Direction.East);

public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate coord, BlocKOffset offset)
    {
        return new BlockCoordinate(coord.Row + offset.RowOffset, coord.Column + offset.ColumnOffset);
    }

    public static BlockCoordinate operator +(BlockCoordinate coord, Direction direction)
    {

        return coord + direction switch // this will trigger the blockOffset + operator above
        {
            Direction.North => new BlocKOffset(+1, 0),
            Direction.East => new BlocKOffset(0, 1),
            Direction.South => new BlocKOffset(-1, 0),
            Direction.West => new BlocKOffset(0, -1),
            _ => new BlocKOffset(0, 0)
        };
    }

    //public int this[int index] => index == 0 ? Row : Column;
    public int this[int index] => index switch { 
        0 => Row,
        1 => Column,
        _ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
    };
}

public record BlocKOffset(int RowOffset, int ColumnOffset);

public enum Direction
{
    North,
    East,
    South,
    West
}