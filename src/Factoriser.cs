
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
        public IEnumerable<int> Factorise(int numberToFactorise, bool useQuantumPeriodFinder)
        {
            Console.WriteLine("************** NEW FACTORISATION **************", numberToFactorise);
            Console.WriteLine("factorising {0}", numberToFactorise);
            List<int> numbersTriedAlready = new List<int>();
            int randomTestNumber = 0;
            do
            {
                randomTestNumber = _randomNumberHelper.GetRandomGreaterThanTwoLessThanN(numberToFactorise, numbersTriedAlready);
                Console.WriteLine();
                Console.WriteLine("random number chosen: {0}", randomTestNumber);
                // if (numberToFactorise % randomTestNumber == 0)
                int gcd = 1;
                if ((gcd = _modularExponentHelper.GetGCD(numberToFactorise, randomTestNumber)) != 1)
                {
                    //we've got lucky!!
                    Console.WriteLine("We got lucky picking {0} as the random number", randomTestNumber);
                    var factor2 = numberToFactorise / gcd;
                    Console.WriteLine("Factors are [{0}, {1}]", gcd, factor2);
                    Console.WriteLine();
                    return new int[] { gcd, factor2 };
                }
                
                var period = _modularExponentHelper.FindPeriod(randomTestNumber, numberToFactorise, useQuantumPeriodFinder);
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
                    Console.WriteLine();
                    return new int[] { firstFactor, secondFactor };
                }
            } while (true);
        }
    }
}

