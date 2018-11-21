using System.Collections.Generic;

namespace ShorByJames
{
    public interface IRandomNumberHelper
    {
        int GetRandomGreaterThanTwoLessThanN(int numberToFactorise
            , List<int> exclusions = null);
    }
}