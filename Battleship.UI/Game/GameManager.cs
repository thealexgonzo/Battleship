
using Battleship.UI.Enums;
using Battleship.UI.Implementations;
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
        private ShotResult previousComputerShot = ShotResult.NoShot;
        private int previousComputerAttackPoint = 0;
        public IPlayer player1 { get; private set; }
        public IPlayer player2 { get; private set; }
        public GameManager(IPlayer p1, IPlayer p2)
        {
            player1 = p1;
            player2 = p2;

            player1.fleet = new Ship[5];
            player2.fleet = new Ship[5];

            player1.fleet[0] = new AircraftCarrier();
            player1.fleet[1] = new Battleship.UI.Ships.Battleship();
            player1.fleet[2] = new Cruiser();
            player1.fleet[3] = new Submarine();
            player1.fleet[4] = new Destroyer();

            player2.fleet[0] = new AircraftCarrier();
            player2.fleet[1] = new Battleship.UI.Ships.Battleship();
            player2.fleet[2] = new Cruiser();
            player2.fleet[3] = new Submarine();
            player2.fleet[4] = new Destroyer();

            player1.playerCombatRadar = new string[100];
            player2.playerCombatRadar = new string[100];
        }
        public void SetUpCurrentPlayerFleet(IPlayer currentPlayer)
        {
            currentPlayer.playerRadar = new string[100];

            if (currentPlayer.IsHuman)
            {
                GameGrid.DisplayPositioningGrid(currentPlayer.playerRadar);
                ConsoleIO.InitialiseEmptyCombatRadar(currentPlayer);
                PositionShips(currentPlayer.fleet[0], currentPlayer);
                ConsoleIO.AnyKey();

                for (int i = 1; i < currentPlayer.fleet.Length; i++)
                {
                    Console.Clear();
                    GameGrid.DisplayPositioningGrid(currentPlayer.playerRadar);
                    PositionShips(currentPlayer.fleet[i], currentPlayer);
                    ConsoleIO.AnyKey();
                }

                Console.Clear();
                GameGrid.DisplayPositioningGrid(currentPlayer.playerRadar);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nFleet positioned and ready for battle, Commander {currentPlayer.playerName}.");
                Console.ResetColor();
                ConsoleIO.AnyKey();
            }
            else
            {
                for (int i = 0; i < currentPlayer.fleet.Length; i++)
                {
                    PositionShips(currentPlayer.fleet[i], currentPlayer);
                }

                GameGrid.DisplayPositioningGrid(currentPlayer.playerRadar);
                ConsoleIO.AnyKey();
            }      
        }
        public ShotResult PlayerAttacks(IPlayer currentPlayer, IPlayer opponent)
        {
            if (currentPlayer.IsHuman)
            {
                Console.Clear();
                ConsoleIO.InitiateCombatSystem(currentPlayer, opponent);
                GameGrid.DisplayCombatGrid(currentPlayer.playerCombatRadar);
                Coordinates attackCoord;

                do
                {
                    attackCoord = ConsoleIO.GetCoordinate();

                    if (currentPlayer.playerCombatRadar[attackCoord.gridAcceptedCoordinate] == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nWe've already fired at those coordinates, Commander. Choose a new target.");
                    }
                } while (true);

                ShotResult shotResult = CheckShotResult(attackCoord.gridAcceptedCoordinate, opponent);

                if (shotResult == ShotResult.Hit)
                {
                    currentPlayer.playerCombatRadar[attackCoord.gridAcceptedCoordinate] = "H";
                    Console.Clear();
                    GameGrid.DisplayCombatGrid(currentPlayer.playerCombatRadar);

                    int shipHit = CheckShipHit(opponent.playerRadar[attackCoord.gridAcceptedCoordinate]);
                    opponent.fleet[shipHit].hitCounter++;

                    if (opponent.fleet[shipHit].size == opponent.fleet[shipHit].hitCounter)
                    {
                        opponent.fleet[shipHit] = null;
                        shotResult = ShotResult.HitAndSunk;
                    }
                }
                else
                {
                    currentPlayer.playerCombatRadar[attackCoord.gridAcceptedCoordinate] = "M";
                    Console.Clear();
                    GameGrid.DisplayCombatGrid(currentPlayer.playerCombatRadar);
                }

                ConsoleIO.DisplayShotResult(shotResult, currentPlayer);
                ConsoleIO.AnyKey();
                return shotResult;
            }
            else
            {
                Console.Clear();

                Console.WriteLine($"Commander we have {opponent.fleet.Count(f => f != null)} ship's still operational.");
                Console.WriteLine($"Brace yourself - {currentPlayer.playerName} is preparing to strike...");

                Random SelectingShot = new Random();
                ShotResult computerShot = ShotResult.NoShot;
                int[] attackCalculations = [1, 10];
                bool TargetMode = false;

                int shot = 0;

                if (previousComputerShot == ShotResult.Hit)
                {
                    TargetMode = true;
                }

                if (TargetMode)
                {
                    if(computerShot == ShotResult.HitAndSunk)
                    {
                        TargetMode = false;
                        
                    }
                    else
                    {
                        if (CheckValidAttackCoordiante(previousComputerAttackPoint + attackCalculations[0], currentPlayer))
                            shot = previousComputerAttackPoint + attackCalculations[0];
                        else if (CheckValidAttackCoordiante(previousComputerAttackPoint - attackCalculations[0], currentPlayer))
                            shot = previousComputerAttackPoint - attackCalculations[0];
                        else if (CheckValidAttackCoordiante(previousComputerAttackPoint + attackCalculations[1], currentPlayer))
                            shot = previousComputerAttackPoint + attackCalculations[1];
                        else if (CheckValidAttackCoordiante(previousComputerAttackPoint - attackCalculations[1], currentPlayer))
                            shot = previousComputerAttackPoint - attackCalculations[1];
                    }
                }
                else
                {
                    do
                    {
                        shot = SelectingShot.Next(0, 100);

                        if (CheckValidAttackCoordiante(shot, currentPlayer))
                            break;

                    } while (true);
                }
                
                Console.WriteLine($"{currentPlayer.playerName} fires a shot at {ConsoleIO.ShotConverter(shot)}");

                computerShot = CheckShotResult(shot, opponent);
                previousComputerShot = computerShot;
                previousComputerAttackPoint = shot;

                if (computerShot == ShotResult.Hit)
                {
                    int shipHit = CheckShipHit(opponent.playerRadar[shot]);
                    opponent.fleet[shipHit].hitCounter += 1;
                    currentPlayer.playerCombatRadar[shot] = "H";

                    if (opponent.fleet[shipHit].size == opponent.fleet[shipHit].hitCounter)
                    {
                        opponent.fleet[shipHit] = null;
                        computerShot = ShotResult.HitAndSunk;
                    }
                }
                else
                {
                    currentPlayer.playerCombatRadar[shot] = "M";
                }

                ConsoleIO.DisplayShotResult(computerShot, currentPlayer);
                ConsoleIO.AnyKey();

                return computerShot;
            }
        }
        private void PositionShips(Ship ship, IPlayer currentPlayer)
        {
            Coordinates coordinate;
            int currentCoordinate = 0;
            Random coordiante = new Random();

            if (currentPlayer.IsHuman)
            {
                Console.WriteLine($"\nShip to place: {ship.name} | Size: {ship.size}");

                do
                {
                    coordinate = ConsoleIO.GetCurrentShipFirstCoordinate();

                    if (!CheckGridSpaceEmpty(coordinate.gridAcceptedCoordinate, currentPlayer))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid coordinates, Commander. We can’t deploy outside the grid or on top of another vessel.");
                        Console.ResetColor();
                    }

                } while (!CheckGridSpaceEmpty(coordinate.gridAcceptedCoordinate, currentPlayer));
                
                currentCoordinate = coordinate.gridAcceptedCoordinate;
            }
            else
            {
                do
                {
                    currentCoordinate = coordiante.Next(0, 100);

                } while (!CheckGridSpaceEmpty(currentCoordinate, currentPlayer));
            }

            Orientation orientation;
            Direction direction;

            do
            {
                if (currentPlayer.IsHuman)
                {
                    orientation = ConsoleIO.GetShipOrientation("Enter ship orientation: 'H' for horizontal or 'V' for vertical: ");
                    direction = ConsoleIO.GetShipDirection(orientation);
                }
                else
                {
                    Random HorizontalOrVertical = new Random();
                    Random LeftOrRight = new Random();
                    Random UpOrDown = new Random();

                    orientation = (Orientation)HorizontalOrVertical.Next(0, 2);
 
                    if (orientation == Orientation.Horizontal)
                    {
                        direction = (Direction)LeftOrRight.Next(0, 2);
                    }
                    else
                    {
                        direction = (Direction)UpOrDown.Next(2, 4);
                    }

                }

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

                    if (currentPlayer.IsHuman)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nDeployment confirmed: {ship.name} has been positioned.");
                        Console.ResetColor();
                    }

                    break;
                }
                else
                {
                    if (currentPlayer.IsHuman)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid coordinates, Commander. We can’t deploy outside the grid or on top of another vessel.");
                        Console.ResetColor();
                    }
                }
            } while (!ValidateShipPlacement(ship, currentCoordinate, direction, currentPlayer)) ;
        }
        private bool ValidateShipPlacement(Ship ship, int coordinate, Direction direction, IPlayer currentPlayer)
        {
            int currentCoordinate = coordinate;
            bool IsValid = true;
            int rowMaxRange = (coordinate - (coordinate % 10)) + 9;
            int rowMinRange = coordinate - (coordinate % 10);

            if (currentCoordinate < 0 || currentCoordinate > 100)
            {
                return false;
            }

            if (currentPlayer.playerRadar[currentCoordinate] == null)
            {
                for (int i = 0; i < ship.size; i++)
                {
                    if (currentCoordinate < 0 || currentCoordinate >= currentPlayer.playerRadar.Length)
                    {
                        return false;
                    }
                    if (direction == Direction.Up)
                    {
                        if(!CheckGridSpaceEmpty(currentCoordinate, currentPlayer))
                        { IsValid = false; break; }
                        currentCoordinate -= 10;

                    }
                    else if (direction == Direction.Down)
                    {
                        if (!CheckGridSpaceEmpty(currentCoordinate, currentPlayer))
                        { IsValid = false; break; }
                        currentCoordinate += 10;
                    }
                    else if (direction == Direction.Left)
                    {
                        if (!CheckGridSpaceEmpty(currentCoordinate, currentPlayer) || currentCoordinate > rowMaxRange || currentCoordinate < rowMinRange)
                        { IsValid = false; break; }
                        currentCoordinate -= 1;
                    }
                    else if (direction == Direction.Right)
                    {
                        if (!CheckGridSpaceEmpty(currentCoordinate, currentPlayer) || currentCoordinate > rowMaxRange || currentCoordinate < rowMinRange)
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
            if (currentPlayer.playerRadar[position] == null)
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
        private ShotResult CheckShotResult(int shot, IPlayer opponent)
        {
            if (opponent.playerRadar[shot] != null)
            {
                return ShotResult.Hit;
            }
            else
            {
                return ShotResult.Miss;
            }
        }
        private static int CheckShipHit(string shipIdentifier)
        {
            if(shipIdentifier == "A")
            {
                return 0;
            }
            else if(shipIdentifier == "B")
            {
                return 1;
            }
            else if(shipIdentifier == "C")
            {
                return 2;
            }
            else if(shipIdentifier == "S")
            {
                return 3;
            }
            else
            {
                return 4;
            }
        } 
        private bool CheckValidAttackCoordiante(int coordinate, IPlayer currentPlayer)
        {
            if (currentPlayer.playerCombatRadar[coordinate] == null)
                return true;
            else
                return false;
        }
    }
}



