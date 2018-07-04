using System.Collections.Generic;
using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Deck newDeck = new Deck();
            // newDeck.topMost(); //Removes the top card from the deck         
            // newDeck = new Deck(); //Resets the deck to 52 cards
            newDeck.shuffle();
            // foreach (var item in newDeck.cards)
            // {
            //     System.Console.WriteLine(item.stringVal + " of " + item.suit);
            // }
            // System.Console.WriteLine("***********************************");
            Player frank = new Player("Frank");
            var card = frank.drawCard(newDeck);
            Card cardDrawn = card as Card;
            System.Console.WriteLine("Card removed from deck "+cardDrawn.stringVal+ " of " +cardDrawn.suit);
            // foreach (var item in newDeck.cards)
            // {
            //     System.Console.WriteLine(item.stringVal + " of " + item.suit);
            // }
            // System.Console.WriteLine("***********************************");
            // System.Console.WriteLine(frank.hand.Count);
            System.Console.WriteLine("Cards in my hand "+frank.hand[0].stringVal + " of " + frank.hand[0].suit);
            System.Console.WriteLine("Number of card left in the deck " + newDeck.cards.Count);
            System.Console.WriteLine("Number of cards in my hand " +frank.hand.Count);
            frank.discard(cardDrawn);
            System.Console.WriteLine(frank.hand.Count);

        }
    }
}
