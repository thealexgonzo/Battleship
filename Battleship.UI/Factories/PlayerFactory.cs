using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.UI.Implementations;
using Battleship.UI.Interfaces;
using Battleship.UI.IO;

namespace Battleship.UI.Factories
{
    public static class PlayerFactory
    {
        public static IPlayer GetPlayerType(string prompt)
        {
            string userChoice;

            do
            {
                Console.WriteLine("\n");
                Console.Write(prompt);
                userChoice = Console.ReadKey().Key.ToString().ToUpper();

                if (userChoice == "H")
                {
                    HumanPlayer player = new HumanPlayer();

                    player.playerName = ConsoleIO.GetPlayerName("\n>> Authorization required. Enter Commander name: ");

                    return player;
                }
                else if (userChoice == "C")
                {
                    //ConsoleIO.TypeOut("\n>>> Opponent selected: Iron Depth [AUTONOMOUS COMBAT SYSTEM v3.4] " +
                    //    "\n>>> Initializing strategic modules... Ready for engagement.");
                    //Temporary:
                    Console.WriteLine("\nIron Depth");

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
