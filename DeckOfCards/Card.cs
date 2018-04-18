using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    public class Card
    {
        private string face; // face of card ("Ace", "Deuce", ...)
        private string suit;// suit of card ("Hearts", "Diamonds", ...)

        public string Face
        {
            get;
            set;

        }
        public string Suit
        {
            get;
            set;

        }
        public Card(string cardFace, string cardSuit)
        {
            face = cardFace; // initialize face of card
            suit = cardSuit; // initialize suit of card
        } // end two-parameter Card constructor

        // return string representation of Card

        public override string ToString()
        {
            return face + " of " + suit;
        } // end method ToString
    } // end class Card
}
