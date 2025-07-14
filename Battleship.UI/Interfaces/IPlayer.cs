using Battleship.UI.Enums;
using Battleship.UI.Ships;
namespace Battleship.UI.Interfaces
{
    public interface IPlayer
    {
        bool IsHuman { get; }
        string playerName { get; }
        public string[] playerRadar { get; set; }
        public string[] playerCombatRadar { get; set; }
        public Ship[] fleet { get; set; } 
    }
}
