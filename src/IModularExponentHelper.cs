namespace ShorByJames
{
    public interface IModularExponentHelper
    {
        int FindPeriod(int smallerNumber, int numberToFactorise);

        int GetExponentModN(int smallerNumber, int exponent, int numberToFactorise);
    }
}