using System.Collections.Generic;
namespace DeckOfCards{

    public class Card{

        public string stringVal; //Holds the string value of the card
        public string suit; //Holds the string suit of the card
        public int val; //Holds the numerical value of the card

        public Card(string stringValue,string suits,int intVal){
            stringVal = stringValue;
            suit = suits;
            val = intVal;
        }

    }
}