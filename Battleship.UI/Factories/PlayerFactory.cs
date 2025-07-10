using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.UI.Implementations;
using Battleship.UI.Interfaces;

namespace Battleship.UI.Factories
{
    public static class PlayerFactory
    {
        public static IPlayer GetPlayerType(string prompt)
        {
            string playerType;

            do
            {
                Console.WriteLine("\n");
                Console.Write(prompt);
                playerType = Console.ReadKey().Key.ToString().ToUpper();

                if (playerType == "H")
                {
                    return new HumanPlayer();
                }
                else if (playerType == "C")
                {
                    return new ComputerPlayer();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNice try, but only real operatives or AI units are allowed. Choose (H) or (C).");
                    Console.ResetColor();
                }
            } while (true);
        }
    }
}
