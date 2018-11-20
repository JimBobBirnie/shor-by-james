using Xunit;

namespace ShorByJames
{
    public class PeriodFinderTest
    {
        [Theory]
        [InlineData(4, 15, 2)]
        public void PeriodFinderReturnsRightResults(int smallNumber
            , int numberToFactor
            , int expectedPeriod)
        {
            var periodFinder = new PeriodFinder();
            var result = periodFinder.FindPeriod(smallNumber,numberToFactor);
            Assert.Equal(expectedPeriod, result);
        }


    }


}

