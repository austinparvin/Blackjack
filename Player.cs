using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Player
    {
        //Cards in the current hand
        public string Name { get; set; }

        public List<Card> Hand { get; set; }

        // Total of the current hand
        public int HandValue { get; set; }

        public void DealACard(List<Card> deck)
        {
            Hand.Add(deck[0]);
            HandValue += deck[0].Value;
            deck.RemoveAt(0);
        }

        public void ShowHand()
        {
            foreach (var card in Hand)
            {
                Console.WriteLine(card.DisplayCard());
            }
        }

        public void ShowHandValue()
        {
            Console.WriteLine($"{Name}'s current total hand value is: {HandValue}");
        }

    }
}