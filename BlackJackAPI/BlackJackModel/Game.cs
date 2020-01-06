
namespace BlackJackModel
{
    public class Game
    {
        public Game(Dealer dealer, Player player)
        {
            Dealer = dealer;
            Player = player;
        }

        public string Userchoose { get; set;} 
        public string Message { get; set; }
        public Player Player { get; set; }
        public Dealer Dealer { get; set; }
      
    }
}
