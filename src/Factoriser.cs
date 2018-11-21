
using System;
using System.Collections.Generic;

namespace ShorByJames
{
    public class Factoriser
    {
        private IRandomNumberHelper _randomNumberHelper;
        private IModularExponentHelper _periodFinder;

        public Factoriser(IRandomNumberHelper randomNumberHelper, IModularExponentHelper periodFinder)
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
            if (period % 2 != 0 ||
                _periodFinder.GetExponentModN(randomTestNumber, period / 2, numberToFactorise)
                 == numberToFactorise - 1)
            {
                List<int> numbersTriedAlready = new List<int> { period };
                randomTestNumber = _randomNumberHelper.GetRandomGreaterThanTwoLessThanN(numberToFactorise, numbersTriedAlready);

            }
            return new int[] { 0, 0 };
        }
    }
}

