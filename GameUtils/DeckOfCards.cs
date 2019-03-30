using System;

namespace GameUtils
{
    public class DeckOfCards
    {
        private static readonly Random RandomNumbers = new Random();
        private const int NumberOfCards = 52;
        private readonly Card[] _deck = new Card[NumberOfCards];
        private int _currentCard;

        public DeckOfCards()
        {
            for (var count = 0; count < _deck.Length; count++)
            {
                _deck[count] = new Card(CardSets.Faces[count % 13], CardSets.Suits[count / 13]);
            }
        }

        public void Shuffle()
        {
            _currentCard = 0;
            for (var card = 0; card < _deck.Length; card++)
            {
                var swap = RandomNumbers.Next(NumberOfCards);
                var temp = _deck[card];
                _deck[card] = _deck[swap];
                _deck[swap] = temp;
            }
        }

        public Card DealCard()
        {
            return _currentCard < _deck.Length ? _deck[_currentCard++] : null;
        }
    }
}
