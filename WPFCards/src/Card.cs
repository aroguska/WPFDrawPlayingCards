using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPFCards
{
    class Cards : TextBlock, IComparable<Cards>
    {

        private Dictionary<Suits, string> suitDecoder = new Dictionary<Suits, string>()
        {
            {Suits.Clubs, "\u2663"},
            {Suits.Hearts, "\u2665"},
            {Suits.Diamonds, "\u2666"},
            {Suits.Spades, "\u2660"}
        };
        public Cards(Values value, Suits suit)
        {
            this.value = value;
            this.suit = suit;

            Inlines.Clear();
            Inlines.Add(new Run($"{value} of "));
            if (suit == Suits.Hearts || suit == Suits.Diamonds) {
                Inlines.Add(new Run($"{suitDecoder[suit]}") { Foreground = Brushes.Red });
            }
            else
                Inlines.Add(new Run($"{suitDecoder[suit]}"));
        }

        public Values value { get; private set; }   

        public Suits suit { get; private set; }
        public string Name { get { return $"{value} of {suitDecoder[suit]}"; } }

        public int CompareTo(Cards other)
        {
            return new CardComparerByValue().Compare(this, other);   
        }
    }
}
