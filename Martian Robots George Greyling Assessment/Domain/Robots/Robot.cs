namespace Martian_Robots_George_Greyling_Assessment.Domain.Robots;

internal sealed class Robot : IRobot
{
    private readonly IEnumerable<IRobotActionStrategy> _actions;

    private Robot(string name, IEnumerable<IRobotActionStrategy> actions)
    {
        Name = name;
        Orientation = "N";
        _actions = actions;
    }

    public string Name { get; }
    public int CoordinateY { get; private set; }
    public int CoordinateX { get; private set; }
    public string Orientation { get; private set; }

    internal sealed class Factory
    {
        private readonly IEnumerable<IRobotActionStrategy> _availableRobotActions;

        public Factory(IEnumerable<IRobotActionStrategy> availableActions)
        {
            _availableRobotActions = availableActions;
        }

        public Robot CreateRobot(string name)
        {
            return new Robot(name, _availableRobotActions);
        }
    }
}
