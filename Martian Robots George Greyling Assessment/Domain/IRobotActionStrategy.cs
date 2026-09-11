using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Domain
{
    public interface IRobotActionStrategy
    {
        public List<string> SuportedActions(string action);          
    }
}
