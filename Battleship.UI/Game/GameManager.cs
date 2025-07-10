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
            ConsoleIO.InitialiseCombatRadar(player1);

            GameGrid.DisplayBattleGrid(coordinate, orientation, direction);

            Console.WriteLine("\nCoordinates should be from A-J (column) and 1-10 (row).");
            Console.WriteLine("You will be prompted for the starting coordinate and the direction of placement.");

            Coordinates acCoords;
            Orientation acOrientation;
            Direction acDirection;

            for (int i = 0; i < fleet.Length; i++)
            {
                Console.WriteLine($"Ship to place: {fleet[i].name} | Size: {fleet[i].size}");
                acCoords = ConsoleIO.GetCurrentShipFirstCoordinate();
                acOrientation = ConsoleIO.GetShipOrientation("Enter ship orientation: 'H' for horizontal or 'V' for vertical: ");
                acDirection = ConsoleIO.GetShipDirection("\nSpecify direction of deployment, Commander — Up, Down, Left, or Right.");
                ConsoleIO.AnyKey();
            }
        }
    }
}
