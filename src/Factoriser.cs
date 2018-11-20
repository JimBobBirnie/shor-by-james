
using System;

namespace ShorByJames
{
    public class Factoriser
    {
        private IRandomNumberHelper _randomNumberHelper;

        public Factoriser(IRandomNumberHelper randomNumberHelper)
        {
            _randomNumberHelper = randomNumberHelper;
        }
        public void Factorise(int numberToFactorise)
        {
            throw new NotImplementedException();
        }
    }
}

