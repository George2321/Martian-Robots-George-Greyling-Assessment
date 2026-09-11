using System;
using System.Collections.Generic;
using System.Text;

namespace Martian_Robots_George_Greyling_Assessment.Domain.Planets
{
    internal class Planet
    {
        private string Name { get; set; } = string.Empty;
        private int RowSize { get; set; } = 0;
        private int ColumnSize { get; set; } = 0;

        internal Planet(string name, int rowSize, int columnSize)
        {
            Name = name;
            RowSize = rowSize;
            ColumnSize = columnSize;
        }
        public Planet CreatePlanet(string name, int rowSize, int columnSize)
        {
           return new Planet(name, rowSize, columnSize);
        }     
    }
}