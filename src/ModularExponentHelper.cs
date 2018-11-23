using System;

namespace ShorByJames
{
    public class ModularExponentHelper : IModularExponentHelper
    {
        public int FindPeriod(int smallerNumber, int numberToFactorise
        , bool useQuantumPeriodFinder)
        {
            DateTime startTime = DateTime.Now;
            int exponent = 1;
            int currentResult = smallerNumber;
            while (currentResult != 1)
            {
                exponent++;
                currentResult = (currentResult * smallerNumber) % numberToFactorise;
            }
            TimeSpan elapsedTime = DateTime.Now - startTime;
            Console.WriteLine("Time taken to find period of {0} mod {1} was:", smallerNumber, numberToFactorise);
            Console.WriteLine("{0} milleseconds", elapsedTime.TotalMilliseconds);

            return exponent;
        }

        public int GetExponentModN(int smallerNumber, int exponent, int numberToFactorise)
        {
            if (exponent == 1)
            {
                return smallerNumber;
            }
            return (smallerNumber * GetExponentModN(smallerNumber, exponent - 1, numberToFactorise)) % numberToFactorise;
        }

        public int GetGCD(int x, int y)
        {
            // If y is equal to 0, return x.
            if (y == 0)
                return x;
            // If y is not equal to 0, recursive call with x as y and y as the remainder.
            return GetGCD(y, x % y);
        }
    }
}