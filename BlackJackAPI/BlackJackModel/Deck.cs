using System;
using System.Collections.Generic;

namespace BlackJackModel
{
    public class Deck 
    {
        public List<Card> cards = new List<Card>();
        public void Shuffel()
        {
            Random random = new Random();
            int totalCard = cards.Count;
            while(totalCard>1)
            {
                totalCard--;
                var randomCard = random.Next(totalCard + 1);
                var card = cards[randomCard];
                cards[randomCard] = cards[totalCard];
                cards[totalCard] =card;
            }
        }

        public void BuildDeck()
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    cards.Add(new Card { suit = (Suit)i, face = (Face)j });
                    cards[cards.Count - 1].value = (j <= 8 ? j + 1 : 10);
                }
            }
        }

        public Card DrawCard()
        {
            var card = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return card;
        }
    }
}
