using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
using Battleship.UI.Ships;

namespace Battleship.UI
{
    public class ShipCoordinates
    {
        public string[] shipCoordinates { get; private set; }
        public string shipCharacterIdentifier { get; private set; }
        public ShipCoordinates(Ship ship, Coordinates firstCoordiante, Orientation orientation, Direction direction)
        {
            string gridColumns = "ABCDEFGHIJ";
            string[] gridRows = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10"];

            shipCoordinates = new string[ship.size];

            if (ship.type == ShipType.AircraftCarrier)
            {

                if(orientation == Orientation.Vertical)
                {
                    if(direction == Direction.Down)
                    {
                        for(int i = 0;  i < shipCoordinates.Length; i++)
                        {
                            shipCoordinates[i] += (firstCoordiante.coordinate[0] + gridRows[i]);
                        }
                    }
                }
            }
        }
    }
}
