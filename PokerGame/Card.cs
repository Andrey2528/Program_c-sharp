using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    class Card
    {
        public enum SUIT
        {
            HEARTS,
            SPADES,
            DIAMONDS,
            CLUBS
        }

        public enum VALUE
        {
            NINE = 9, TEN, JACK, QUEEN, KING, ACE
        }

        //properties
        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }
    }
}
