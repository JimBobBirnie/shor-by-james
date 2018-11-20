using System.Collections.Generic;

namespace ShorByJames
{
    public interface IRandomNumberHelper
    {
        int GetRandomGreaterThanTwoLessThan(int numberToFactorise
            , IEnumerable<int> exclusions = null);
    }
}