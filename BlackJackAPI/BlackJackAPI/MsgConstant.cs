using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackAPI
{
    static public class MsgConstant
    {
       
        public const string PlayerBust = "the Player is bust and lost hence Dealer wins";
        public const string DealerBust= "the Dealer is bust and lost hence Player wins";

        public const string PlayerWin = "the Player is winner";
        public const string DealerWin = "the Dealer is winner";
 
        public const string Hit = "HIT";
        public const string Stick = "STICK";
        public const string ValidOption = "choose valid option Stick or hit";
        public const string Continue = "Continue.. Select Stick or Hit";
    }
}
