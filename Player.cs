using System.Collections.Generic;

namespace Blackjack
{
  public class Player
  {
    //Cards in the current hand
    public List<Card> Hand { get; set; }

    // Total of the current hand
    public int HandValue { get; set; }



    // public void DealACard() {
    //     DealACard() {
    //       Hand.Add(deck[0]);
    //       HandValue += deck[0].GetCardValue();
    //       deck.RemoveAt(0);
        
    // }

  }
}