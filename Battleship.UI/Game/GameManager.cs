using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Battleship.UI;
using Battleship.UI.Enums;
using Battleship.UI.Implementations;
using Battleship.UI.Interfaces;
using Battleship.UI.IO;
using Battleship.UI.Ships;

namespace Battleship.UI
{
    public class GameManager
    {
        public Ship[] ship = new Ship[5];

        public string[] radar = new string[100];
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

        public void SetUpPlayer1Grid()
        {
            GameGrid.DisplayBattleGrid(radar);
            ConsoleIO.InitialiseEmptyCombatRadar(player1);
            GetShipCoordinates(ship[0]);
            ConsoleIO.AnyKey();

            for (int i = 1; i < ship.Length; i++)
            {
                Console.Clear();
                GameGrid.DisplayBattleGrid(radar);
                GetShipCoordinates(ship[i]);
                ConsoleIO.AnyKey();
            }
        }

        private void GetShipCoordinates(Ship ship)
        {
            Console.WriteLine($"\nShip to place: {ship.name} | Size: {ship.size}");
            CoordinateParser(ship);
        }

        private void CoordinateParser(Ship ship)
        {
            Ship currentShip = ship;
            Coordinates firstPoint = ConsoleIO.GetCurrentShipFirstCoordinate();
            Orientation orientation = ConsoleIO.GetShipOrientation("Enter ship orientation: 'H' for horizontal or 'V' for vertical: ");
            Direction direction = ConsoleIO.GetShipDirection(orientation);
            
            string gridColumsn = "ABCDEFGHIJ";
            int column = gridColumsn.IndexOf(firstPoint.coordinate[0]);
            int row = int.Parse(firstPoint.coordinate.Substring(1)) - 1;

            int gridFirstPoint = 0;

            gridFirstPoint = column + (row * 10);

            if(orientation == Orientation.Vertical)
            {
                if(direction == Direction.Up)
                {
                    for (int i = 0; i < currentShip.size; i++)
                    {
                        radar[gridFirstPoint] += currentShip.identifier;
                        gridFirstPoint -= 10;
                    }
                }
                else if(direction == Direction.Down)
                {
                    for(int i = 0; i < currentShip.size; i ++)
                    {
                        radar[gridFirstPoint] += currentShip.identifier;
                        gridFirstPoint += 10;
                    }
                }
            }
            else if(orientation == Orientation.Horizontal)
            {
                if(direction == Direction.Left)
                {
                    for (int i = 0; i < currentShip.size; i++)
                    {
                        radar[gridFirstPoint] += currentShip.identifier;
                        gridFirstPoint -= 1;
                    }
                }
                else if( direction == Direction.Right)
                {
                    for (int i = 0; i < currentShip.size; i++)
                    {
                        radar[gridFirstPoint] += currentShip.identifier;
                        gridFirstPoint += 1;
                    }
                }
            }
        }
    }
}
