namespace Martian_Robots_George_Greyling_Assessment.Domain.Robots.Actions;

internal sealed class MoveForward : IRobotActionStrategy
{
    public char SupportedKey => 'F';
    public string Description =>
        "Moves the robot forward one grid point without changing its orientation. " +
        "When facing north, it moves from (x, y) to (x, y + 1).";

    public string RobotAction(string action)
    {
        return action;
    }
}
