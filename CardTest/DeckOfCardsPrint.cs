using System;
using GameUtils;

namespace CardTest
{
    static class DeckOfCardsPrint
    {
        private static void Main()
        {
            var deckOfCards = new DeckOfCards();
            deckOfCards.Shuffle();
            for (var i = 0; i < 52; i++)
            {
                Console.Write($"{deckOfCards.DealCard(),-19}");
                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}