
namespace BlackJackModel
{
    public enum Suit
    {
        Club,
        Diamond,
        Heart,
        Sprade
    }
    public enum Face
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        public Suit suit;
        public Face face;
        public int value;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Card card = (Card)obj;

            if (!this.GetType().Equals(card.GetType()))
                return false;

            if (this.face == card.face && this.suit == card.suit && this.value == card.value)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return 133 * this.face.GetHashCode() * this.suit.GetHashCode() * this.value.GetHashCode();
        }

    }
}
