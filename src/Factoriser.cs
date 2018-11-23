
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
            Console.WriteLine("factorising {0}", numberToFactorise);
            List<int> numbersTriedAlready = new List<int>();
            int randomTestNumber = 0;
            do
            {
                randomTestNumber = _randomNumberHelper.GetRandomGreaterThanTwoLessThanN(numberToFactorise, numbersTriedAlready);
                Console.WriteLine("random number chosen: {0}", randomTestNumber);
                if (numberToFactorise % randomTestNumber == 0)
                {
                    return new int[] { randomTestNumber, numberToFactorise / randomTestNumber };
                }
                var period = _modularExponentHelper.FindPeriod(randomTestNumber, numberToFactorise);
                Console.WriteLine("period of {0} mod {1} is {2}", randomTestNumber, numberToFactorise, period);
                int halfPeriodModN = 0;
                if (period % 2 != 0 ||
                    (halfPeriodModN = _modularExponentHelper.GetExponentModN(randomTestNumber, period / 2, numberToFactorise))
                     == numberToFactorise - 1)
                {
                    Console.WriteLine("Looping again - period was odd or half period exponent was N-1");
                    numbersTriedAlready.Add(randomTestNumber);
                }
                else
                {
                    Console.WriteLine("getting factors!");
                    int firstFactor = _modularExponentHelper.GetGCD(halfPeriodModN - 1, numberToFactorise);
                    int secondFactor = _modularExponentHelper.GetGCD(halfPeriodModN + 1, numberToFactorise);
                    Console.WriteLine("Factors are [{0}, {1}]", firstFactor, secondFactor);
                    return new int[] { firstFactor, secondFactor };
                }
            } while (true);
        }
    }
}

