using Battleship.UI.Enums;
namespace Battleship.UI.Interfaces
{
    public interface IPlayer
    {
        bool IsHuman { get; }
        string playerName { get; }
        public string[] playerRadar { get; set; }
    }
}
