using Martian_Robots_George_Greyling_Assessment.Domain.Planets;

namespace Martian_Robots_George_Greyling_Assessment.Application.Services;

internal class RobotMovementService
{
    IPlanet _planet;


    public RobotMovementService(IPlanet planet)
    {
        _planet = planet;
    }

    public string MoveRobot(string instructionString)
    {
        return instructionString;
    }
}
