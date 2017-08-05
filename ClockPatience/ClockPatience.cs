using System;

namespace Cards
{
    class ClockPatience
    {
        static Card[,] FaceDownCards = new Card[4, 13];

        static void Main(string[] args)
        {
            var myDeckOfCards = new DeckOfCards();
            myDeckOfCards.Shuffle();
            DealCards(myDeckOfCards);

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

            if (faceUpCards < 52)
            {
                Console.WriteLine($"You have turned over {faceUpCards} Cards...");
            }
            else
            {
                Console.WriteLine("Congratulations... You beat the 'CLOCK'...");
            }
            Console.ReadLine();
        }

        private static void DealCards(DeckOfCards myDeckOfCards)
        {
            for (int set = 0; set < 4; set++)
            {
                for (int hour = 0; hour < 13; hour++)
                {
                    FaceDownCards[set, hour] = myDeckOfCards.DealCard();
                }
            }
        }

        private static Card GetClockFaceCard(string cardToGet)
        {
            Card result = null;
            var numericalCardToGet = Array.IndexOf(CardSets.faces, cardToGet);
            var set = 3;
            while ((set >= 0) && (FaceDownCards[set, numericalCardToGet] == null))
            {
                set--;
            }
            if (set >= 0)
            {
                result = FaceDownCards[set, numericalCardToGet];
                FaceDownCards[set, numericalCardToGet] = null;
            }
            return result;
        }
    }
}
