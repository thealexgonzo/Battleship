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
        public static void Run(IPlayer p1, IPlayer p2)
        {
            ConsoleIO.DisplayBattleGrid();
        }
    }
}
