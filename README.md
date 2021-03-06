# Blackjack

A multi-player of Blackjack with a computer dealer

## Includes:

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- Multiple classes with methods

# Featured Code

## Multiple Classes In Use w/Methods

```C#
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
```

## Actions

Players can:

- hit 
- stay

## Single Player

![record it](http://g.recordit.co/bww46zyAS3.gif)

## Multi Player

![record it](http://g.recordit.co/1sCCNNc8ox.gif)
