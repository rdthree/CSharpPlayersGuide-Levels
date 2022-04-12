namespace Level27_Interfaces_RoboticInterface;

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}