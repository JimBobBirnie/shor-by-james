namespace ShorByJames
{
    public class ModularExponentHelper : IModularExponentHelper
    {
        public int FindPeriod(int smallerNumber, int numberToFactorise)
        {
            int exponent = 1;
            int currentResult = smallerNumber;
            while(currentResult != 1){
                exponent ++;
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
    }
}