using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Martian_Robots_George_Greyling_Assessment.Domain.Robots
{
    public interface IRobotActionStrategy
    {
        public string RobotAction(string action);
    }
}
