using System.Collections.Generic;

namespace ShorByJames
{
    public interface IRandomNumberHelper
    {
        int GetRandomGreaterThanTwoLessThanN(int numberToFactorise
            , IEnumerable<int> exclusions = null);
    }
}