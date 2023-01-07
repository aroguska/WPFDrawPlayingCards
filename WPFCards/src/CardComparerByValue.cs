using System.Collections.Generic;

namespace WPFCards
{
    class CardComparerByValue:IComparer<Cards>
    {
        public int Compare(Cards x, Cards y)
        {
            if (x.Suit > y.Suit)
                return 1;
            if (x.Suit < y.Suit)
                return -1;
            else
                if (x.Value > y.Value)
                return 1;
            else if (x.Value < y.Value)
                return -1;
            else
                return 0;
        }
    }
}
