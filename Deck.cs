using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
        public List<string> Suits { get; set; }

        public List<string> Ranks { get; set; }

        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            Suits = new List<string>() { "Hearts", "Clubs", "Spades", "Diamonds" };
            Ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            foreach (var suit in Suits)
            {
                foreach (var rank in Ranks)
                {
                    var card = new Card();

                    card.Rank = rank;
                    card.Suit = suit;
                    if (card.Rank.ToLower() == "ace")
                    {
                        card.Value = 11;
                    }
                    else if (card.Rank.ToLower() == "queen" || card.Rank.ToLower() == "king" || card.Rank.ToLower() == "jack")
                    {
                        card.Value = 10;
                    }
                    else
                    {
                        card.Value = int.Parse(card.Rank);
                    }
                    if (card.Suit == "diamonds" || card.Suit == "hearts")
                        card.Color = "red";
                    else
                        card.Color = "black";

                    Cards.Add(card);
                }
            }
        }

        public void ShuffleDeck()
        {
            for (int i = Cards.Count - 1; i >= 0; i--)
            {
                var j = new Random().Next(Cards.Count);
                var temp = Cards[j];
                Cards[j] = Cards[i];
                Cards[i] = temp;
            }
        }
    }
}