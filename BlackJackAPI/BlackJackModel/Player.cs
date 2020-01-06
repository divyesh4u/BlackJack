using System;
using System.Collections.Generic;

namespace BlackJackModel
{
    public class Player
    {
        public Player(string name, List<Card> hand)
        {
            Name = name;
            Hand = hand;

        }
        public string Name { get;private set; }
      
        public List<Card> Hand { get; set; }
    }
}
