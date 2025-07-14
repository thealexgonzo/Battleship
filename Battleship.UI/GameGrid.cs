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
        public static void DisplayPositioningGrid(string[] positionCoordinates)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"   A B C D E F G H I J");

            int rowNumber = 1;

            for (int i = 0; i < positionCoordinates.Length; i += 10)
            {
                Console.Write(rowNumber == 10 ? $"{rowNumber}" : $" {rowNumber}");  
                
                for (int j = i; j < i + 10; j++)
                {
                    if (positionCoordinates[j] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" ~");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($" {positionCoordinates[j]}");
                    }
                }
                Console.WriteLine();

                rowNumber++;
            }
        }
        public static void DisplayCombatGrid(string[] attackCoordiantes)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"   A B C D E F G H I J");

            int rowNumber = 1;

            for (int i = 0; i < 100; i += 10)
            {
                Console.Write(rowNumber == 10 ? $"{rowNumber}" : $" {rowNumber}");

                for (int j = i; j < i + 10; j++)
                {
                    if (attackCoordiantes[j] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" ~");
                        Console.ResetColor();
                    }
                    else
                    {
                        if(attackCoordiantes[j] == "H")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Console.Write($" {attackCoordiantes[j]}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();

                rowNumber++;
            }
        }
    }
}
