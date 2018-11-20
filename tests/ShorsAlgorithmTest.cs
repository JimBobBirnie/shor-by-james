using ShorByJames;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ShorByJames
{

    public class ShorsAlgorithmTest
    {
        [Fact]
        public void FactoriseGetsARandomNumberLessThanN()
        {
            var numberToFactorise = 15;

            var randomNumberHelper = new Mock<IRandomNumberHelper>();
            randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThan(numberToFactorise, null))
                .Returns(2)
                .Verifiable();
            var factoriser = new Factoriser(randomNumberHelper.Object);
            factoriser.Factorise(numberToFactorise);

            randomNumberHelper.VerifyAll();
        }

        [Fact]
        public void WhenRandomNumberDiviedsNWeAreDone()
        {
            var numberToFactorise = 15;

            var randomNumberHelper = new Mock<IRandomNumberHelper>();
            randomNumberHelper.Setup(s => s.GetRandomGreaterThanTwoLessThan(numberToFactorise, null))
                .Returns(5);
            var factoriser = new Factoriser(randomNumberHelper.Object);
            var result = factoriser.Factorise(numberToFactorise);

            Assert.Contains(3, result);
            Assert.Contains(5, result);
            Assert.True(result.Count() == 2);

        }

       
    }


}

