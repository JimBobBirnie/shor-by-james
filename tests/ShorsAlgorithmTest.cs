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
        private Mock<IModularExponentHelper> _modularExponentHelpler;

        public ShorsAlgorithmTest()
        {
            _randomNumberHelper = new Mock<IRandomNumberHelper>();
            _modularExponentHelpler = new Mock<IModularExponentHelper>();
        }
        [Fact]
        public void FactoriseGetsARandomNumberLessThanN()
        {
            var numberToFactorise = 15;

            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, null))
                .Returns(2)
                .Verifiable();
            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);
            factoriser.Factorise(numberToFactorise);

            _randomNumberHelper.VerifyAll();
        }

        [Fact]
        public void WhenRandomNumberDiviedsNWeAreDone()
        {
            var numberToFactorise = 15;
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, null))
                .Returns(5);
            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);
            var result = factoriser.Factorise(numberToFactorise);

            Assert.Contains(3, result);
            Assert.Contains(5, result);
            Assert.True(result.Count() == 2);

        }

        [Fact]
        public void WhenNotAFactorFactoriseFindsPeriodOfAmodN()
        {
            var numberToFactorise = 15;

            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, null))
                .Returns(4);

            _modularExponentHelpler.Setup(s => s.FindPeriod(4, 15))
                .Returns(4)
                .Verifiable();

            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);
            var result = factoriser.Factorise(numberToFactorise);
            _modularExponentHelpler.VerifyAll();
        }

        [Fact]
        public void WhenPeriodIsOddFactoriseGetsADifferentRandomNumber()
        {
            var numberToFactorise = 15;
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, null))
                .Returns(7);
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise
                    , It.Is<List<int>>(exclusions => exclusions != null && exclusions.Single() == 7)))
                .Returns(2)
                .Verifiable();

            _modularExponentHelpler.Setup(s => s.FindPeriod(7, 15))
                .Returns(7);

            _modularExponentHelpler.Setup(s => s.FindPeriod(2, 15))
                .Returns(4);
            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);

            var result = factoriser.Factorise(numberToFactorise);

            _randomNumberHelper.VerifyAll();

        }

    }


}

