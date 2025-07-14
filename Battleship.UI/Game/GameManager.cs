
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
            currentPlayer.playerRadar = new string[100];

            GameGrid.DisplayBattleGrid(currentPlayer.playerRadar);
            ConsoleIO.InitialiseEmptyCombatRadar(currentPlayer);
            PositionShips(ship[0], currentPlayer);
            ConsoleIO.AnyKey();

            for (int i = 1; i < ship.Length; i++)
            {
                Console.Clear();
                GameGrid.DisplayBattleGrid(currentPlayer.playerRadar);
                PositionShips(ship[i], currentPlayer);
                ConsoleIO.AnyKey();
            }

            Console.Clear();
            GameGrid.DisplayBattleGrid(currentPlayer.playerRadar);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFleet positioned and ready for battle, Commander.");
            Console.ResetColor();
            ConsoleIO.AnyKey();
        }
        private void PositionShips(Ship ship, IPlayer currentPlayer)
        {
            Console.WriteLine($"\nShip to place: {ship.name} | Size: {ship.size}");
            Coordinates coordinate;

            do
            {
                coordinate = ConsoleIO.GetCurrentShipFirstCoordinate();

                if (!CheckGridSpaceEmpty(coordinate.gridAcceptedCoordinate, currentPlayer))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid coordinates, Commander. We can’t deploy outside the grid or on top of another vessel.");
                    Console.ResetColor();
                }

            } while (true);

            int currentCoordinate = coordinate.gridAcceptedCoordinate;

            do
            {
                
                Orientation orientation = ConsoleIO.GetShipOrientation("Enter ship orientation: 'H' for horizontal or 'V' for vertical: ");
                Direction direction = ConsoleIO.GetShipDirection(orientation);

                if (ValidateShipPlacement(ship, currentCoordinate, direction, currentPlayer))
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        if (direction == Direction.Up)
                        {
                            currentPlayer.playerRadar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate -= 10;
                        }
                        else if (direction == Direction.Down)
                        {
                            currentPlayer.playerRadar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate += 10;
                        }
                        else if (direction == Direction.Left)
                        {
                            currentPlayer.playerRadar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate -= 1;
                        }
                        else if (direction == Direction.Right)
                        {
                            currentPlayer.playerRadar[currentCoordinate] += ship.shipIdentifier;
                            currentCoordinate += 1;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nDeployment confirmed: {ship.name} has been positioned.");
                    Console.ResetColor();

                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid coordinates, Commander. We can’t deploy outside the grid or on top of another vessel.");
                    Console.ResetColor();
                }

            } while (true) ;
        }
        private bool ValidateShipPlacement(Ship ship, int coordinate, Direction direction, IPlayer currentPlayer)
        {
            int currentCoordinate = coordinate;
            bool IsValid = true;

            if (currentCoordinate < 0 || currentCoordinate > 100)
            {
                return false;
            }

            if (currentPlayer.playerRadar[currentCoordinate] == null)
            {
                for (int i = 0; i < ship.size; i++)
                {
                    if (currentCoordinate < 0 || currentCoordinate > 100)
                    {
                        return false;
                    }
                    if (direction == Direction.Up)
                    {
                        if(CheckGridSpaceEmpty(currentCoordinate, currentPlayer))
                        { IsValid = false; break; }
                        currentCoordinate -= 10;

                    }
                    else if (direction == Direction.Down)
                    {
                        if (CheckGridSpaceEmpty(currentCoordinate, currentPlayer))
                        { IsValid = false; break; }
                        currentCoordinate += 10;
                    }
                    else if (direction == Direction.Left)
                    {
                        if (CheckGridSpaceEmpty(currentCoordinate, currentPlayer))
                        { IsValid = false; break; }
                        currentCoordinate -= 1;
                    }
                    else if (direction == Direction.Right)
                    {
                        if (CheckGridSpaceEmpty(currentCoordinate, currentPlayer))
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
        public bool CheckGridSpaceEmpty(int position, IPlayer currentPlayer)
        {
            if (currentPlayer.playerRadar[position] != null)
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



