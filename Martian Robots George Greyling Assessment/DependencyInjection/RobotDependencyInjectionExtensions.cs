using Martian_Robots_George_Greyling_Assessment.Domain.Robots;
using Martian_Robots_George_Greyling_Assessment.Application.Interfaces;
using Martian_Robots_George_Greyling_Assessment.Application.Services;
using Martian_Robots_George_Greyling_Assessment.Domain.Planets;
using Microsoft.Extensions.DependencyInjection;

namespace Martian_Robots_George_Greyling_Assessment.DependencyInjection;

internal static class RobotDependencyInjectionExtensions
{
    public static IServiceCollection AddPlanet(this IServiceCollection services, IPlanet planet)
    {
        services.AddSingleton(planet);

        return services;
    }

    public static IServiceCollection AddRobotServices(this IServiceCollection services)
    {
        var strategyType = typeof(IRobotActionStrategy);
        var implementations = strategyType.Assembly
            .GetTypes()
            .Where(type => strategyType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);

        foreach (var implementation in implementations)
        {
            services.AddTransient(strategyType, implementation);
        }

        services.AddTransient<Robot.Factory>();

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IRobotMovementService, RobotMovementService>();

        return services;
    }
}
