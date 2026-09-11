using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    internal class Robot : IRobotActionStrategy
    {
        private string Name = string.Empty;
        private int CordinateY = new();
        private int CordinateX = new();
        private string Orientation = string.Empty;

        public List<string> SuportedActions(string action)
        {
            return new List<string> { action };
        }

        internal Robot(string Name)
        {
            this.Name = Name;
            this.Orientation = "N";
        }

        internal static class Factory
        {

            public static Robot CreateRobot(string name)
            {   
                 
                return new Robot(name);
            }
        }
    }
}
