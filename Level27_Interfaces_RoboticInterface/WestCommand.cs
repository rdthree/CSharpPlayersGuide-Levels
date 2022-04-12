namespace Level27_Interfaces_RoboticInterface;

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X--;
    }
}