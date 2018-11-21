using Xunit;

namespace ShorByJames
{
    public class ModularExponentHelperTest
    {
        [Theory]
        [InlineData(4, 15, 2)]
        [InlineData(4, 1517, 90)]
        [InlineData(14, 1517, 24)]
        [InlineData(128, 1517, 180)]
        [InlineData(10, 1517, 15)]
        public void FindPeriodReturnsRightResults(int smallNumber
            , int numberToFactor
            , int expectedPeriod)
        {
            var modularExponentHelper = new ModularExponentHelper();
            var result = modularExponentHelper.FindPeriod(smallNumber, numberToFactor);
            Assert.Equal(expectedPeriod, result);
        }

        [Theory]
        [InlineData(4, 3, 15, 4)]
        [InlineData(4, 73, 1517, 966)]
        [InlineData(15, 22, 1517, 472)]
        [InlineData(128, 31, 1517, 446)]
        [InlineData(10, 43, 1517, 713)]
        public void GetExponentModNReturnsRightResults(int smallerNumber
            , int exponent, int numberToFactor, int expected)
        {
            var modularExponentHelper = new ModularExponentHelper();
            var result = modularExponentHelper.GetExponentModN(smallerNumber, exponent, numberToFactor);
            Assert.Equal(expected, result);
        }

    }


}

