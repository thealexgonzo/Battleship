using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Battleship.UI;
using Battleship.UI.Enums;
using Battleship.UI.Implementations;
using Battleship.UI.Interfaces;
using Battleship.UI.IO;
using Battleship.UI.Ships;

namespace Battleship.UI
{
    public class GameManager
    {
        public Ship[] fleet = new Ship[5];
        public IPlayer player1 { get; private set; }
        public IPlayer player2 { get; private set; }

        public GameManager(IPlayer p1, IPlayer p2)
        {
            player1 = p1;
            player2 = p2;

            fleet[0] = new AircraftCarrier();
            fleet[1] = new Battleship.UI.Ships.Battleship();
            fleet[2] = new Cruiser();
            fleet[3] = new Submarine();
            fleet[4] = new Destroyer();
        }

        public void SetUpPlayer1Grid()
        {
            ConsoleIO.InitialiseEmptyCombatRadar(player1);

            for (int i = 0; i < fleet.Length; i++)
            {
                fleet[i].shipCoordinates = GetShipCoordinates(fleet[i], fleet[i].size);
                GameGrid.DisplayBattleGrid(fleet[i].shipCoordinates);
            }
        }

        public string[] GetShipCoordinates(Ship ship, int size)
        {
            Console.WriteLine($"\nShip to place: {ship.name} | Size: {ship.size}");
            Coordinates coordinates = ConsoleIO.GetCurrentShipFirstCoordinate();
            Orientation orientation = ConsoleIO.GetShipOrientation("Enter ship orientation: 'H' for horizontal or 'V' for vertical: ");
            Direction direction = ConsoleIO.GetShipDirection("\nSpecify direction of deployment, Commander — Up, Down, Left, or Right.");

            ConsoleIO.AnyKey();

            ShipCoordinates currentShip = new ShipCoordinates(ship, coordinates, orientation, direction);

            return currentShip.shipCoordinates;
        }
    }
}
