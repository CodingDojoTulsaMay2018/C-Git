using System.Collections.Generic;
using System;
namespace DeckOfCards{

    public class Deck{
        public List<Card> cards = new List<Card>();
        public List <string> cardValue = new List<string>{"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
        public List <string> cardSuit = new List<string>{"Spades","Hearts","Diamonds","Clubs"};


        public  Deck(){
            for(var j=0;j<cardSuit.Count;j++){       
                for(var i=0;i<cardValue.Count;i++){
                    var suit = cardSuit[j];
                    var stringVal = cardValue[i];
                    var intVal = i;
                    Card cardName = new Card(stringVal,suit,intVal);
                    cards.Add(cardName);                                     
                }
            }
        }

        public  Card topMost(){
            // var topCard = cards.IndexOf(0);
            var topCard = cards[0];
            cards.RemoveAt(0);
            return (topCard);                        
        }

        public void shuffle(){
            Random rand = new Random();
            // System.Console.WriteLine(cards.Count);

            for(var i=0;i<cards.Count;i++){
                var randomPosition = rand.Next(0,cards.Count);
                var temp = cards[i];
                cards[i]= cards[randomPosition];
                cards[randomPosition] = temp;
            }
            
        }
    }

    
}