using System;
using System.Collections.Generic;

namespace Blackjack
{
  class Program
  {
    static void Main(string[] args)
    {
      var isPlaying = true;
      while (isPlaying)
      {
        /********************** POTENTIAL Classes ***************************/
        /*
        Game
        Deck
        Card
        Player

        */
        /********************** POTENTIAL FUNCTIONS ***************************/
        /*  DealACard() {
          Hand.Add(deck[0]);
          HandValue += deck[0].GetCardValue();
          deck.RemoveAt(0);
        }

        */  

        /********************** CREATING THE DECK ***************************/

        //The game should be played with a standard deck of playing cards (52).
        var deck = new List<Card>();
        var suits = new List<string>() { "Hearts", "Clubs", "Spades", "Diamonds" };
        var ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };


        for (var i = 0; i < suits.Count; i++)
        {
          for (var n = 0; n < ranks.Count; n++)
          {
            var card = new Card();
            card.Rank = ranks[n];
            card.Suit = suits[i];
            if (card.Suit == "diamonds" || card.Suit == "hearts")
              card.Color = "red";
            else
              card.Color = "black";

            deck.Add(card);
          }
        }

        /********************** SHUFFLING THE DECK ***************************/

        for (int i = deck.Count - 1; i >= 0; i--)
        {
          var j = new Random().Next(deck.Count);
          var temp = deck[j];
          deck[j] = deck[i];
          deck[i] = temp;
        }


        /********************** DEALING CARDS ***************************/
        // Create dealer and player hands
        var dealer = new Player();
        var player = new Player();

        dealer.Hand = new List<Card>();
        player.Hand = new List<Card>();
        
       

        // "Deal" cards into their hands while removing them fro the "top" of the deck
        dealer.Hand.Add(deck[0]);
        deck.RemoveAt(0);
        dealer.Hand.Add(deck[0]);
        deck.RemoveAt(0);

        player.Hand.Add(deck[0]);
        deck.RemoveAt(0);
        player.Hand.Add(deck[0]);
        deck.RemoveAt(0);


        // Show the players their Hand and total value of their cards
        Console.WriteLine("");
        for (int i = 0; i < player.Hand.Count; i++)
        {
          Console.WriteLine(player.Hand[i].DisplayCard());
        }

        // Creating the player hand total
        player.HandValue = 0;
        for (int i = 0; i < player.Hand.Count; i++)
        {
          player.HandValue += player.Hand[i].GetCardValue();
        }
        Console.WriteLine($"Your current total card value is: {player.HandValue}");

        // Creating the dealer hand total
        dealer.HandValue = 0;
        for (int i = 0; i < dealer.Hand.Count; i++)
        {
          dealer.HandValue += dealer.Hand[i].GetCardValue();
        }




        /********************** PLAYER HIT OR STAND (HUH?) ***************************/
        // If the players hand is under 21 ask them if they want to hit

        var userInput = "";
        while (userInput == "" && (player.HandValue < 22))
        {
          // Prompt the user to either hit or stand
          Console.WriteLine("Press Enter to hit or type 's' to stay.");
          userInput = Console.ReadLine().ToLower();

          while (userInput != "" && userInput != "s")
          {
            Console.WriteLine("I'm sorry. That is not a valid input.");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to hit or type 's' to stay.");
            userInput = Console.ReadLine().ToLower();
          }

          // If they chose to hit...
          if (userInput == "")
          {
            player.Hand.Add(deck[0]);                         // Add that card to their hand
            player.HandValue += deck[0].GetCardValue();  // Add that card value to their current total hand value
            deck.RemoveAt(0);                                // Remove that card from the deck

            // This shows the player the card in their hand each time through the while loop
            for (int i = 0; i < player.Hand.Count; i++)
            {
              Console.WriteLine(player.Hand[i].DisplayCard());
            }

            // then check that the haven't busted
            if (player.HandValue < 22)
            {
              // Give them their total hand value
              Console.WriteLine($"Your current total card value is: {player.HandValue}");
            }
            else
            {
              Console.WriteLine($"You busted with a total hand value of: {player.HandValue}");

            }


          }
          else
          {
            Console.WriteLine($"You are staying with a total hand value of: {player.HandValue}");

          }

        }

        /*************************** DID PLAYER BUST? ********************************/
        if (player.HandValue > 21)
        {

          Console.WriteLine("Dealer wins. You lose.");
        }
        else
        {
          /********************** DEALER HIT OR STAND (HUH?) ***************************/
          Console.WriteLine("This is the dealers hand: ");

          for (int i = 0; i < dealer.Hand.Count; i++)
          {
            Console.WriteLine(dealer.Hand[i].DisplayCard());
          }

          while (dealer.HandValue < 17)
          {
            dealer.Hand.Add(deck[0]);
            Console.WriteLine(deck[0].DisplayCard());
            dealer.HandValue += deck[0].GetCardValue();
            deck.RemoveAt(0);
          }

          Console.WriteLine("");
          Console.WriteLine($"The dealers final total hand value: {dealer.HandValue}");

          /*************************** DID PLAYER BUST? ********************************/
          if (dealer.HandValue > 21)
          {
            Console.WriteLine("");
            Console.WriteLine("Dealer busts. You win.");
          }
          else
          {
            if (dealer.HandValue > player.HandValue)
            {
              Console.WriteLine("");
              Console.WriteLine("Dealer wins. You lose.");
            }
            else if (dealer.HandValue == player.HandValue)
            {
              Console.WriteLine("");
              Console.WriteLine("It's a tie!");
            }
            else if (dealer.HandValue < player.HandValue)
            {
              Console.WriteLine("");
              Console.WriteLine("You win. The dealer loses.");
            }
            else
            {
              Console.WriteLine("");
              Console.WriteLine("ERROR: unable to define game outcome.  Check if/else statements");
            }
          }

        }

        /********************** DOES THE USER WANT TO PLAY AGAIN? ***************************/
        Console.WriteLine("");
        Console.WriteLine("Press enter to play again or enter 'q' to quit");

        userInput = "";
        userInput = Console.ReadLine().ToLower();

        while (userInput != "" && userInput != "q")
        {
          Console.WriteLine("I'm sorry. That is not a valid input.");
          Console.WriteLine("");
          Console.WriteLine("Press Enter to play again or enter 'q' to quit");
          userInput = Console.ReadLine().ToLower();
        }

        if (userInput != "")
        {
          isPlaying = false;
        }
      }
    }
  }
}
