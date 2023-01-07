using System.Collections.Generic;

namespace WPFCards
{
    class CardComparerByValue:IComparer<Cards>
    {
        public int Compare(Cards x, Cards y)
        {
            if(x.suit > y.suit)
                return 1;
            if(x.suit < y.suit)
                return -1;
            else 
                if(x.value > y.value)
                     return 1;   
                else if(x.value < y.value)
                    return -1;
                else
                    return 0;
        }
    }
}
