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
            Console.WriteLine("\n");
            Console.WriteLine($"   A B C D E F G H I J");

            for (int i = 0; i < coordiantes.Length; i += 10)
            {
                //Console.Write(i == 10 ? $"{i}" : $" {i}");
                Console.WriteLine("1");  
                
                for (int j = i; j < i + 10; j++)
                {

                    if (coordiantes[j] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" ~");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($" {coordiantes[j]}");
                    }

                }

            }
        }
    }
}
