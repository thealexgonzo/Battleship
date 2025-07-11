using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
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
        public static string GetPlayerName(string prompt, bool isHumanPlayer)
        {
            string humanPlayerName;

            if (isHumanPlayer)
            {
                Console.Write(prompt);
                humanPlayerName = Console.ReadLine();

                return humanPlayerName;
            }
            else
            {
                Console.WriteLine("\n>>> Opponent selected: Iron Depth [AUTONOMOUS COMBAT SYSTEM v3.4]" +
                "\n>>> Initializing strategic modules... Ready for engagement.");
            }

            return null;
        }

        public static void InitialiseEmptyCombatRadar(IPlayer player)
        {
            ConsoleIO.TypeOut("\nInitializing combat systems...");

            Thread.Sleep(2000);

            Console.Clear();

            Console.WriteLine($"\nWelcome, Commander {player.playerName}.");
            Console.WriteLine("Your fleet is standing by. It's time to deploy your ships.");

            DisplayEmptyRadar();

            Console.WriteLine("\nCoordinates should be from A-J (column) and 1-10 (row).");
            Console.WriteLine("You will be prompted for the starting coordinate and the direction of placement.");
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
            string column = "ABCDEFGHIJ";

            do
            {
                Console.Write("Enter the starting coordinate: ");
                string coordinate = Console.ReadLine().ToUpper();
                int row = int.Parse(coordinate.Substring(1));

                if ((column.Contains(coordinate[0])) && (row >= 1 && row <= 10))
                {
                    return new Coordinates(coordinate);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Coordinate rejected. Grid reference invalid or outside targeting range (e.g., A1 to J10).");
                    Console.ResetColor();
                }

            } while (true);
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
                    Console.WriteLine("Commander, that orientation is not valid. Please enter 'H' for horizontal or 'V' for vertical.");
                }
            } while (true);
        }
        internal static Direction GetShipDirection(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string direction = Console.ReadKey().Key.ToString().ToUpper();

                if (direction == "U")
                {
                    return Direction.Up;
                }
                else if (direction == "D")
                {
                    return Direction.Down;
                }
                else if(direction == "L")
                {
                    return Direction.Left;
                }
                else if(direction == "R")
                {
                    return Direction.Right;
                }
                else
                {
                    Console.WriteLine("Commander, that direction is not valid. Please enter (U)p, (D)own, (L)eft, or (R)ight.");
                }
            } while (true);
        }

        public static void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
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
