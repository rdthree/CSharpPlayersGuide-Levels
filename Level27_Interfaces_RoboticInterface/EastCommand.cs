namespace Level27_Interfaces_RoboticInterface;

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X++;
    }
}