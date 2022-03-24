namespace Level31_FountainOfObjects;

internal class Controls : IControls
{
    public Go Direction { get; private set; } = Level31_FountainOfObjects.Go.None;

    public Go Go()
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

    private Go North()
    {
        Console.WriteLine("You have moved North");
        return Direction = Level31_FountainOfObjects.Go.North;
    }

    private Go South()
    {
        Console.WriteLine("You have moved South");
        return Direction = Level31_FountainOfObjects.Go.South;
    }

    private Go West()
    {
        Console.WriteLine("You have moved West");
        return Direction = Level31_FountainOfObjects.Go.West;
    }

    private Go East()
    {
        Console.WriteLine("You have moved East");
        return Direction = Level31_FountainOfObjects.Go.East;
    }

    private Go None()
    {
        Console.WriteLine("You remain motionless");
        return Direction = Level31_FountainOfObjects.Go.None;
    }
}