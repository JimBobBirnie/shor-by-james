using Xunit;

namespace ShorByJames
{
    public class PeriodFinderTest
    {
        [Theory]
        [InlineData(4, 15, 2)]
        [InlineData(4, 1517, 90)]
        [InlineData(14, 1517, 24)]
        [InlineData(128, 1517, 180)]
        [InlineData(10, 1517, 15)]
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

