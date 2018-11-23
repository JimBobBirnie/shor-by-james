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

            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, It.IsAny<List<int>>()))
                .Returns(2)
                .Verifiable();
            _modularExponentHelpler.Setup(s=>s.GetGCD(It.IsAny<int>(),It.IsAny<int>()))
                .Returns(1);
            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);
            factoriser.Factorise(numberToFactorise, false);

            _randomNumberHelper.VerifyAll();
        }

        [Fact]
        public void WhenRandomNumberDiviedsNWeAreDone()
        {
            var numberToFactorise = 15;
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, It.IsAny<List<int>>()))
                .Returns(5);
            _modularExponentHelpler.Setup(s=>s.GetGCD(It.IsAny<int>(),It.IsAny<int>()))
                .Returns(5);
            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);
            var result = factoriser.Factorise(numberToFactorise, false);

            Assert.Contains(3, result);
            Assert.Contains(5, result);
            Assert.True(result.Count() == 2);

        }

          [Fact]
        public void WhenGCDRandomNumberAndNumberToFactoriseNotOneWeAreDone()
        {
            var numberToFactorise = 15;
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, It.IsAny<List<int>>()))
                .Returns(10);
            _modularExponentHelpler.Setup(s=>s.GetGCD(It.IsAny<int>(),It.IsAny<int>()))
                .Returns(5);
            
            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);
            var result = factoriser.Factorise(numberToFactorise, false);

            Assert.Contains(3, result);
            Assert.Contains(5, result);
            Assert.True(result.Count() == 2);

        }

        [Fact]
        public void WhenNotAFactorFactoriseFindsPeriodOfAmodN()
        {
            var numberToFactorise = 15;

            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, It.IsAny<List<int>>()))
                .Returns(4);
            _modularExponentHelpler.Setup(s=>s.GetGCD(It.IsAny<int>(),It.IsAny<int>()))
                .Returns(1);
            _modularExponentHelpler.Setup(s => s.FindPeriod(4, 15, false))
                .Returns(4)
                .Verifiable();

            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);
            var result = factoriser.Factorise(numberToFactorise, false);
            _modularExponentHelpler.VerifyAll();
        }

        [Fact]
        public void WhenPeriodIsOddFactoriseGetsADifferentRandomNumber()
        {
            var numberToFactorise = 15;
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, It.Is<List<int>>(l => l.Count == 0)))
                .Returns(7);
            _modularExponentHelpler.Setup(s=>s.GetGCD(It.IsAny<int>(),It.IsAny<int>()))
                .Returns(1);
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise
                    , It.Is<List<int>>(exclusions => exclusions != null && exclusions.Count > 0 && exclusions.Single() == 7)))
                .Returns(2)
                .Verifiable();

            _modularExponentHelpler.Setup(s => s.FindPeriod(7, 15, false))
                .Returns(7);

            _modularExponentHelpler.Setup(s => s.FindPeriod(2, 15, false))
                .Returns(4);
            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);

            var result = factoriser.Factorise(numberToFactorise, false);

            _randomNumberHelper.VerifyAll();

        }

        [Fact]
        public void WhenPeriodIsEvenFactoriseChecksHalfPeriod()
        {
            var numberToFactorise = 15;
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, It.IsAny<List<int>>()))
                .Returns(7);
            _modularExponentHelpler.Setup(s=>s.GetGCD(It.IsAny<int>(),It.IsAny<int>()))
                .Returns(1);
            _modularExponentHelpler.Setup(s => s.FindPeriod(7, 15, false))
                .Returns(6);

            _modularExponentHelpler.Setup(s => s.GetExponentModN(7, 3, 15))
                .Returns(12)
                .Verifiable();

            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);

            var result = factoriser.Factorise(numberToFactorise, false);

            _modularExponentHelpler.VerifyAll();
        }

        [Fact]
        public void WhenHalfPeriodExponentIsMinusOneFactoriseGetsADifferentRandomNumber()
        {
            var numberToFactorise = 15;
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, It.IsAny<List<int>>()))
                .Returns(7);
            _modularExponentHelpler.Setup(s=>s.GetGCD(It.IsAny<int>(),It.IsAny<int>()))
                .Returns(1);

            _modularExponentHelpler.Setup(s => s.FindPeriod(7, 15, false))
                .Returns(6);

            _modularExponentHelpler.Setup(s => s.GetExponentModN(7, 3, 15))
                .Returns(14);

            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise
                   , It.Is<List<int>>(exclusions => exclusions != null && exclusions.Count > 0 && exclusions.Single() == 7)))
               .Returns(2)
               .Verifiable();

            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);

            var result = factoriser.Factorise(numberToFactorise, false);

            _randomNumberHelper.VerifyAll();

        }

        [Fact]
        public void WhenPeriodIsEvenAndHalfPeriodNotMinusOneFactoriseGetsGCDs()
        {
            var numberToFactorise = 15;
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, It.IsAny<List<int>>()))
                .Returns(7);
            _modularExponentHelpler.Setup(s=>s.GetGCD(It.IsAny<int>(),It.IsAny<int>()))
                .Returns(1);
            _modularExponentHelpler.Setup(s => s.FindPeriod(It.IsAny<int>(), It.IsAny<int>(), false))
                .Returns(6);
            _modularExponentHelpler.Setup(s => s.GetExponentModN(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(4);
            //half period exponent is not minus 1 - so the half period exponent +-1 is used to get factors
            _modularExponentHelpler.Setup(s => s.GetGCD(3, 15))
                .Returns(0)
                .Verifiable();
            _modularExponentHelpler.Setup(s => s.GetGCD(5, 15))
                .Returns(0)
                .Verifiable();

            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);

            var result = factoriser.Factorise(numberToFactorise, false);

            _modularExponentHelpler.VerifyAll();

        }

        [Fact]
        public void FactoriseReturnsFactors()
        {
            var numberToFactorise = 15;
            _randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThanN(numberToFactorise, It.IsAny<List<int>>()))
                .Returns(7);
            _modularExponentHelpler.Setup(s=>s.GetGCD(It.IsAny<int>(),It.IsAny<int>()))
                .Returns(1);
            _modularExponentHelpler.Setup(s => s.FindPeriod(It.IsAny<int>(), It.IsAny<int>(), false))
                .Returns(6);
            _modularExponentHelpler.Setup(s => s.GetExponentModN(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(4);
            //half period exponent is not minus 1 - so the half period exponent +-1 is used to get factors
            var firstExpectedFactor = 23;
            var secondExpectedFactor = 17;
            _modularExponentHelpler.Setup(s => s.GetGCD(3, 15))
                .Returns(firstExpectedFactor);
            _modularExponentHelpler.Setup(s => s.GetGCD(5, 15))
                .Returns(secondExpectedFactor);

            var factoriser = new Factoriser(_randomNumberHelper.Object, _modularExponentHelpler.Object);

            var result = factoriser.Factorise(numberToFactorise, false);
            Assert.Contains(firstExpectedFactor, result);
            Assert.Contains(secondExpectedFactor, result);
        }

        [Theory]
        [InlineData(15,3,5)]
        [InlineData(21,3,7)]
        public void EndToEndTestsOfClassicalShorImplementation(int numberToFactorise
            , int expectedFactor1, int expectedFactor2)
        {
            var factoriser = new Factoriser(new RandomNumberHelper()
                , new ModularExponentHelper());
            var result = factoriser.Factorise(numberToFactorise, false);
            Assert.Contains(expectedFactor1, result);
            Assert.Contains(expectedFactor2, result);
        }
    }


}

