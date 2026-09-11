namespace Martian_Robots_George_Greyling_Assessment.Application.Exceptions;

internal sealed class InputValidationException : Exception
{
    public InputValidationException(string message)
        : base(message)
    {
    }
}
