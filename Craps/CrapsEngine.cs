using System;
using System.Collections.Generic;
using GameUtils;

namespace Craps
{
    public class CrapsEngine
    {
        private readonly List<int> _validThrows = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public enum Status { Continue, Win, Loose }

        public Status GetStatusFromFirstThrow(int firstThrowPoints)
        {
            if (!_validThrows.Contains(firstThrowPoints)) throw new ArgumentOutOfRangeException(nameof(firstThrowPoints));
            switch ((Dice.DiceNames)firstThrowPoints)
            {
                case Dice.DiceNames.Seven:
                case Dice.DiceNames.YoLeven:
                    return Status.Win;
                case Dice.DiceNames.SnakeEyes:
                case Dice.DiceNames.Trey:
                case Dice.DiceNames.BoxCars:
                    return Status.Loose;
                default:
                    Console.WriteLine($"Score to get is {firstThrowPoints}");
                    return Status.Continue;
            }
        }

        public Status GetStatusFromLaterThrow(int firstThrowPoints, int laterThrowPoints)
        {
            if (!_validThrows.Contains(firstThrowPoints)) throw new ArgumentOutOfRangeException(nameof(firstThrowPoints));
            if (!_validThrows.Contains(laterThrowPoints)) throw new ArgumentOutOfRangeException(nameof(firstThrowPoints));
            if (laterThrowPoints == firstThrowPoints)
            {
                return Status.Win;
            }
            else if (laterThrowPoints == (int)Dice.DiceNames.Seven)
            {
                return Status.Loose;
            }
            return Status.Continue; 
        }
    }
}