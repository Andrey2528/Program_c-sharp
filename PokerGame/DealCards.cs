using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerGame
{
    class DealCards : DeckOfCard
    {
        private Card[] playerHand;
        private Card[] computerHand;
        private Card[] sortedPlayerHand;

        public DealCards()
        {
            playerHand = new Card[5];
            sortedPlayerHand = new Card[5];
            computerHand = new Card[5];
        }

        public void Deal()
        {
            DeckOfCards();
            setUpDeck(); //create the deck of cards and shuffle them
            getHand();
            sortCards();
            evaluateHands();
        }

        public void getHand()
        {
            //5 cards for the player
            for (int i = 0; i < 5; i++)
                playerHand[i] = getDeck[i];

            //5 cards for the computer
            for (int i = 5; i < 10; i++)
                computerHand[i - 5] = getDeck[i];
        }

        public void sortCards()
        {
            var queryPlayer = from hand in playerHand
                              orderby hand.MyValue
                              select hand;
            var index = 0;
            foreach (var element in queryPlayer.ToList())
            {
                sortedPlayerHand[index] = element;
                index++;
            }

            index = 0;
        }
        public void evaluateHands()
        {
            //create player's computer's evaluation objects (passing SORTED hand to constructor)
            HandEvaluator playerHandEvaluator = new HandEvaluator(sortedPlayerHand);

            //get the player;s and computer's hand
            Hand playerHand = playerHandEvaluator.EvaluateHand();
        }
    }
}
