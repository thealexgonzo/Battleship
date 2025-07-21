using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Battleship.UI.IO
{
    public static class ConsoleIO
    {
        public static void DisplayGameTitle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================");
            Console.WriteLine("         FLEET COMMAND: BATTLE GRID       ");
            Console.WriteLine("=========================================");
            Console.ResetColor();
        }
        public static string GetPlayerName(string prompt)
        {
            do
            {
                Console.Write(prompt);

                string humanPlayerName = Console.ReadLine();

                if(!string.IsNullOrEmpty(humanPlayerName) && Regex.IsMatch(humanPlayerName, "[a-zA-z]"))
                {
                    return humanPlayerName;
                }
                else
                {
                    Console.WriteLine("Commander ID must be a valid name — letters only. No digits or special characters.");
                }

            } while (true);
        }
        public static void InitialiseEmptyCombatRadar(IPlayer player)
        {
            //ConsoleIO.TypeOut("\nInitializing combat systems...");

            //Thread.Sleep(2000);

            Console.Clear();

            Console.WriteLine($"\nWelcome, Commander {player.playerName}.");
            Console.WriteLine("Your fleet is standing by. It's time to deploy your ships.");

            DisplayEmptyRadar();

            Console.WriteLine("\nCoordinates should be from A-J (column) and 1-10 (row).");
            Console.WriteLine("You will be prompted for the starting coordinate and the direction of placement.");
        }
        public static void InitiateCombatSystem(IPlayer currentPlayer, IPlayer enemyPlayer)
        {
            int enemyFleetCount = 0;

            for(int i = 0; i < enemyPlayer.fleet.Length; i++)
            {
                if (enemyPlayer.fleet[i] != null)
                {
                    enemyFleetCount++;
                }
            }

            Console.WriteLine("All systems online. Weapons standing by.");
            Console.WriteLine($"Enemy fleet still has {enemyFleetCount} ships afloat");
            Console.WriteLine($"Your move, Commander {currentPlayer.playerName}. Select your target.");
        }
        public static void DisplayEmptyRadar()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"   A B C D E F G H I J");

            for (int i = 1; i <= 10; i++)
            {
                if (i == 10)
                {
                    Console.Write($"{i}");
                }
                else
                {
                    Console.Write($" {i}");
                }

                for (int x = 0; x <= 9; x++)
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" ~");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        public static Coordinates GetCurrentShipFirstCoordinate()
        {
            do
            {
                string columns = "ABCDEFGHIJ";

                Console.Write("Enter the starting coordinate: ");
                string coordinate = Console.ReadLine().ToUpper();

                if ((coordinate.Length > 1 && coordinate.Length <= 3) && 
                    (int.TryParse(coordinate.Substring(1), out int row)) && 
                    ((columns.Contains(coordinate[0])) && (row >= 1 && row <= 10)))
                {
                    return new Coordinates(coordinate);
                }
                else
                {
                    DisplayInvalidCoordinateErrorMessage();
                }
            } while (true);
        }
        public static Coordinates GetCoordinate()
        {
            do
            {
                string columns = "ABCDEFGHIJ";

                Console.Write("\nLocked and loaded. Designate target coordinate (example: C5): ");
                string coordinate = Console.ReadLine().ToUpper();

                if ((coordinate.Length > 1 && coordinate.Length <= 3) &&
                    (int.TryParse(coordinate.Substring(1), out int row)) &&
                    ((columns.Contains(coordinate[0])) && (row >= 1 && row <= 10)))
                {
                    return new Coordinates(coordinate);
                }
                else
                {
                    DisplayInvalidCoordinateErrorMessage();
                }
            } while (true);
        }
        private static void DisplayInvalidCoordinateErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Coordinate rejected. Grid reference invalid or outside targeting range (e.g., A1 to J10).");
            Console.ResetColor();
        }
        public static Orientation GetShipOrientation(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string orientation = Console.ReadKey().Key.ToString().ToUpper();

                if (orientation == "V")
                {
                    return Orientation.Vertical;
                }
                else if (orientation == "H")
                {
                    return Orientation.Horizontal;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCommander, that orientation is not valid. Please enter 'H' for horizontal or 'V' for vertical.");
                    Console.ResetColor();
                }
            } while (true);
        }
        internal static Direction GetShipDirection(Orientation orientation)
        {
            do
            {
                string direction;
                if(orientation == Orientation.Vertical)
                {
                    Console.Write("\nSpecify direction of deployment, Commander — Up or Down: ");
                    direction = Console.ReadKey().Key.ToString().ToUpper();

                    if (direction == "U")
                    {
                        return Direction.Up;
                    }
                    else if (direction == "D")
                    {
                        return Direction.Down;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCommander, that direction is not valid. Please enter (U)p or (D)own.");
                        Console.ResetColor();
                    }
                }
                else if(orientation == Orientation.Horizontal)
                {
                    Console.Write("\nSpecify direction of deployment, Commander — Left, or Right: ");
                    direction = Console.ReadKey().Key.ToString().ToUpper();

                    if (direction == "L")
                    {
                        return Direction.Left;
                    }
                    else if (direction == "R")
                    {
                        return Direction.Right;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCommander, that direction is not valid. Please enter (L)eft, or (R)ight.");
                        Console.ResetColor();
                    }
                }
                
            } while (true);
        }
        public static void AnyKey()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
        public static void TypeOut(string message, int delay = 60)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }

            Console.WriteLine();
        } 
    }
}
