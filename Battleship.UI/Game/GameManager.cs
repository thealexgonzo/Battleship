
using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
using Battleship.UI.IO;
using Battleship.UI.Ships;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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
            //Direction direction = ConsoleIO.GetShipDirection(orientation);
            do
            {
                Direction direction = ConsoleIO.GetShipDirection(orientation);
                //ValidateShipPlacement(ship, currentCoordinate, direction)
                if (ValidateShipPlacement(ship, currentCoordinate, direction))
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        if (direction == Direction.Up)
                        {
                            player1Radar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate -= 10;
                        }
                        else if (direction == Direction.Down)
                        {
                            player1Radar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate += 10;
                        }
                        else if (direction == Direction.Left)
                        {
                            player1Radar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate -= 1;
                        }
                        else if (direction == Direction.Right)
                        {
                            player1Radar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate += 1;
                        }
                    }

                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThat placement isn't valid.");
                    Console.ResetColor();
                }

            } while (true) ;
        }

        private bool ValidateShipPlacement(Ship ship, int coordinate, Direction direction)
        {
            int currentCoordinate = coordinate;
            bool IsValid = true;

            if (currentCoordinate < 0 || currentCoordinate > 100)
            {
                return false;
            }

            if (player1Radar[currentCoordinate] == null)
            {
                for (int i = 0; i < ship.size; i++)
                {
                    if (currentCoordinate < 0 || currentCoordinate > 100)
                    {
                        return false;
                    }
                    if (direction == Direction.Up)
                    {
                        if(CheckGridSpaceEmpty(currentCoordinate))
                        { IsValid = false; break; }
                        currentCoordinate -= 10;

                    }
                    else if (direction == Direction.Down)
                    {
                        if (CheckGridSpaceEmpty(currentCoordinate))
                        { IsValid = false; break; }
                        currentCoordinate += 10;
                    }
                    else if (direction == Direction.Left)
                    {
                        if (CheckGridSpaceEmpty(currentCoordinate))
                        { IsValid = false; break; }
                        currentCoordinate -= 1;
                    }
                    else if (direction == Direction.Right)
                    {
                        if (CheckGridSpaceEmpty(currentCoordinate))
                        { IsValid = false; break; }
                        currentCoordinate += 1;
                    }
                }
            }
            else
            {
                return false;
            }

            return IsValid;
        }
        public bool CheckGridSpaceEmpty(int position)
        {
            if (player1Radar[position] != null)
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



