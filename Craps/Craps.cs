using Dices;
using System;
using static Craps.CrapsEngine;

namespace Craps
{
    class Craps
    {
        private static Dice dice = new Dice();

        static void Main(string[] args)
        {
            var firstThrowPoints = dice.Roll2Dice();
            var game = new CrapsEngine();
            var gameStatus = game.GetStatusFromFirstThrow(firstThrowPoints);

            while (gameStatus == Status.Continue)
            {
                var laterTrowPoints = dice.Roll2Dice();
                gameStatus = game.GetStatusFromLaterThow(firstThrowPoints, laterTrowPoints);
            }

            var message = (gameStatus == Status.Win) ? "Player Wins" : "Player Looses";
            Console.WriteLine(message);
        }

    }
}
