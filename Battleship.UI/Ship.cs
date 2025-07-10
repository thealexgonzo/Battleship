//using Battleship.UI.Enums;
//using Battleship.UI.Interfaces;

//namespace Battleship.UI
//{
//    public class Ship
//    {
//        public string[] shipCoordinate { get; private set; }
//        public string shipCharacterIdentifier { get; private set; }
//        public Ship(ShipType ship, Coordinates coordinate, Orientation orientation, Direction direction)
//        {
//            string gridColumns = "ABCDEFGHIJ";
//            string[] gridRows = ["1","2","3","4","5","6","7","8","9","10"];
            
//            if(ship == ShipType.AircraftCarrier)
//            {
//                shipCoordinate = new string[5];
//                shipCharacterIdentifier = "A";
//            }
//            else if(ship == ShipType.BattleShip)
//            {
//                shipCoordinate = new string[4];
//                shipCharacterIdentifier = "B";
//            }
//            else if(ship == ShipType.Cruiser)
//            {
//                shipCoordinate = new string[3];
//                shipCharacterIdentifier = "C";
//            }
//            else if(ship == ShipType.Submarine)
//            {
//                shipCoordinate = new string[3];
//                shipCharacterIdentifier = "S";
//            }
//            else if(ship == ShipType.Destroyer)
//            {
//                shipCoordinate = new string[2];
//                shipCharacterIdentifier = "D";
//            }

//            for(int i = 0; i <= shipCoordinate.Length; i++)
//            {
//                if(orientation == Orientation.Vertical)
//                {
//                    i = int.Parse(coordinate.coordinate[1].ToString()) - 1;
//                    shipCoordinate[i] += (gridColumns[gridColumns.IndexOf(coordinate.coordinate[0])]);
//                    shipCoordinate[i] += gridRows[i];
//                }
//            }
//        }
//    }
//}
