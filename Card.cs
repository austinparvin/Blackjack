namespace Blackjack
{
  public class Card
  {
    // rank
    public string Rank { get; set; }
    // suit 
    public string Suit { get; set; }
    // color
    public string Color { get; set; }
    // Value
    public int Value { get; set; }

    //Method
    public string DisplayCard()
    {
      return $"{Rank} of {Suit}";
    }



  }
}