using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI
{
    public class Coordinates
    {
        public string firstCoordinate { get; private set; }
        public Coordinates(string column, int row)
        {
            string gridColumns = "ABCDEFGHIJ";
            int[] gridRows = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            do
            {
                if ((gridColumns.Contains(column) && column.Length == 1) && (gridRows.Contains(row) && row >= 1 && row <= 10))
                {
                    firstCoordinate = column + row;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Coordinate rejected. Grid reference invalid or outside targeting range (e.g., A1 to J10).");
                    Console.ResetColor();
                }

            } while (true);
        }
    }
}
