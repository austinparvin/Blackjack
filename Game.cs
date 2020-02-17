using System;
using System.Collections.Generic;

namespace Blackjack
{
  public class Game
  {
    public string UserInput { get; set; }

    public List<Player> Players { get; set; }
    // Methods

    public bool isPlaying { get; set; }

    public Game()
    {
      Players = new List<Player>();

      // Creating the Dealer
      var dealer = new Player();
      dealer.Name = "dealer";
      dealer.Hand = new List<Card>();
      dealer.HandValue = 0;
      Players.Add(dealer);

      isPlaying = true;

      var deck = new Deck();
    }
    // Create a players

    public void ResetHands()
    {
      foreach (Player p in Players)
      {
        p.Hand = new List<Card>();
        p.HandValue = 0;
      }
    }
    public void DealHands(Deck deck)
    {
      foreach (Player p in Players)
      {
        p.DealACard(deck.Cards);
        p.DealACard(deck.Cards);

        if (p.Name != "dealer")
        {
          Console.WriteLine($"{p.Name} drew:");
          Console.WriteLine("------------------------");
          p.ShowHand();
          Console.WriteLine("------------------------");
          p.ShowHandValue();
          Console.WriteLine("");
        }
        else
        {
          Console.WriteLine($"{p.Name} drew:");
          Console.WriteLine("------------------------");
          Console.WriteLine(p.Hand[0].DisplayCard());
          Console.WriteLine("------------------------");
          Console.WriteLine("");
        }
      }

    }

    public void GetDealerFinalHand(Deck deck)
    {
      foreach (Player p in Players)
      {


        if (p.HandValue < 21)
        {
          /********************** DEALER HIT OR STAND (HUH?) ***************************/
          Console.WriteLine("");
          Console.WriteLine("This is the dealers hand: ");

          while (Players[0].HandValue < 17)
            Players[0].DealACard(deck.Cards);

          Players[0].ShowHand();
          Console.WriteLine("");
          Console.WriteLine($"The dealers final total hand value: {Players[0].HandValue}");


        }
      }
    }

    public void CalculateWinners()
    {
      /*************************** Who Wins? ********************************/
      foreach (Player p in Players)
      {
        if (p.Name != "dealer")
        {
          if (p.HandValue > 21)
          {
            Console.WriteLine("");
            Console.WriteLine($"{p.Name} busted. Dealer wins");
          }
          else
          {

            if (Players[0].HandValue > 21)
            {
              Console.WriteLine("");
              Console.WriteLine($"Dealer busts. {p.Name} wins.");
            }
            else
            {
              if (Players[0].HandValue > p.HandValue)
              {
                Console.WriteLine("");
                Console.WriteLine($"Dealer wins. {p.Name} lose.");
              }
              else if (Players[0].HandValue == p.HandValue)
              {
                Console.WriteLine("");
                Console.WriteLine($"{p.Name} and the dealer tied!");
              }
              else if (Players[0].HandValue < p.HandValue)
              {
                Console.WriteLine("");
                Console.WriteLine($"{p.Name} win. The dealer loses.");
              }
              else
              {
                Console.WriteLine("");
                Console.WriteLine("ERROR: unable to define game outcome.  Check if/else statements");
              }
            }
          }
        }
      }
    }

    public void ValidateInput(string x, string y)
    {
      while (UserInput != x && UserInput != y)
      {
        Console.WriteLine("I'm sorry. That is not a valid input.");
        Console.WriteLine("");
        Console.WriteLine("Please try again");
        UserInput = Console.ReadLine().ToLower();
      }
    }

    public void CreatePlayers()
    {
      var x = 1;
      do
      {
        Console.WriteLine($"");
        Console.WriteLine($"Enter Player {x}'s name:");
        UserInput = Console.ReadLine().ToLower();

        if (UserInput != "")
        {
          var player = new Player();
          player.Name = UserInput;
          player.Hand = new List<Card>();
          player.HandValue = 0;

          Players.Add(player);
          x++;
        }
      } while (UserInput != "");
    }
    public void GetPlayerFinalHand(Deck deck)
    {
      UserInput = "";

      foreach (Player p in Players)
      {
        while (UserInput == "" && (p.HandValue < 22) && p.Name != "dealer")
        {
          // Prompt the user to either hit or stand
          Console.WriteLine($"{p.Name} it is your turn.");
          Console.WriteLine("");
          Console.WriteLine("------------------------");
          p.ShowHand();
          Console.WriteLine("------------------------");
          p.ShowHandValue();
          Console.WriteLine("Press Enter to hit or type 's' to stay.");
          UserInput = Console.ReadLine().ToLower();

          ValidateInput("", "s");
          if (UserInput == "")
          {
            p.DealACard(deck.Cards);
            Console.WriteLine("------------------------");
            p.ShowHand();
            Console.WriteLine("------------------------");
            p.ShowHandValue();
            // then check that the haven't busted
            if (p.HandValue > 22)
            {
              Console.WriteLine($"{p.Name}'s busted with a total hand value of: {p.HandValue}");

            }
          }
          else
          {
            Console.WriteLine("");
            Console.WriteLine("------------------------");
            p.ShowHand();
            Console.WriteLine("------------------------");
            Console.WriteLine($"{p.Name} is staying with a total hand value of: {p.HandValue}");
          }
          Console.WriteLine("");
        }
        UserInput = "";
      }
    }

    public void AskPlayAgain()
    {
      Console.WriteLine("");
      Console.WriteLine("Press enter to play again or enter 'q' to quit");

      // Resets the user input value
      UserInput = "";
      UserInput = Console.ReadLine().ToLower();

      ValidateInput("", "q");
    
      if (UserInput != "")
      {
        isPlaying = false;
      }
      else
      {
        isPlaying = true;
      }
    }
  }
}