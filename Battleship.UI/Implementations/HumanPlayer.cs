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
            return ConsoleIO.GetPlayerName("\n>> Authorization required. Enter Commander name: ");
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
