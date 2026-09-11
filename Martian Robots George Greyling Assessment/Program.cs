using Martian_Robots_George_Greyling_Assessment.Application.Exceptions;
using Martian_Robots_George_Greyling_Assessment.Application.Interfaces;
using Martian_Robots_George_Greyling_Assessment.DependencyInjection;
using Martian_Robots_George_Greyling_Assessment.Domain.Planets;
using Martian_Robots_George_Greyling_Assessment.Domain.Robots;
using Martian_Robots_George_Greyling_Assessment.Presentation;
using Microsoft.Extensions.DependencyInjection;

try
{
    ConsoleBanner.Show();
    Console.WriteLine();
    Console.WriteLine();

    var services = new ServiceCollection();

    // Add The planet
    services.AddPlanet(new Planet("Mars", rowSize: 50, columnSize: 60));
    services.AddRobotServices();
    services.AddApplicationServices();

    using var serviceProvider = services.BuildServiceProvider();

    var planet = serviceProvider.GetRequiredService<IPlanet>();
    var robotFactory = serviceProvider.GetRequiredService<Robot.Factory>();
    var robotMovementService = serviceProvider.GetRequiredService<IRobotMovementService>();
    var actionStrategies = serviceProvider
        .GetServices<IRobotActionStrategy>()
        .OrderBy(strategy => "LRF".IndexOf(strategy.SupportedKey))
        .ToArray();

    // Create robots using the factory
    var robots = new[]
    {
        robotFactory.CreateRobot("Curiosity"),
        robotFactory.CreateRobot("Spirit"),
        robotFactory.CreateRobot("Opportunity")
    };
    var currentRobotIndex = 0;

    Console.WriteLine("Loading .........................");
    Console.WriteLine();
    Console.WriteLine($"Created planet {planet.Name} ({planet.RowSize} x {planet.ColumnSize}).");
    Console.WriteLine($"Created {robots.Length} robots: {string.Join(", ", robots.Select(robot => robot.Name))}.");
    Console.WriteLine();
    Console.WriteLine("Supported movement instructions:");

    foreach (var strategy in actionStrategies)
    {
        Console.WriteLine($"  {strategy.SupportedKey} - {strategy.Description}");
    }

    Console.WriteLine();
    Console.WriteLine(
        "Welcome to the Martian Robots program the martians are currently on the planet {0}!",
        planet.Name);
    Console.WriteLine();
    Console.WriteLine();

    while (true)
    {
        Console.WriteLine("Enter command");
        Console.WriteLine();
        Console.WriteLine("Type a movement sequence, or type 'exit' to quit.");
        Console.WriteLine();
        Console.Write("> ");
        var input = Console.ReadLine();

        if (input is not string instruction)
        {
            break;
        }

        if (instruction.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Closing app...");
            break;
        }

        try
        {
            if (currentRobotIndex >= robots.Length)
            {
                Console.WriteLine("All robots have received their movement instructions.");
                break;
            }

            var currentRobot = robots[currentRobotIndex];
            robotMovementService.MoveRobot(instruction, currentRobot);
            Console.WriteLine($"Movement instructions accepted for {currentRobot.Name}.");
            currentRobotIndex++;
        }
        catch (InputValidationException exception)
        {
            Console.Error.WriteLine($"Input error: {exception.Message}");
        }
    }

    return 0;
}
catch (Exception exception)
{
    System.Diagnostics.Debug.WriteLine(exception);
    Console.Error.WriteLine("Error: Oops! Sorry, something unexpected went wrong. Please try again.");
    return 1;
}
finally
{
    ConsoleBanner.ResetTextColour();
}
