using Martian_Robots_George_Greyling_Assessment.Application.Exceptions;
using Martian_Robots_George_Greyling_Assessment.Domain.Planets;
using Martian_Robots_George_Greyling_Assessment.Domain.Robots;
using Martian_Robots_George_Greyling_Assessment.Application.Interfaces;

namespace Martian_Robots_George_Greyling_Assessment.Application.Services;

internal sealed class RobotMovementService : IRobotMovementService
{
    private readonly IPlanet _planet;
    private readonly IReadOnlyDictionary<char, IRobotActionStrategy> _actionStrategies;

    public RobotMovementService(
        IPlanet planet,
        IEnumerable<IRobotActionStrategy> actionStrategies)
    {
        _planet = planet;
        _actionStrategies = actionStrategies.ToDictionary(strategy => strategy.SupportedKey);
    }

    public string MoveRobot(string instructionString, IRobot robot)
    {
        ValidateInput(instructionString);

        return instructionString;
    }

    private void ValidateInput(string instructionString)
    {
        if (string.IsNullOrWhiteSpace(instructionString))
        {
            throw new InputValidationException("Movement instructions cannot be empty.");
        }

        if (instructionString.Length >= 100)
        {
            throw new InputValidationException("Movement instructions must be fewer than 100 characters.");
        }

        if (instructionString.Any(instruction => !_actionStrategies.ContainsKey(instruction)))
        {
            var supportedKeys = string.Join(
                ", ",
                _actionStrategies.Keys.OrderBy(key => "LRF".IndexOf(key)));
            throw new InputValidationException(
                $"Movement instructions may only contain these supported keys: {supportedKeys}.");
        }
    }
}
