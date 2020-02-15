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
      var isPlaying = true;
      game.CreatePlayers();

      while (isPlaying)
      {
        game.ResetHands();
        deck.ShuffleDeck();
        game.DealHands(deck);
        game.GetPlayerFinalHand(deck);
        game.GetDealerFinalHand(deck);
        game.CalculateWinners();
        isPlaying = game.AskPlayAgain(isPlaying);
      }
    }
  }
}