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
        
        public static string GetPlayerName(string prompt)
        {
            string humanPlayerName;

            Console.Write(prompt);
            humanPlayerName = Console.ReadLine();

            return humanPlayerName;
        }

        public static Coordinates GetCurrentShipFirstCoordinate()
        {
            string gridColumns = "ABCDEFGHIJ";

            do
            {
                Console.Write("Enter the column of your coordinate: ");
                string column = Console.ReadLine();
                Console.Write("Enter the row of your coordinate: ");
                int row = int.Parse(Console.ReadLine());

                if ((gridColumns.Contains(column) && column.Length == 1) && (row >= 1 && row <= 10))
                {
                    return new Coordinates(column, row);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Coordinate rejected. Grid reference invalid or outside targeting range (e.g., A1 to J10).");
                    Console.ResetColor();
                }

            } while (true);
        }
        //public static void DisplayBattleGrid()
        //{
        //    Console.WriteLine("\n");
        //    Console.WriteLine($"   A B C D E F G H I J");

        //    for ( int i = 1; i <= 10; i++)
        //    {
        //        if (i == 10)
        //        {
        //            Console.Write($"{i}");
        //            Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine(" ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
        //            Console.ResetColor();
        //        }
        //        else
        //        {
        //            Console.Write($" {i}");
        //            Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine(" ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
        //            Console.ResetColor();
        //        }
        //    }
        //}

        public static void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
