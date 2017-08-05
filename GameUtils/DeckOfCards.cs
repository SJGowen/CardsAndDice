using System;

namespace Cards
{
    public class DeckOfCards
    {
        private static Random randomNumbers = new Random();
        private const int NumberOfCards = 52;
        private Card[] Deck = new Card[NumberOfCards];
        private int currentCard = 0;

        public DeckOfCards()
        {
            for (int count = 0; count < Deck.Length; count++)
            {
                Deck[count] = new Card(CardSets.faces[count % 13], CardSets.suits[count / 13]);
            }
        }

        public void Shuffle()
        {
            currentCard = 0;
            for (var card = 0; card < Deck.Length; card++)
            {
                var swap = randomNumbers.Next(NumberOfCards);
                Card temp = Deck[card];
                Deck[card] = Deck[swap];
                Deck[swap] = temp;
            }
        }

        public Card DealCard()
        {
            if (currentCard < Deck.Length)
            {
                return Deck[currentCard++];
            }
            else
            {
                return null;
            }
        }
    }
}
