
using System;
using System.Collections.Generic;

namespace ShorByJames
{
    public class Factoriser
    {
        private IRandomNumberHelper _randomNumberHelper;
        private IPeriodFinder _periodFinder;

        public Factoriser(IRandomNumberHelper randomNumberHelper, IPeriodFinder periodFinder)
        {
            _randomNumberHelper = randomNumberHelper;
            _periodFinder = periodFinder;
        }
        public IEnumerable<int> Factorise(int numberToFactorise)
        {
            var randomTestNumber = _randomNumberHelper.GetRandomGreaterThanTwoLessThanN(numberToFactorise);
            if (numberToFactorise % randomTestNumber == 0)
            {
                return new int[] { randomTestNumber, numberToFactorise / randomTestNumber };
            }
            var period = _periodFinder.FindPeriod(randomTestNumber, numberToFactorise);
            return new int[] { 0, 0 };
        }
    }
}

