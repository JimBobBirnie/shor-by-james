using ShorByJames;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ShorByJames
{

    public class ShorsAlgorithmTest
    {
        private Mock<IRandomNumberHelper> _randomNumberHelper;
        private Mock<IPeriodFinder> _periodFinder;

        public ShorsAlgorithmTest()
        {
            _randomNumberHelper = new Mock<IRandomNumberHelper>();
            _periodFinder = new Mock<IPeriodFinder>();
        }
        [Fact]
        public void FactoriseGetsARandomNumberLessThanN()
        {
            var numberToFactorise = 15;

            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThan(numberToFactorise, null))
                .Returns(2)
                .Verifiable();
            var factoriser = new Factoriser(_randomNumberHelper.Object, _periodFinder.Object);
            factoriser.Factorise(numberToFactorise);

            _randomNumberHelper.VerifyAll();
        }

        [Fact]
        public void WhenRandomNumberDiviedsNWeAreDone()
        {
            var numberToFactorise = 15;
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThan(numberToFactorise, null))
                .Returns(5);
            var factoriser = new Factoriser(_randomNumberHelper.Object, _periodFinder.Object);
            var result = factoriser.Factorise(numberToFactorise);

            Assert.Contains(3, result);
            Assert.Contains(5, result);
            Assert.True(result.Count() == 2);

        }

        [Fact]
        public void WhenNotAFactorFactoriseFindsPeriodOfAmodN()
        {
            var numberToFactorise = 15;

            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThan(numberToFactorise, null))
                .Returns(4);

            _periodFinder.Setup(s => s.FindPeriod(4, 15))
                .Returns(4)
                .Verifiable();

            var factoriser = new Factoriser(_randomNumberHelper.Object, _periodFinder.Object);
            var result = factoriser.Factorise(numberToFactorise);
            _periodFinder.VerifyAll();
        }

        // [Fact]
        // public void FactoriseGetsADifferentRandomNumberLessThanN()
        // {
        //     var numberToFactorise = 15;
        //     var randomNumberHelper = new Mock<IRandomNumberHelper>();
        //     randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThan(numberToFactorise, null))
        //         .Returns(5)
        //         .Verifiable();
        //     randomNumberHelper.Setup(s=>s.GetRandomGreaterThanTwoLessThan(numberToFactorise
        //     , It.Is<IEnumerable<int>>(exclusions=>exclusions.Single() == 5)));
        // }

    }


}

