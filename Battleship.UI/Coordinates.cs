using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI
{
    public class Coordinates
    {
        public int gridAcceptedCoordinate { get; private set; }
        public int rowRangeMax { get; private set; }
        public int rowRangeMin { get; private set; }
        public Coordinates(string coordinate)
        {
            string gridColumns = "ABCDEFGHIJ";

            int column = gridColumns.IndexOf(coordinate[0]);
            int row = int.Parse(coordinate.Substring(1)) - 1;

            rowRangeMax = ((row + 1) * 10) - 1;
            rowRangeMin = row == 0 ? 0 : ((row + 1) * 10) - 10;

            gridAcceptedCoordinate = column + (row * 10);
        }
    }
}
