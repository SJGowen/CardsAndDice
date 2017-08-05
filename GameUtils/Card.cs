namespace Cards
{
    public class Card
    {
        public string Face { get; }
        public string Suit { get; }
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
        public override string ToString() => $"{Face} of {Suit}";
    }
}
