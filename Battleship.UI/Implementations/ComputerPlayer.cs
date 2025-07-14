using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
using Battleship.UI.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Implementations
{
    public class ComputerPlayer : IPlayer
    {
        public bool IsHuman { get { return false; } }
        public string playerName { get { return "Iron Depth"; } }
        public string[] playerRadar { get; set; }
        public string[] playerCombatRadar { get; set; }
        public Ship[] fleet { get; set; }
    }
}
