using ShorByJames;
using Xunit;


public class ShorsAlgorithmTest{
    [Fact]    
    public void FactoriseGetsARandomNumberLessThanN(){
        var factoriser = new Factoriser();
        var numberToFactorise = 15;
        factoriser.Factorise(numberToFactorise);
        Assert.True(false);
    }
}