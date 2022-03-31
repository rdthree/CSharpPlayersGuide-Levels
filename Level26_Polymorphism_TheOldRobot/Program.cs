var game = new Game(9);
game.Play();

public class Game
{
    private readonly Robot _robot;

    public Game(int n = 3)
    {
        _robot = new Robot(n);
    }

    public void Play()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"You have a total of {_robot.Commands.Length} moves.");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("WASD controls | X: on | Z: off");
        Console.ResetColor();
        for (var i = 0; i < _robot.Commands.Length; i++)
        {
            Console.Write("input key: ");
            var k = Console.ReadKey().KeyChar;
            Console.WriteLine();
            
            RobotCommand? command = k switch
            {
                'z' => new OffCommand(),
                'x' => new OnCommand(),
                'w' => new NorthCommand(),
                's' => new SouthCommand(),
                'a' => new WestCommand(),
                'd' => new EastCommand(),
                _ => null
            };
            _robot.Commands[i] = command;
        }
        _robot.Run();

    }

    public void RunGame() => _robot.Run();
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; }

    public Robot(int n = 3)
    {
        Commands = new RobotCommand[n];
    }

    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public Robot? Robot { get; set; }
    public bool IsPowered { get; set; }
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = true;
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = false;
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y++;
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y--;
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X--;
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X++;
    }
}