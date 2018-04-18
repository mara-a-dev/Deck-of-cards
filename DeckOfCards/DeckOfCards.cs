using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{


    public class DeckOfCards
    {
        //private Card[] deck; // array of Card objects

        Card[] deck = new Card[52];
        
        private int currentCard; // index of next Card to be dealt (0-51)
        private const int NUMBER_OF_CARDS = 52; // constant number of Cards
        private Random randomNumbers; // random-number generator
        public string[] face = new string[5];
        public string[] suit = new string[5];
        
        // constructor fills deck of Cards
        public DeckOfCards()
        {
            string[] faces = { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

            currentCard = 0; // set currentCard so deck[ 0 ] is dealt first
            randomNumbers = new Random(); // create random-number generator
            // populate deck with Card objects
            
            for (int count = 0; count < deck.Length; ++count)
                deck[count] = new Card(faces[count % 13], suits[count / 13]);
        } // end DeckOfCards constructor

        // shuffle deck of Cards with one-pass algorithm
        public void Shuffle()
        {
            // after shuffling, dealing should start at deck[ 0 ] again
            currentCard = 0; // reinitialize currentCard

            // for each Card, pick another random Card and swap them
            for (int first = 0; first < deck.Length; ++first)
            {
                // select a random number between 0 and 51
                int second = randomNumbers.Next(NUMBER_OF_CARDS);

                // swap current Card with randomly selected Card
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            } // end for
        } // end method Shuffle

        // deal one Card
        public Card DealCard()
        {
            // determine whether Cards remain to be dealt
            if (currentCard < deck.Length)
                return deck[currentCard++]; // return current Card in array
            else
                return null; // indicate that all Cards were dealt
        } // end method DealCard

        public void seperate()
        {
            string str;
            
            for (int i = 0; i < 5; i++)
            {
                str = Convert.ToString(deck[i]);
                string[] words = str.Split(' ');
                face[i] = words[0];
                suit[i] = words[2];
                
            }
        }
        
        public void pair() // this method is for 1 pair and 2 pairs
        {
            seperate();
            string pairSuit = suit[0];

            var result = face.GroupBy(i => i).Select(p => new { Value = p.Key, Count = p.Count() }).Where(x => x.Count > 1).ToList();

            foreach (var pair in result)
            {
                Console.WriteLine("Type =  " + pair.Value + " , Count  = " + pair.Count);
            }
        }

        public void ThreeOfKind()
        {
            seperate();
            string group1 = face[0];
            string group2 = face[1];

            int count1 = 0;
            int count2 = 0;

            if (face[0] != face[1])
                group2 = face[1];
            else if (face[0] != face[2])
                group2 = face[2];

            else if (face[0] != face[3])
                group2 = face[3];


            for (int i = 0; i < 5; i++)
                if (face[i] == group1)
                    count1++;
                else if (face[i] == group2)
                    count2++;

            if (count1 == 3)
                Console.WriteLine("Three Of a Kind, Type = " + group1);
            if (count2 == 3)
                Console.WriteLine("Three Of a Kind, Type = " + group2);

        }       
        public void FourOfKind()
        {
            seperate();
            string group1 = face[0];
            string group2 = face[1];

            int count1 = 0;
            int count2 = 0;

            if (face[0] != face[1])
                group2 = face[1];
            else if (face[0] != face[2])
                group2 = face[2];

            else if (face[0] != face[3])
                group2 = face[3];

            else if (face[0] != face[4])
                group2 = face[4];

            for (int i = 0; i < 5; i++)
                if (face[i] == group1)
                    count1++;
                else if (face[i] == group2)
                    count2++;

            if (count1 == 4)
                Console.WriteLine("Four Of a Kind, Type = "+ group1);
            if (count2 == 4)
                Console.WriteLine("Four Of a Kind, Type = " + group2);

        }

        public void aFlush()
        {
            seperate();
            int flushCount = 0;
            string pairSuit = suit[0];

            for (int j = 0; j < 5; j++)
            {
                if (suit[j] != pairSuit)
                {
                    break;
                }
                else
                {
                    flushCount++;
                    continue;
                    
                }
            }

            if(flushCount == 5)
                Console.WriteLine("A Flush");
       
        }
        public void aStraight()
        {
            seperate();
            string pairFace = face[0];
            string[] arr = new string[13];

            arr[1]= "Ace";
            arr[2]= "Deuce";
            arr[3]= "Three";
            arr[4]= "Four";
            arr[5]= "Five";
            arr[6]= "Six";
            arr[7]= "Seven";
            arr[8]= "Eight";
            arr[9]= "Nine";
            arr[10]= "Jack";
            arr[11]= "Queen";
            arr[12]= "King";

            for (int j = 0; j < 13; j++)
                if (face[0] == arr[j])
                    if (face[1] == arr[j + 1])
                        if (face[2] == arr[j + 2])
                            if (face[3] == arr[j + 3])
                                if (face[4] == arr[j + 4])
                                    Console.WriteLine("A STRAIGHT");
                
            
        }
        public void aFullHouse()
        {
            seperate();
            string group1 = face[0];
            string group2 = face[1];
            int count1 = 0 ;
            int count2 = 0;
            if (face[0] != face[1])
                group2 = face[1];
            else if (face[0] != face[2])
                    group2 = face[2];
            
            else if (face[0] != face[3])
                    group2 = face[3];

            for (int i = 0; i < 5; i++)
                if (face[i] == group1)
                    count1++;
                else if (face[i] == group2)
                    count2++;

            if((count1 == 2 && count2 == 3) || (count1 == 3 && count2 == 2))
                Console.WriteLine("We Have a Full House");

        }
    } // end class DeckOfCards
}
