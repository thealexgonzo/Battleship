using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI
{
    public class Coordinates
    {
        public string coordinate { get; private set; }
        public Coordinates(string coordinate)
        {
            this.coordinate = coordinate;
        }
    }
}
