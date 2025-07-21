using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Ships
{
    public class Cruiser : Ship
    {
        public Cruiser()
        {
            name = "Crusier";
            size = 3;
            type = Enums.ShipType.Cruiser;
            shipIdentifier = "C";
            hitCounter = 0;
        }
    }
}
