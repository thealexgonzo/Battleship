using Battleship.UI.Factories;
using Battleship.UI.Game;
using Battleship.UI.Interfaces;
using Battleship.UI.IO;

ConsoleIO.DisplayGameTitle();

Console.ForegroundColor = ConsoleColor.Cyan;
IPlayer player1 = PlayerFactory.GetPlayerType("Commander, identify yourself: (H)uman operative or (C)omputer-controlled unit? ");
if (player1.IsHuman) player1.GetPlayerName();
else Console.WriteLine(player1.GetPlayerName());

Console.ForegroundColor = ConsoleColor.DarkYellow;
IPlayer player2 = PlayerFactory.GetPlayerType("Who’s your adversary? A (H)uman tactician or an AI-controlled war machine? ");
if (player2.IsHuman) player2.GetPlayerName();
else Console.WriteLine(player2.GetPlayerName());
Console.ResetColor();

App.Run(player1, player2);

