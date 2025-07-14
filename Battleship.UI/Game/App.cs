using Battleship.UI.Enums;
using Battleship.UI.Factories;
using Battleship.UI.Interfaces;
using Battleship.UI.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Game
{
    public class App
    {
        public static void Run()
        {
            ConsoleIO.DisplayGameTitle();

            Console.ForegroundColor = ConsoleColor.Cyan;
            IPlayer player1 = PlayerFactory.GetPlayerType("Commander, identify yourself: (H)uman operative or (C)omputer-controlled unit? ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            IPlayer player2 = PlayerFactory.GetPlayerType("Who’s your adversary? A (H)uman tactician or an AI-controlled war machine? ");
            Console.ResetColor();

            GameManager manager = new GameManager(player1, player2);

            IPlayer currentPlayer = player1;

            manager.SetUpCurrentPlayerFleet(player1);
            manager.SetUpCurrentPlayerFleet(player2);


            manager.PlayerAttacks(currentPlayer);

        }
    }
}
