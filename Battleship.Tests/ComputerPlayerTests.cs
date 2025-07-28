using Battleship.UI;
using Battleship.UI.Implementations;
using Battleship.UI.Interfaces;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class ComputerPlayerTests
    {
        public static IPlayer GetComputerPlayer()
        {
            return new ComputerPlayer();
        }
        [Test]
        public static void CorrectChoiceAfterHit()
        {
            var p1 = GetComputerPlayer();
            var p2 = GetComputerPlayer();

            GameManager manager = new GameManager(p1, p2);

            p1.playerRadar = new string[100];
            p2.playerRadar = new string[100];

            p1.playerCombatRadar = new string[100];

            p1.playerCombatRadar[45] = "H";
            p1.playerCombatRadar[46] = "M";

            var reuslt = manager.

            Assert.That()

        }
    }
}
