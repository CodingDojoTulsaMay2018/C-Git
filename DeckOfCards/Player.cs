using System.Collections.Generic;
using System;
namespace DeckOfCards{

    public class Player
    {
        public string name;
        public List <Card> hand = new List<Card>();


        public Player(string val){
            name = val;
        }

        public Object drawCard(Deck deck){
            Random rand = new Random();
            
                var randomPosition = rand.Next(1,deck.cards.Count);
                // System.Console.WriteLine(randomPosition);
                var cardDrawn = deck.cards[randomPosition];
                hand.Add(cardDrawn);
                deck.cards.Remove(cardDrawn);
                // System.Console.WriteLine(cardDrawn.stringVal+" of "+ cardDrawn.suit);
                return(cardDrawn);
            
            
            // var drawnCard = deck.cards

            // var randomPosition = rand.Next(0,cards.Count);

        }
        public Card discard(Card card){
            // Card cardDrawn = card as Card;
            var cardDrawn = card;
            hand.Remove(cardDrawn);
            return(cardDrawn);
        }

    }









}