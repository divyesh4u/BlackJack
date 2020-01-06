using BlackJackModel;
using BlackJackAPI.Controllers;
using BlackJackAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace BlackJackAPITest
{
    [TestClass]
    public class BlackJackControllTest
    {
        Deck deck;

        [TestInitialize]
        public void SetUp()
        {
            deck = new Deck();
            deck.BuildDeck();
            deck.Shuffel();
        }


        [TestMethod]
        public void Game_Start_Success_Test()
        {
            BlackJackController blackJackController = new BlackJackController();
            Game gameBlackJack= blackJackController.StartGame("Player1");
            Assert.AreEqual(2, gameBlackJack.Dealer.Hand.Count);
            Assert.AreEqual(2, gameBlackJack.Player.Hand.Count);
            Assert.AreEqual(48, gameBlackJack.Dealer.Deck.cards.Where(x => (x.suit.Equals(Suit.Club) || x.suit.Equals(Suit.Heart) || x.suit.Equals(Suit.Diamond) || x.suit.Equals(Suit.Sprade))
                            && (x.face.Equals(Face.Ace) || x.face.Equals(Face.Two) || x.face.Equals(Face.Three) || x.face.Equals(Face.Four) || x.face.Equals(Face.Five) || x.face.Equals(Face.Six) || x.face.Equals(Face.Seven) || x.face.Equals(Face.Eight) || x.face.Equals(Face.Nine) || x.face.Equals(Face.Ten) || x.face.Equals(Face.Jack) || x.face.Equals(Face.Queen) || x.face.Equals(Face.King))
                            && x.value >= 1 && x.value <= 10).Count());
        }

        [TestMethod]
        public void Game_PlayerWin_Success_Test()
        {
            BlackJackController blackJackController = new BlackJackController();
            Player player = new Player("Player1", new List<Card>() { new Card { face = Face.Ace, value = 1, suit = Suit.Club }, new Card { face = Face.Queen, value = 10, suit = Suit.Club } });
            Dealer dealer = new Dealer(deck, new List<Card>() { new Card { face = Face.Six, value = 6, suit = Suit.Club }, new Card { face = Face.Two, value = 2, suit = Suit.Club } });
            Game game = new Game(dealer, player);
            Game actualResult= blackJackController.PlayGame(game);
            Assert.AreEqual(MsgConstant.PlayerWin, actualResult.Message);
        }

        [TestMethod]
        public void Game_PlayerBust_Success_Test()
        {
            BlackJackController blackJackController = new BlackJackController();
            Player player = new Player("Player1", new List<Card>() { new Card { face = Face.King, value = 10, suit = Suit.Club }, new Card { face = Face.Queen, value = 10, suit = Suit.Club } });
            Dealer dealer = new Dealer(deck, new List<Card>() { new Card { face = Face.Six, value = 6, suit = Suit.Club }, new Card { face = Face.Two, value = 2, suit = Suit.Club } });
            Game game = new Game(dealer, player);
            game.Userchoose = MsgConstant.Hit;
            Game actualResult = blackJackController.PlayGame(game);
            Assert.AreEqual(MsgConstant.PlayerBust, actualResult.Message);
        }

        [TestMethod]
        public void Game_DealerWin_Success_Test()
        {
            BlackJackController blackJackController = new BlackJackController();
            Player player = new Player("Player1", new List<Card>() { new Card { face = Face.Six, value = 6, suit = Suit.Club }, new Card { face = Face.Two, value = 2, suit = Suit.Club } });
            Dealer dealer = new Dealer(null, new List<Card>() { new Card { face = Face.Ace, value = 1, suit = Suit.Club }, new Card { face = Face.Queen, value = 10, suit = Suit.Club } });

            Game game = new Game(dealer, player);
            Game actualResult = blackJackController.PlayGame(game);
            Assert.AreEqual(MsgConstant.DealerWin, actualResult.Message);
        }

        [TestMethod]
        public void Player_HitOption_Success_Test()
        {
            BlackJackController blackJackController = new BlackJackController();
            Game gameBlackJack= blackJackController.StartGame("Player1");
            gameBlackJack.Userchoose = MsgConstant.Hit;

            gameBlackJack = blackJackController.PlayGame(gameBlackJack);

            int dealerCardTotalValue = gameBlackJack.Dealer.Hand.Sum(x => x.value);
            int playerCardTotalValue = gameBlackJack.Player.Hand.Sum(x => x.value);
            Assert.IsNotNull(gameBlackJack);

                   
            if (dealerCardTotalValue == 21 && gameBlackJack.Dealer.Hand.Count == 2)
                Assert.AreEqual(gameBlackJack.Message, MsgConstant.DealerWin);

            if (playerCardTotalValue == 21 && gameBlackJack.Player.Hand.Count==2)
                Assert.AreEqual(gameBlackJack.Message,MsgConstant.PlayerWin);

            if (playerCardTotalValue > 21)
                Assert.AreEqual(gameBlackJack.Message, MsgConstant.PlayerBust);
            else
                Assert.AreEqual(gameBlackJack.Message, MsgConstant.Continue);
            
        }


        [TestMethod]
        public void Player_StickOption_Success_Test()
        {
            BlackJackController blackJackController = new BlackJackController();
            Game gameBlackJack = blackJackController.StartGame("Player1");
            gameBlackJack.Userchoose = MsgConstant.Stick;

            gameBlackJack = blackJackController.PlayGame(gameBlackJack);

            int dealerCardTotalValue = gameBlackJack.Dealer.Hand.Sum(x => x.value);
            int playerCardTotalValue = gameBlackJack.Player.Hand.Sum(x => x.value);
            Assert.IsNotNull(gameBlackJack);
         
            if (dealerCardTotalValue == 21 && gameBlackJack.Dealer.Hand.Count == 2)
                Assert.AreEqual(gameBlackJack.Message, MsgConstant.DealerWin);

            if (playerCardTotalValue == 21 && gameBlackJack.Player.Hand.Count == 2)
                Assert.AreEqual(gameBlackJack.Message, MsgConstant.PlayerWin);

            if (playerCardTotalValue > 21)
                Assert.AreEqual(gameBlackJack.Message, MsgConstant.PlayerBust);

            if (dealerCardTotalValue > 21)
                Assert.AreEqual(gameBlackJack.Message, MsgConstant.DealerBust);

            if (playerCardTotalValue > dealerCardTotalValue)
                Assert.AreEqual(gameBlackJack.Message, MsgConstant.PlayerWin);
            else
                Assert.AreEqual(gameBlackJack.Message, MsgConstant.DealerWin);
        }

        [TestMethod]
        public void Player_InValidOption_Success_Test()
        {
            BlackJackController blackJackController = new BlackJackController();
            Game actualResult = blackJackController.StartGame("Player1");
            actualResult.Userchoose = "zzz";

            blackJackController.PlayGame(actualResult);
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualResult.Message, MsgConstant.ValidOption);
        }
    }
}
