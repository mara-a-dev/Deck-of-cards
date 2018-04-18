﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{

    public class DeckOfCardsTest
    {
        // execute app
        public static void Main(string[] args)
        {
            DeckOfCards myDeckOfCards = new DeckOfCards();
            myDeckOfCards.Shuffle(); // place Cards in random order
            Card[] ar;
            ar = new Card[5]; 
            // display all 52 Cards in the order in which they are dealt
            for (int i = 0; i < 5; ++i)
            {
                Console.Write("{0,-19}", myDeckOfCards.DealCard());
                             
                if ((i + 1) % 4 == 0)
                    Console.WriteLine();
                                
            } // end for
            Console.WriteLine();
            myDeckOfCards.pair();
            myDeckOfCards.ThreeOfKind();
            myDeckOfCards.FourOfKind();
            myDeckOfCards.aFlush();
            myDeckOfCards.aStraight();
            myDeckOfCards.aFullHouse();


            Console.ReadKey();
        } // end Main
    } // end class DeckOfCardsTest
}
