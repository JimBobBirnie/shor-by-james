using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;


namespace ShorByJames
{
    class Driver
    {
        static void Main(string[] args)
        {
            int numberToFactorise = 0;
            if (args.Length == 0)
            {
                numberToFactorise = 15;
            }
            else
            {
                int.TryParse(args[0], out numberToFactorise);
            }
            if (numberToFactorise == 0)
            {
                Console.WriteLine("no number to factorise");
            }
            else
            {
                var factoriser = new Factoriser(new RandomNumberHelper(), new ModularExponentHelper());
                factoriser.Factorise(15);
            }

        }
    }
}