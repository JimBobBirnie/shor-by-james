using System.Collections.Generic;
using Xunit;

namespace ShorByJames
{
    public class RandomNumberHelperTest
    {

        [Fact]
        public void GetRandomLessThanReturnsIntegerLessThanN()
        {
            var randomNumberHelper = new RandomNumberHelper();
            const int n = 15;
            var result = randomNumberHelper.GetRandomGreaterThanTwoLessThanN(n);
            Assert.True(result > 1);
            Assert.True(result < 15);

        }

        [Fact]
        public void GetRandomReturnsOnlyValidValue()
        {
            var randomNumberHelper = new RandomNumberHelper();
            const int n = 3;
            var result = randomNumberHelper.GetRandomGreaterThanTwoLessThanN(n);
            Assert.Equal(2, result);
        }

        [Fact]
        public void GetRandomDoesntReturnExcludedValues()
        {
            var n = 5;
            var excluded = new List<int> { 2, 3 };
            AssertSingleResultOfGetRandomGreaterThanTwoLessThanN(n, excluded, 4);

            excluded = new List<int> { 3, 4 };
            AssertSingleResultOfGetRandomGreaterThanTwoLessThanN(n, excluded, 2);


            n = 10;
            excluded.Clear();
            for (int i = 2; i < 9; i++)
            {
                excluded.Add(i);
            }
            AssertSingleResultOfGetRandomGreaterThanTwoLessThanN(n, excluded, 9);
        }

        [Fact]
        public void GetRandomGreaterThanTwoLessThanNReturnsAValidValue()
        {
            var n = 8;
            List<int> exclusions = new List<int> { 3, 5, 6 };
            var randomNumberHelper = new RandomNumberHelper();
            var result = randomNumberHelper.GetRandomGreaterThanTwoLessThanN(n, exclusions);
            List<int> possibleResults = new List<int> { 2, 4, 7 };
            Assert.Contains(result, possibleResults);
        }

        private void AssertSingleResultOfGetRandomGreaterThanTwoLessThanN(
            int n, List<int> exclusions, int expected)
        {
            var randomNumberHelper = new RandomNumberHelper();
            var result = randomNumberHelper.GetRandomGreaterThanTwoLessThanN(n, exclusions);
            Assert.Equal(expected, result);
        }
    }


}

