namespace ShorByJames
{
    public interface IModularExponentHelper
    {
        int FindPeriod(int smallerNumber, int numberToFactorise, bool useQuantumPeriodFinder);
        int GetExponentModN(int smallerNumber, int exponent, int numberToFactorise);
        int GetGCD(int x, int y);
    }
}