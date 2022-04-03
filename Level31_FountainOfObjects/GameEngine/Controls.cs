namespace Level31_FountainOfObjects.GameEngine;

internal class Controls : IControls
{
    public HeadingTypes Direction { get; private set; } = HeadingTypes.None;
    public bool IsShoot { get; private set; }
    public bool ShowMap { get; private set; }

    public HeadingTypes Go()
    {
        Shoot(false);
        Console.WriteLine("Direction (WASD) | Shoot (X) | Map (M)");
        Console.Write("Input Direction (WASD): ");
        var k = Console.ReadKey().KeyChar;
        k = char.ToLower(k);
        Console.WriteLine();
        Direction = k switch
        {
            'w' => North(),
            's' => South(),
            'a' => West(),
            'd' => East(),
            'x' => Shoot(true),
            'm' => Map(!ShowMap),
                _ => None()
        };
        return Direction;
    }

    public HeadingTypes Shoot(bool isShoot)
    {
        IsShoot = isShoot;
        return Direction = HeadingTypes.None;
    }

    public HeadingTypes Map(bool showMap)
    {
        ShowMap = showMap;
        return Direction = HeadingTypes.None;
    }

    private HeadingTypes North() => Direction = HeadingTypes.North;
    private HeadingTypes South() => Direction = HeadingTypes.South;
    private HeadingTypes West() => Direction = HeadingTypes.West;
    private HeadingTypes East() => Direction = HeadingTypes.East;
    private HeadingTypes None() => Direction = HeadingTypes.None;
}