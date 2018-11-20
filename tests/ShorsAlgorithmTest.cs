using ShorByJames;
using Xunit;
using Moq;


public class ShorsAlgorithmTest{
    [Fact]    
    public void FactoriseGetsARandomNumberLessThanN(){
        var numberToFactorise = 15;
        
        var randomNumberHelper = new Mock<IRandomNumberHelper>();
        randomNumberHelper.Setup(s=>s.GetRandomLessThan(numberToFactorise));
        var factoriser = new Factoriser(randomNumberHelper.Object);
        factoriser.Factorise(numberToFactorise);
        Assert.True(false);
    }
}

