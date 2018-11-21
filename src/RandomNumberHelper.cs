using System;
using System.Collections.Generic;

namespace ShorByJames
{
    public class RandomNumberHelper : IRandomNumberHelper
    {
        public int GetRandomGreaterThanTwoLessThanN(int numberToFactorise
        , IEnumerable<int> exclusions = null)
        {
            Random rand = new Random();
            return rand.Next(2, numberToFactorise-1);
        }
    }
}