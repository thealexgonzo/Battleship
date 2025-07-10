using System;
using System.Collections.Generic;
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
        public static void DisplayBattleGrid()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"   A B C D E F G H I J");

            for ( int i = 1; i <= 10; i++)
            {
                if (i == 10)
                {
                    Console.Write($"{i}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($" {i}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
                    Console.ResetColor();
                }
            }
        }
    }
}
