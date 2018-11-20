using ShorByJames;
using Xunit;
using Moq;


public class ShorsAlgorithmTest
{
    [Fact]
    public void FactoriseGetsARandomNumberLessThanN()
    {
        var numberToFactorise = 15;

        var randomNumberHelper = new Mock<IRandomNumberHelper>();
        randomNumberHelper.Setup(s => s.GetRandomLessThan(numberToFactorise))
            .Returns(0)
            .Verifiable();
        var factoriser = new Factoriser(randomNumberHelper.Object);
        factoriser.Factorise(numberToFactorise);

        randomNumberHelper.VerifyAll();
    }
}

