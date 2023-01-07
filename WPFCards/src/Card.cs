using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPFCards
{
    class Cards : TextBlock, IComparable<Cards>
    {

        private readonly Dictionary<Suits, string> suitDecoder = new Dictionary<Suits, string>()
        {
            {Suits.Clubs, "\u2663"},
            {Suits.Hearts, "\u2665"},
            {Suits.Diamonds, "\u2666"},
            {Suits.Spades, "\u2660"}
        };
        public Cards(Values value, Suits suit)
        {
            Value = value;
            Suit = suit;

            Inlines.Clear();
            Inlines.Add(new Run($"{value} of "));
            if (suit == Suits.Hearts || suit == Suits.Diamonds)
                Inlines.Add(new Run($"{suitDecoder[suit]}") { Foreground = Brushes.Red });
            else
                Inlines.Add(new Run($"{suitDecoder[suit]}"));
        }

        public Values Value { get; private set; }   

        public Suits Suit { get; private set; }
        public string Name { get { return $"{Value} of {suitDecoder[Suit]}"; } }

        public int CompareTo(Cards other)
        {
            return new CardComparerByValue().Compare(this, other);   
        }
    }
}
