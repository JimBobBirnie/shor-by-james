using System;
using System.Collections.Generic;
using System.Linq;

namespace ShorByJames
{
    public class RandomNumberHelper : IRandomNumberHelper
    {
        public int GetRandomGreaterThanTwoLessThanN(int numberToFactorise, List<int> exclusions = null)
        {
            Random rand = new Random();

            int countOfExclusions = 0;
            if (exclusions != null && exclusions.Count > 0)
            {
                exclusions.Sort();
                countOfExclusions = exclusions.Count;
            }
            var result = rand.Next(3, numberToFactorise - 1 - countOfExclusions);
            for (int i = 0; i < countOfExclusions; i++)
            {
                if (result < exclusions[i])
                {
                    return result;
                }
                result++;
            }
            return result;
        }
    }
}