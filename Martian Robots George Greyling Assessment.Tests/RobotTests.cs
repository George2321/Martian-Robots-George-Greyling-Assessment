using Martian_Robots_George_Greyling_Assessment.Application.Exceptions;
using Martian_Robots_George_Greyling_Assessment.Application.Services;
using Martian_Robots_George_Greyling_Assessment.Domain.Planets;
using Martian_Robots_George_Greyling_Assessment.Domain.Robots;
using Martian_Robots_George_Greyling_Assessment.Domain.Robots.Actions;
using Xunit;

namespace Martian_Robots_George_Greyling_Assessment.Tests;

public class RobotTests
{
    private readonly IRobotActionStrategy[] _strategies =
    [
        new MoveLeft(),
        new MoveRight(),
        new MoveForward()
    ];

    [Fact]
    public void FactoryCreatesRobotAtDefaultPositionFacingNorth()
    {
        var factory = new Robot.Factory(_strategies);

        var robot = factory.CreateRobot("Curiosity");

        Assert.Equal("Curiosity", robot.Name);
        Assert.Equal(0, robot.CoordinateX);
        Assert.Equal(0, robot.CoordinateY);
        Assert.Equal("N", robot.Orientation);
    }

    [Fact]
    public void MovementServiceRejectsUnsupportedInstruction()
    {
        var planet = new Planet("Mars", rowSize: 50, columnSize: 50);
        var factory = new Robot.Factory(_strategies);
        var robot = factory.CreateRobot("Curiosity");
        var movementService = new RobotMovementService(planet, _strategies);

        var exception = Assert.Throws<InputValidationException>(
            () => movementService.MoveRobot("LXR", robot));

        Assert.Equal(
            "Movement instructions may only contain these supported keys: L, R, F.",
            exception.Message);
    }

    [Theory]
    [InlineData("RFRFRFRF")]
    [InlineData("FRRFLLFFRRFLL")]
    [InlineData("LLFFFLFLFL")]
    public void MovementServiceAcceptsSampleMovementInstructions(string instructions)
    {
        var planet = new Planet("Mars", rowSize: 5, columnSize: 3);
        var factory = new Robot.Factory(_strategies);
        var robot = factory.CreateRobot("Sample robot");
        var movementService = new RobotMovementService(planet, _strategies);

        var acceptedInstructions = movementService.MoveRobot(instructions, robot);

        Assert.Equal(instructions, acceptedInstructions);
    }

    [Fact]
    public void SampleMovementInstructionsArePassedToRobotsInOrder()
    {
        var sampleInstructions = new[]
        {
            "RFRFRFRF",
            "FRRFLLFFRRFLL",
            "LLFFFLFLFL"
        };
        var robots = new Robot.Factory(_strategies);
        var sampleRobots = new[]
        {
            robots.CreateRobot("Robot 1"),
            robots.CreateRobot("Robot 2"),
            robots.CreateRobot("Robot 3")
        };
        var movementService = new RobotMovementService(
            new Planet("Mars", rowSize: 5, columnSize: 3),
            _strategies);

        var acceptedInstructions = sampleRobots
            .Zip(
                sampleInstructions,
                (robot, instructions) => movementService.MoveRobot(instructions, robot))
            .ToArray();

        Assert.Equal(sampleInstructions, acceptedInstructions);
    }
}
