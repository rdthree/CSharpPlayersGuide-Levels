namespace Level31_FountainOfObjects.GameEngine;

internal class Controls : IControls
{
    public HeadingTypes Direction { get; private set; } = HeadingTypes.None;
    public bool IsShoot { get; private set; }
    public bool ShowMap { get; private set; }

    public HeadingTypes Go()
    {
        Shoot(false); // resets the shoot function
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
            'x' => Shoot(!IsShoot),
            'm' => Map(!ShowMap),
                _ => None()
        };
        return Direction;
    }

    private HeadingTypes Shoot(bool isShoot)
    {
        IsShoot = isShoot;
        return Direction;
    }

    private HeadingTypes Map(bool showMap)
    {
        ShowMap = showMap;
        return Direction;
    }

    private HeadingTypes North() => Direction = HeadingTypes.North;
    private HeadingTypes South() => Direction = HeadingTypes.South;
    private HeadingTypes West() => Direction = HeadingTypes.West;
    private HeadingTypes East() => Direction = HeadingTypes.East;
    private HeadingTypes None() => Direction = HeadingTypes.None;
}