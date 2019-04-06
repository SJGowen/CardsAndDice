using System;
using GameUtils;

namespace ClockPatience
{
    internal static class ClockPatience
    {
        private static readonly Card[,] FaceDownCards = new Card[4, 13];

        private static void Main()
        {
            var deckOfCards = new DeckOfCards();
            deckOfCards.Shuffle();
            Deal13SetsOf4(deckOfCards);

            var faceUpCards = 0;
            var face = "King";
            var cardInPlay = GetClockFaceCard(face);
            while (cardInPlay != null)
            {
                faceUpCards++;
                Console.WriteLine($"Taken from the {face}'s position is the '{cardInPlay}'.");
                face = cardInPlay.Face;
                cardInPlay = GetClockFaceCard(face);
            }

            if (faceUpCards == 52)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CONGRATULATIONS... You beat the 'CLOCK'...");
            }
            else
            {
               Console.WriteLine($"You have turned over {faceUpCards} Cards...");
            }
            Console.ReadKey();
        }

        private static void Deal13SetsOf4(DeckOfCards deckOfCards)
        {
            for (var set = 0; set < 4; set++)
            {
                for (var hour = 0; hour < 13; hour++)
                {
                    FaceDownCards[set, hour] = deckOfCards.DealCard();
                }
            }
        }

        private static Card GetClockFaceCard(string cardToGet)
        {
            var numericalCardToGet = Array.IndexOf(CardSets.Faces, cardToGet);
            var set = 3;
            while ((set >= 0) && (FaceDownCards[set, numericalCardToGet] == null))
            {
                set--;
            }

            if (set < 0) return null;
            var result = FaceDownCards[set, numericalCardToGet];
            FaceDownCards[set, numericalCardToGet] = null;
            return result;
        }
    }
}
