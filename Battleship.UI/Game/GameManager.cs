
using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
using Battleship.UI.IO;
using Battleship.UI.Ships;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Battleship.UI
{
    public class GameManager
    {
        public Ship[] ship = new Ship[5];

        public string[] player1Radar = new string[100];
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
            Coordinates coordinate = ConsoleIO.GetCurrentShipFirstCoordinate();
            int currentCoordinate = coordinate.gridAcceptedCoordinate;
            Orientation orientation = ConsoleIO.GetShipOrientation("Enter ship orientation: 'H' for horizontal or 'V' for vertical: ");
            Direction direction = ConsoleIO.GetShipDirection(orientation);
            do
            {
                //Direction direction = ConsoleIO.GetShipDirection(orientation);
            //ValidateShipPlacement(ship, currentCoordinate, direction)
                if (ValidateShipPlacement(ship, currentCoordinate, direction))
                {
                    if (direction == Direction.Up)
                    {
                        for (int i = 0; i < ship.size; i++)
                        {
                            player1Radar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate -= 10;
                        }
                    }
                    else if (direction == Direction.Down)
                    {
                        for (int i = 0; i < ship.size; i++)
                        {
                            player1Radar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate += 10;
                        }
                    }
                    else if (direction == Direction.Left)
                    {
                        for (int i = 0; i < ship.size; i++)
                        {
                            player1Radar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate -= 1;
                        }
                    }
                    else if (direction == Direction.Right)
                    {
                        for (int i = 0; i < ship.size; i++)
                        {
                            player1Radar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate += 1;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("That placement isn't valid.");
                }

            } while (true) ;
        }

        private bool ValidateShipPlacement(Ship ship, int coordinate, Direction direction)
        {
            int currentCoordinate = coordinate;
            string[] shipPositions = new string[ship.size];
            bool shipPositionValid = true;

            if (player1Radar[currentCoordinate] == null)
            {           
                if (direction == Direction.Up)
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        shipPositions[i] += player1Radar[currentCoordinate];
                        currentCoordinate -= 10;
                    }
                }
                else if (direction == Direction.Down)
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        shipPositions[i] += player1Radar[currentCoordinate];
                        currentCoordinate += 10;
                    }
                }
                else if (direction == Direction.Left)
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        shipPositions[i] += player1Radar[currentCoordinate];
                        currentCoordinate -= 1;
                    }
                }
                else if (direction == Direction.Right)
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        shipPositions[i] += player1Radar[currentCoordinate];
                        currentCoordinate += 1;
                    }
                }
            }
            else
            {
                shipPositionValid = false;
            }

            return shipPositionValid;
        }
        public bool CheckGridSpaceEmpty(int position)
        {
            if (player1Radar[position] == null)
            {
                return true;
            }
            else
            {
                return false;
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
    }
}



