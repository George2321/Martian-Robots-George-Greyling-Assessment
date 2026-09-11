using Martian_Robots_George_Greyling_Assessment.Domain.Robots;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Martian_Robots_George_Greyling_Assessment
{
    public static class RobotExtensions
    {
        public static IServiceCollection AddRobotInfrastructure(this IServiceCollection services)
        {
            // 1. Automatically find all concrete classes implementing IRobotAction
            var strategyType = typeof(IRobotActionStrategy);

            var implementations = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => strategyType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            // 2. Register each strategy found in the assembly
            foreach (var implementation in implementations)
            {
                services.AddTransient(typeof(IRobotActionStrategy), implementation);
            }

            // 3. Register the nested factory itself
            services.AddTransient<Robot.Factory>();

            return services;
        }
    }
}
