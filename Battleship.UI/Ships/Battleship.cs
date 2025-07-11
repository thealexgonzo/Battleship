using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Ships
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            name = "Battle ship";
            size = 4;
            type = Enums.ShipType.BattleShip;
            shipIdentifier = "B";
            shipCoordinates = new string[size];
        }
    }
}
