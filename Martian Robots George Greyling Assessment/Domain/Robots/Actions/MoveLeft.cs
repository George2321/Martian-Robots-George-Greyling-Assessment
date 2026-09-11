namespace Martian_Robots_George_Greyling_Assessment.Domain.Robots.Actions;

internal sealed class MoveLeft : IRobotActionStrategy
{
    public char SupportedKey => 'L';
    public string Description =>
        "Turns the robot left 90 degrees and keeps it on its current grid point.";

    public string RobotAction(string action)
    {
        return action;
    }
}
