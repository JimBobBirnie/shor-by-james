using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;


namespace ShorByJames
{
    class Driver
    {
        static void Main(string[] args)
        {
            //15 = 3 * 5
            //1517 = 39 * 41
            //5537 = 113 * 49
            //19043  = 139 * 137
            //804509 = 887 * 907
            var factoriser = new Factoriser(new RandomNumberHelper(), new ModularExponentHelper());
            factoriser.Factorise(19043);
        }
    }
}