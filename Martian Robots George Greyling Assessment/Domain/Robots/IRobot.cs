namespace Martian_Robots_George_Greyling_Assessment.Domain.Robots;

internal interface IRobot
{
    string Name { get; }
    int CoordinateX { get; }
    int CoordinateY { get; }
    string Orientation { get; }
}
