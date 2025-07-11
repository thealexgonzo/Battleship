using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI
{
    public class Coordinates
    {
        public int gridPosition { get; private set; }
        public Coordinates(string coordinate)
        {
            string gridColumns = "ABCDEFGHIJ";

            int column = gridColumns.IndexOf(coordinate[0]);
            int row = int.Parse(coordinate.Substring(1)) - 1;

            gridPosition = column + (row * 10);
        }
    }
}
