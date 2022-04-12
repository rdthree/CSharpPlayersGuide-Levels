namespace Level27_Interfaces_RoboticInterface;

internal class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}