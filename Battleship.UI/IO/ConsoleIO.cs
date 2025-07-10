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

        public static Coordinates GetCurrentShipFirstCoordinate()
        {
            string gridColumns = "ABCDEFGHIJ";

            do
            {
                Console.Write("Enter the coordinate: ");
                string coordinate = Console.ReadLine().ToUpper();
                int row = int.Parse(coordinate.Substring(1));

                if ((gridColumns.Contains(coordinate[0])) && (row >= 1 && row <= 10))
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
