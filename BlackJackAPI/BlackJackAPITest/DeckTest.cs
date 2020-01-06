using BlackJackModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BlackJackAPITest
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void Build_Deck_Success_Test()
        {
            List<Card> expectedDeck = new List<Card>();
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    expectedDeck.Add(new Card { suit = (Suit)i, face = (Face)j });
                    expectedDeck[expectedDeck.Count - 1].value = (j <= 8 ? j + 1 : 10);
                }
            }

            Deck deck = new Deck();
            deck.BuildDeck();

            Assert.AreEqual(expectedDeck.Count, deck.cards.Count);
            for (int i = 0; i < expectedDeck.Count; i++)
            {
                Assert.AreEqual(expectedDeck[i], deck.cards[i]);
            }
        }

        [TestMethod]
       public void Deck_Shuffel_Success_Test()
       {
            Deck deck = new Deck();
            deck.BuildDeck();
            deck.Shuffel();
            
            Assert.AreEqual(52, deck.cards.Where(x => (x.suit.Equals(Suit.Club) || x.suit.Equals(Suit.Heart) || x.suit.Equals(Suit.Diamond) || x.suit.Equals(Suit.Sprade))
                            && (x.face.Equals(Face.Ace) || x.face.Equals(Face.Two) || x.face.Equals(Face.Three) || x.face.Equals(Face.Four) || x.face.Equals(Face.Five) || x.face.Equals(Face.Six) || x.face.Equals(Face.Seven) || x.face.Equals(Face.Eight) || x.face.Equals(Face.Nine) || x.face.Equals(Face.Ten) || x.face.Equals(Face.Jack) || x.face.Equals(Face.Queen) || x.face.Equals(Face.King))
                            && x.value >= 1 && x.value <= 10).Count());
            Assert.AreEqual(13, deck.cards.Where(x => x.suit.Equals(Suit.Heart) && (x.value >= 1 && x.value <= 10)).Count());
            Assert.AreEqual(13, deck.cards.Where(x => x.suit.Equals(Suit.Diamond) && (x.value >= 1 && x.value <= 10)).Count());
            Assert.AreEqual(13, deck.cards.Where(x => x.suit.Equals(Suit.Sprade) && (x.value >= 1 && x.value <= 10)).Count());
            Assert.AreEqual(13, deck.cards.Where(x => x.suit.Equals(Suit.Club) && (x.value >= 1 && x.value <= 10)).Count());
        }

        [TestMethod]
        public void Draw_Card_Success_Test()
        {
            Deck deck = new Deck();
            deck.BuildDeck();
            deck.Shuffel();

            var card= deck.DrawCard();
            Assert.IsNotNull(card);
            Assert.IsTrue(card.value>=1 && card.value<=13);
            Assert.IsTrue(card.suit.Equals(Suit.Club) || card.suit.Equals(Suit.Diamond) || card.suit.Equals(Suit.Heart) || card.suit.Equals(Suit.Sprade));
            Assert.IsTrue((card.face.Equals(Face.Ace) || card.face.Equals(Face.Two) || card.face.Equals(Face.Three) || card.face.Equals(Face.Four) || card.face.Equals(Face.Five) || card.face.Equals(Face.Six) || card.face.Equals(Face.Seven) || card.face.Equals(Face.Eight) || card.face.Equals(Face.Nine) || card.face.Equals(Face.Ten) || card.face.Equals(Face.Jack) || card.face.Equals(Face.Queen) || card.face.Equals(Face.King))); 
            
        }
    }
}
