using Battleship.UI.Enums;
namespace Battleship.UI.Interfaces
{
    public interface IPlayer
    {
        bool IsHuman { get; }
        string SelectShipType();
        //Coordinates PlaceShipCoordinate();
        string GetPlayerName();
        char ChooseShipOrientation();
        Direction GetPlacementDirection();
        string SelectAttackCoordiante();
    }
}
