
using System;
using System.Collections.Generic;

namespace ShorByJames
{
    public class Factoriser
    {
        private IRandomNumberHelper _randomNumberHelper;
        private IModularExponentHelper _modularExponentHelper;

        public Factoriser(IRandomNumberHelper randomNumberHelper, IModularExponentHelper periodFinder)
        {
            _randomNumberHelper = randomNumberHelper;
            _modularExponentHelper = periodFinder;
        }
        public IEnumerable<int> Factorise(int numberToFactorise)
        {
                List<int> numbersTriedAlready = new List<int> ();
            var randomTestNumber = _randomNumberHelper.GetRandomGreaterThanTwoLessThanN(numberToFactorise, numbersTriedAlready);
            if (numberToFactorise % randomTestNumber == 0)
            {
                return new int[] { randomTestNumber, numberToFactorise / randomTestNumber };
            }
            var period = _modularExponentHelper.FindPeriod(randomTestNumber, numberToFactorise);
            if (period % 2 != 0 ||
                _modularExponentHelper.GetExponentModN(randomTestNumber, period / 2, numberToFactorise)
                 == numberToFactorise - 1)
            {
                numbersTriedAlready.Add(randomTestNumber);
                randomTestNumber = _randomNumberHelper.GetRandomGreaterThanTwoLessThanN(numberToFactorise, numbersTriedAlready);

            }
            return new int[] { 0, 0 };
        }
    }
}

