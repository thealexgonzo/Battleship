using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
using Battleship.UI.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Implementations
{
    public class HumanPlayer : IPlayer
    {
        public bool IsHuman { get { return true; } }

        public string playerName { get; set; }
    }
}
