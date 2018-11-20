
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
        public int Factorise(int numberToFactorise)
        {
            var randomTestNumber = _randomNumberHelper.GetRandomLessThan(numberToFactorise);
            return 0;
        }
    }
}

