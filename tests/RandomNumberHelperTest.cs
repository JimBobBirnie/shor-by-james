using Xunit;

namespace ShorByJames
{
    public class RandomNumberHelperTest
    {

        [Fact]
        public void GetRandomLessThanReturnsIntegerLessThanN()
        {
            var RandomNumberHelper = new RandomNumberHelper();
            const int numberToFactorise = 15;
            var result = RandomNumberHelper.GetRandomGreaterThanTwoLessThanN(numberToFactorise);
            Assert.True(result > 0);
            Assert.True(result < 15);

        }
    }


}

