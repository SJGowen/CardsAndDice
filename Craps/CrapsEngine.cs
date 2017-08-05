using Dices;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Craps
{
    public class CrapsEngine
    {
        private List<int> validThrows = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public enum Status { Continue, Win, Loose }

        public Status GetStatusFromFirstThrow(int firstThrowPoints)
        {
            if (!validThrows.Contains(firstThrowPoints)) throw new ArgumentOutOfRangeException("Invalid first throw points");
            var result = Status.Continue;
            switch ((Dice.DiceNames)firstThrowPoints)
            {
                case Dice.DiceNames.Seven:
                case Dice.DiceNames.YoLeven:
                    result = Status.Win;
                    break;
                case Dice.DiceNames.SnakeEyes:
                case Dice.DiceNames.Trey:
                case Dice.DiceNames.BoxCars:
                    result = Status.Loose;
                    break;
                default:
                    result = Status.Continue;
                    Console.WriteLine($"Score to get is {firstThrowPoints}");
                    break;
            }
            return result;
        }

        public Status GetStatusFromLaterThow(int firstThrowPoints, int laterThrowPoints)
        {
            if (!validThrows.Contains(firstThrowPoints)) throw new ArgumentOutOfRangeException("Invalid first throw points");
            if (!validThrows.Contains(laterThrowPoints)) throw new ArgumentOutOfRangeException("Invalid later throw points");
            var result = Status.Continue;
            if (laterThrowPoints == firstThrowPoints)
            {
                result = Status.Win;
            }
            else if (laterThrowPoints == (int)Dice.DiceNames.Seven)
            {
                result = Status.Loose;
            }
            return result;
        }
    }
}