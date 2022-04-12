namespace Level27_Interfaces_RoboticInterface;

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }

    public bool IsPowered { get; set; }

    internal List<IRobotCommand?> Commands { get; }

    public Robot()
    {
        Commands = new List<IRobotCommand?>();
    }

    public void Run()
    {
        foreach (var command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}