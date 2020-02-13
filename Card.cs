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

    //Method
    public string DisplayCard()
    {
      return $"{Rank} of {Suit}";
    }

    public int GetCardValue()
    {
      if (Rank.ToLower() == "ace") { 
          return 11;
      } else if (Rank.ToLower() == "queen" || Rank.ToLower() == "king" || Rank.ToLower() == "jack"){
          return 10;
      } else {
          return int.Parse(Rank);
      }
    }
  }
}