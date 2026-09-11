using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static Martian_Robots_George_Greyling_Assessment.Domain.Robots.IRobotActionStrategy;

namespace Martian_Robots_George_Greyling_Assessment.Domain.Robots
{
    internal class Robot
    {
        private string Name = string.Empty;
        private int CordinateY = new();
        private int CordinateX = new();
        private string Orientation = string.Empty;
        private readonly IEnumerable<IRobotActionStrategy> _actions;

        internal Robot(string Name, IEnumerable<IRobotActionStrategy> actions)
        {
            this.Name = Name;
            this.Orientation = "N";
            _actions = actions;
        }

        internal class Factory
        {
            private readonly IEnumerable<IRobotActionStrategy> _availibleRobotActions;

            public Factory(IEnumerable<IRobotActionStrategy> availableActions)
            {
                _availibleRobotActions = availableActions;
            }

            public Robot CreateRobot(string name)
            {
                var matchingActions = _availibleRobotActions;

                return new Robot(name , matchingActions);
            }
        }
    }
}
