using System;

namespace ShorByJames
{
    public class ModularExponentHelper : IModularExponentHelper
    {
        public int FindPeriod(int smallerNumber, int numberToFactorise)
        {
            
            int exponent = 1;
            int currentResult = smallerNumber;
            while (currentResult != 1)
            {
                exponent++;
                currentResult = (currentResult * smallerNumber) % numberToFactorise;
            }
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