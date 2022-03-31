namespace Level31_FountainOfObjects.GameEngine;

internal class Controls : IControls
{
    public HeadingTypes Direction { get; private set; } = HeadingTypes.None;
    public bool IsShoot { get; private set; }

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

    public bool Shoot()
    {
         Console.Write("x to Shoot");
         var k = Console.ReadKey().KeyChar;
         Console.WriteLine();
         IsShoot = k switch
         {
             'x' => IsShoot = true,
             _ => IsShoot = false 
         };
         return IsShoot;       
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