namespace Level27_Interfaces_RoboticInterface;

public class Game
{
    private readonly Robot _robot;
    public Game() => _robot = new Robot();

    public void Play()
    {
        //Console.ForegroundColor = ConsoleColor.Red;
        //Console.WriteLine($"You have a total of {_robot.Commands.Count} moves.");
        //Console.ForegroundColor = ConsoleColor.Blue;
        //Console.WriteLine("WASD controls | X: on | Z: off");
        //Console.ResetColor();

        var quit = false;
        while (!quit)
        {
            Console.WriteLine("q to quit, any other key to continue");
            var kq = Console.ReadKey(true).KeyChar;
            if (kq == 'q') quit = true;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("WASD controls | X: on | Z: off");
            Console.ResetColor();
            //for (var i = 0; i < _robot.Commands.Count; i++)
            //{
            Console.Write("input key: ");
            var k = Console.ReadKey().KeyChar;
            Console.WriteLine();

            IRobotCommand? command = k switch
            {
                'z' => new OffCommand(),
                'x' => new OnCommand(),
                'w' => new NorthCommand(),
                's' => new SouthCommand(),
                'a' => new WestCommand(),
                'd' => new EastCommand(),
                _ => null
            };
            _robot.Commands.Add(command);
            //}
        }

        _robot.Run();
    }

    public void RunGame() => _robot.Run();
}