using System;

namespace Dices
{
    public class Dice
    {
        private Random randomNumbers = new Random();

        public enum DiceNames
        {
            SnakeEyes = 2,
            Trey = 3,
            Seven = 7,
            YoLeven = 11,
            BoxCars = 12
        }

        public int RollADice()
        {
            var die = randomNumbers.Next(1, 7);

            Console.WriteLine($"Player rolled {die}");
            return die;
        }

        public int Roll2Dice()
        {
            var die1 = randomNumbers.Next(1, 7);
            var die2 = randomNumbers.Next(1, 7);

            var sum = die1 + die2;

            Console.WriteLine($"Player rolled {die1} + {die2} = {(DiceNames)sum}");
            return sum;
        }
    }
}
