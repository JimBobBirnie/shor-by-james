
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
            List<int> numbersTriedAlready = new List<int>();
            int randomTestNumber = 0;
            do
            {
                randomTestNumber = _randomNumberHelper.GetRandomGreaterThanTwoLessThanN(numberToFactorise, numbersTriedAlready);
                if (numberToFactorise % randomTestNumber == 0)
                {
                    return new int[] { randomTestNumber, numberToFactorise / randomTestNumber };
                }
                var period = _modularExponentHelper.FindPeriod(randomTestNumber, numberToFactorise);
                int halfPeriodModN = 0;
                if (period % 2 != 0 ||
                    (halfPeriodModN = _modularExponentHelper.GetExponentModN(randomTestNumber, period / 2, numberToFactorise))
                     == numberToFactorise - 1)
                {
                    numbersTriedAlready.Add(randomTestNumber);
                }
                else
                {
                    int firstFactor = _modularExponentHelper.GetGCD(halfPeriodModN - 1, numberToFactorise);
                    int secondFactor = _modularExponentHelper.GetGCD(halfPeriodModN + 1, numberToFactorise);
                    return new int[] { firstFactor, secondFactor };
                }
            } while (true);
        }
    }
}

