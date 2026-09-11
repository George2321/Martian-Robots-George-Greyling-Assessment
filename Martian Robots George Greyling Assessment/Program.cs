
using Martian_Robots_George_Greyling_Assessment;
using Martian_Robots_George_Greyling_Assessment.Domain.Planets;
using Martian_Robots_George_Greyling_Assessment.Domain.Robots;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddRobotInfrastructure();
services.AddSingleton<IPlanet>(new Planet("Mars", rowSize: 50, columnSize: 60));

using var serviceProvider = services.BuildServiceProvider();

var planet = serviceProvider.GetRequiredService<IPlanet>();
var robotFactory = serviceProvider.GetRequiredService<Robot.Factory>();

var robots = new[]
{
    robotFactory.CreateRobot("Curiosity"),
    robotFactory.CreateRobot("Spirit"),
    robotFactory.CreateRobot("Opportunity")
};

Console.WriteLine("Welcome to the Martian Robots universe!");
Console.WriteLine($"Created planet {planet.Name} ({planet.RowSize} x {planet.ColumnSize}).");
Console.WriteLine($"Created {robots.Length} robots: {string.Join(", ", robots.Select(robot => robot.Name))}.");
