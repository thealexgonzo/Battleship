using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            name = "Destroyer";
            size = 2;
            type = Enums.ShipType.Destroyer;
            shipIdentifier = "D";
            hitCounter = 0;
        }
    }
}
