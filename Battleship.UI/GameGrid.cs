using Battleship.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI
{
    public class GameGrid
    {
        public static void DisplayBattleGrid(string[] coordiantes)
        {
            string[] grid = coordiantes;

            Console.WriteLine("\n");
            Console.WriteLine($"   A B C D E F G H I J");

            //Prints 10 rows
            for (int i = 0; i < grid.Length; i++)
            {
                if(i % 10 == 0)
                {
                    Console.WriteLine();
                }
                if (i == 10)
                {
                    Console.Write($"{i}");
                }
                else
                {
                    Console.Write($" {i}");
                }

                if (grid[i] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" ~");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($" {grid[i]}");
                }
            }
        }
    }
}
