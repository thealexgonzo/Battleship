
using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
using Battleship.UI.IO;
using Battleship.UI.Ships;

namespace Battleship.UI
{
    public class GameManager
    {
        public Ship[] ship = new Ship[5];

        public static string[] player1Radar = new string[100];
        public string[] player2Radar = new string[100];
        public IPlayer player1 { get; private set; }
        public IPlayer player2 { get; private set; }

        public GameManager(IPlayer p1, IPlayer p2)
        {
            player1 = p1;
            player2 = p2;

            ship[0] = new AircraftCarrier();
            ship[1] = new Battleship.UI.Ships.Battleship();
            ship[2] = new Cruiser();
            ship[3] = new Submarine();
            ship[4] = new Destroyer();
        }

        public void SetUpCurrentPlayerFleet(IPlayer currentPlayer)
        {
            GameGrid.DisplayBattleGrid(player1Radar);
            ConsoleIO.InitialiseEmptyCombatRadar(player1);
            PositionShips(ship[0]);
            ConsoleIO.AnyKey();

            for (int i = 1; i < ship.Length; i++)
            {
                Console.Clear();
                GameGrid.DisplayBattleGrid(player1Radar);
                PositionShips(ship[i]);
                ConsoleIO.AnyKey();
            }
        }

        private void PositionShips(Ship ship)
        {
            Console.WriteLine($"\nShip to place: {ship.name} | Size: {ship.size}");
            CoordinateParser(ship);
        }

        private void CoordinateParser(Ship ship)
        {
            Coordinates firstPoint = ConsoleIO.GetCurrentShipFirstCoordinate();

            Orientation orientation = ConsoleIO.GetShipOrientation("Enter ship orientation: 'H' for horizontal or 'V' for vertical: ");
            Direction direction = ConsoleIO.GetShipDirection(orientation);

            int gridCurrentPoint = firstPoint.gridPosition;

            if (orientation == Orientation.Vertical)
            {
                if (direction == Direction.Up)
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        player1Radar[gridCurrentPoint] += ship.shipIdentifier;
                        gridCurrentPoint -= 10;
                    }
                }
                else if (direction == Direction.Down)
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        player1Radar[gridCurrentPoint] += ship.shipIdentifier;
                        gridCurrentPoint += 10;
                    }
                }
            }
            else if (orientation == Orientation.Horizontal)
            {
                if (direction == Direction.Left)
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        player1Radar[gridCurrentPoint] += ship.shipIdentifier;
                        gridCurrentPoint -= 1;
                    }
                }
                else if (direction == Direction.Right)
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        player1Radar[gridCurrentPoint] += ship.shipIdentifier;
                        gridCurrentPoint += 1;
                    }
                }
            }
        }

        public IPlayer SwithPlayers(IPlayer player)
        {
            if(player == player1)
            {
                return player2;
            }
            else
            {
                return player1;
            }
        }

        //public bool ValidateGridPositoin(int position)
        //{
        //    for (int i = 0; i < player1Radar.Length; i++)
        //    {
        //        if (player1Radar[i] == null)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}
    }
}
