using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJackModel;

namespace BlackJackAPI.Controllers
{
    [Route("api/[controller]")]
    public class BlackJackController : Controller
    {
       
        [HttpGet("{playerName}")]
        public Game StartGame(string playerName)
        {
            Deck deck = new Deck();
            deck.BuildDeck();
            deck.Shuffel();

            Dealer dealer = new Dealer(deck, new List<Card>() { deck.DrawCard(), deck.DrawCard() });
            Player player = new Player(playerName, new List<Card>() { deck.DrawCard(), deck.DrawCard() });
            return new Game(dealer, player);
        }

        [HttpPost("{gameBlackJack}")]
        public Game PlayGame(Game gameBlackJack)
        {
            Dealer Dealer = gameBlackJack.Dealer;
            Player Player = gameBlackJack.Player;
            Dealer.Hand.Where(x => x.face.Equals(Face.Ace)).ToList().ForEach(x => x.value = 11);
            Player.Hand.Where(x => x.face.Equals(Face.Ace)).ToList().ForEach(x => x.value = 11);

            if (Dealer.Hand.Sum(x => x.value).Equals(21))
            {
                gameBlackJack.Message = MsgConstant.DealerWin;
                return gameBlackJack;
            }
            if (Player.Hand.Sum(x => x.value).Equals(21))
            {
                gameBlackJack.Message= MsgConstant.PlayerWin;
                return gameBlackJack;
            }
            switch (gameBlackJack.Userchoose.ToUpper())
            {
                case MsgConstant.Hit:
                    Player.Hand.Add(gameBlackJack.Dealer.Deck.DrawCard());
                    gameBlackJack.Message = gameBlackJack.Player.Hand.Sum(x => x.value) > 21 ? MsgConstant.PlayerBust : MsgConstant.Continue;
                    break;
                case MsgConstant.Stick:
                    while (Dealer.Hand.Sum(x => x.value) <= 17)
                        Dealer.Hand.Add(gameBlackJack.Dealer.Deck.DrawCard());

                    gameBlackJack.Message = gameBlackJack.Dealer.Hand.Sum(x => x.value) > 21 ? MsgConstant.DealerBust 
                        : (Dealer.Hand.Sum(x => x.value) > Player.Hand.Sum(x => x.value) ? MsgConstant.DealerWin : MsgConstant.PlayerWin);
                    break;
                default: gameBlackJack.Message = MsgConstant.ValidOption; break;
            }
            return gameBlackJack;
        }
    }
}
