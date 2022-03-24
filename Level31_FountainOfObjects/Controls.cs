namespace Level31_FountainOfObjects;

internal class Controls : IControls
{
    public HeadingTypes Direction { get; private set; } = HeadingTypes.None;

    public HeadingTypes Go()
    {
        Console.Write("Input Direction (WASD): ");
        var k = Console.ReadKey().KeyChar;
        Console.WriteLine();
        Direction = k switch
        {
            'w' => North(),
            's' => South(),
            'a' => West(),
            'd' => East(),
            _ => None()
        };
        return Direction;
    }

    private HeadingTypes North()
    {
        Console.WriteLine("You have moved North");
        return Direction = HeadingTypes.North;
    }

    private HeadingTypes South()
    {
        Console.WriteLine("You have moved South");
        return Direction = HeadingTypes.South;
    }

    private HeadingTypes West()
    {
        Console.WriteLine("You have moved West");
        return Direction = HeadingTypes.West;
    }

    private HeadingTypes East()
    {
        Console.WriteLine("You have moved East");
        return Direction = HeadingTypes.East;
    }

    private HeadingTypes None()
    {
        Console.WriteLine("You remain motionless");
        return Direction = HeadingTypes.None;
    }
}