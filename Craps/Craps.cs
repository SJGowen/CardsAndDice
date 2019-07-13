using System;
using GameUtils;
using static Craps.CrapsEngine;

namespace Craps
{
    internal static class Craps
    {
        private static readonly Dice Dice = new Dice();

        private static void Main()
        {
            var firstThrowPoints = Dice.Roll2Dice();
            var game = new CrapsEngine();
            var gameStatus = game.GetStatusFromFirstThrow(firstThrowPoints);

            while (gameStatus == Status.Continue)
            {
                var laterTrowPoints = Dice.Roll2Dice();
                gameStatus = game.GetStatusFromLaterThrow(firstThrowPoints, laterTrowPoints);
            }

            Console.ForegroundColor = (gameStatus == Status.Win) ? ConsoleColor.Yellow : ConsoleColor.Red;
            Console.WriteLine(gameStatus == Status.Win ? "Player Wins" : "Player Looses");
            Console.ReadKey();
        }
    }
}
