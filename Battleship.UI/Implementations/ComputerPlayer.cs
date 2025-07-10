using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
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

        public char ChooseShipOrientation()
        {
            throw new NotImplementedException();
        }

        public Direction GetPlacementDirection()
        {
            throw new NotImplementedException();
        }

        public string GetPlayerName()
        {
            return "\n>>> Opponent selected: Iron Depth [AUTONOMOUS COMBAT SYSTEM v3.4]" + 
                "\n>>> Initializing strategic modules... Ready for engagement.";
        }

        public string PlaceShipCoordinate()
        {
            throw new NotImplementedException();
        }

        public string SelectAttackCoordiante()
        {
            throw new NotImplementedException();
        }

        public string SelectShipType()
        {
            throw new NotImplementedException();
        }
    }
}
