using System.Collections.Generic;

namespace BlackJackModel
{
    public class Dealer
    {
        public Dealer(Deck deck, List<Card> hand)
        {
            Deck = deck;
            Hand = hand;
        }
        public List<Card> Hand { get; set; }

        public Deck Deck { get;private set; }
    }
}
