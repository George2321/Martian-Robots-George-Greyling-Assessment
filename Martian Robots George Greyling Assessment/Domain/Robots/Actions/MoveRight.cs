namespace Martian_Robots_George_Greyling_Assessment.Domain.Robots.Actions;

internal sealed class MoveRight : IRobotActionStrategy
{
    public char SupportedKey => 'R';
    public string Description =>
        "Turns the robot right 90 degrees and keeps it on its current grid point.";

    public string RobotAction(string action)
    {
        return action;
    }
}
