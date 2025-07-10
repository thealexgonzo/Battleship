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
        public static void DisplayBattleGrid(Coordinates coordiante, Orientation orientation, Direction direction)
        {
            string[] grid = new string[100];

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
                    if (grid[x] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" ~");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(grid[x]);
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
