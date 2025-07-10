using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI
{
    public class Coordinates
    {
        public string firstCoordinate { get; private set; }
        public Coordinates(string column, int row)
        {
            firstCoordinate = column + row;
        }
    }
}
