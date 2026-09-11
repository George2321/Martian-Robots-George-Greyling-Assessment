namespace Martian_Robots_George_Greyling_Assessment.Domain.Planets;

public class Planet : IPlanet
{
    public Planet(string name, int rowSize, int columnSize)
    {
        Name = name;
        RowSize = rowSize;
        ColumnSize = columnSize;
    }

    public string Name { get; }
    public int RowSize { get; }
    public int ColumnSize { get; }
}
