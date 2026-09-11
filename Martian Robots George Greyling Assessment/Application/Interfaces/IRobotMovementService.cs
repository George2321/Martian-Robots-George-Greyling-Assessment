using System;
using System.Collections.Generic;
using System.Text;
using Martian_Robots_George_Greyling_Assessment.Domain.Robots;

namespace Martian_Robots_George_Greyling_Assessment.Application.Interfaces
{
    internal interface IRobotMovementService
    {
        string MoveRobot(string instructionString, IRobot robot);
    }
}
