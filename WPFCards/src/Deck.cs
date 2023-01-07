using System;
using System.Collections.Generic;

namespace WPFCards
{
    class Deck : List<Cards>
    {
        private static Random random = new Random();

        public Deck()
        { 
            Reset();
        }

        public Deck Reset() 
        { 
            Clear(); 
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int values = 1; values <= 13; values++)
                {
                    Add(new Cards((Values)values, (Suits)suit));
                }
            } 
            return this;
        }

        public Deck Shuffle() 
        {
            List<Cards> copy = new List<Cards>(this);  
            Clear(); 
            while (copy.Count > 0) 
            { 
                int index = random.Next(copy.Count);
                Cards cards = copy[index];
                copy.RemoveAt(index);
                Add(cards);
            }
            return this;
        }
    }
}
