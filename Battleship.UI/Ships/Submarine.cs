using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Ships
{
    public class Submarine : Ship
    {
        public Submarine()
        {
            name = "Submarine";
            size = 3;
            type = Enums.ShipType.Submarine;
            shipCoordinates = new string[size];
            shipIdentifier = "S";
            hitCounter = 0;
        }
    }
}
