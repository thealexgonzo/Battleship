using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Battleship.UI;
using Battleship.UI.Implementations;
using Battleship.UI.Interfaces;
using Battleship.UI.IO;

namespace Battleship.UI
{
    public class GameManager
    {
        public Ship[] ships = new Ship[5];

        IPlayer player1 { get; set; }
        IPlayer player2 { get; set; }

        public GameManager(IPlayer p1, IPlayer p2)
        {
            player1 = p1;
            player2 = p2;
        }

        public void SetUpPlayer1Grid()
        {
            ConsoleIO.TypeOut("\nInitializing combat systems...");

            Thread.Sleep(2000);

            Console.WriteLine($"\nWelcome, Commander {player1.playerName}.");
            Console.WriteLine("Your fleet is standing by. It's time to deploy your ships.");

            GameGrid.DisplayBattleGrid();



        }
    }
}
