using System;
using System.Collections.Generic;

namespace Blackjack
{
  class Program
  {
    static void Main(string[] args)
    {
      var game = new Game();
      var deck = new Deck();
      
      game.CreatePlayers();

      while (game.isPlaying)
      {
        game.ResetHands();
        deck.ShuffleDeck();
        game.DealHands(deck);
        game.GetPlayerFinalHand(deck);
        game.GetDealerFinalHand(deck);
        game.CalculateWinners();
        game.AskPlayAgain();
      }
    }
  }
}