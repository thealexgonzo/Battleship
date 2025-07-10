using Battleship.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Ships
{
    public abstract class Ship
    {
        public string name { get; set; }
        public int size { get; set; }
        public ShipType type { get; set;}

        public string identifier { get; set; }

        public string[] shipCoordinates { get; set; }
    }
}
