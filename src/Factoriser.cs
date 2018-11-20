
using System;
using System.Collections.Generic;

namespace ShorByJames
{
    public class Factoriser
    {
        private IRandomNumberHelper _randomNumberHelper;

        public Factoriser(IRandomNumberHelper randomNumberHelper)
        {
            _randomNumberHelper = randomNumberHelper;
        }
        public IEnumerable<int> Factorise(int numberToFactorise)
        {
            var randomTestNumber = _randomNumberHelper.GetRandomGreaterThanTwoLessThan(numberToFactorise);
            if (numberToFactorise % randomTestNumber == 0)
            {
                return new int[] { randomTestNumber, numberToFactorise / randomTestNumber };
            }
            return new int[] { 0, 0 };
        }
    }
}

