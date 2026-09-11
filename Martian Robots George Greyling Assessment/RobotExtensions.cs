using Martian_Robots_George_Greyling_Assessment.Domain.Robots;
using Microsoft.Extensions.DependencyInjection;

namespace Martian_Robots_George_Greyling_Assessment;

public static class RobotExtensions
{
    public static IServiceCollection AddRobotInfrastructure(this IServiceCollection services)
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
}
