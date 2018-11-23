using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;


namespace ShorByJames
{
    class Driver
    {
        static void Main(string[] args)
        {
            var factoriser = new Factoriser(new RandomNumberHelper(), new ModularExponentHelper());
            factoriser.Factorise(21);
        }
    }
}