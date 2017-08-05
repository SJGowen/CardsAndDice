using System;

namespace Cards
{
    class DeckOfCardsPrint
    {
        static void Main(string[] args)
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
        }
    }
}