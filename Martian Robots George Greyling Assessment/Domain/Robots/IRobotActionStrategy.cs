namespace Martian_Robots_George_Greyling_Assessment.Domain.Robots;

internal interface IRobotActionStrategy
{
    char SupportedKey { get; }
    string Description { get; }

    string RobotAction(string action);
}
