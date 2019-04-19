using System;
using Roulette;

namespace ConsoleApplicationForRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            var roulette = new Roulette.Roulette();
            var logging = new RouletteLogging(roulette);

            for(var i = 0; i < 10; i++)
            {
                Console.WriteLine("Fell number is {0}", roulette.SpinRouletteWheel());
            }

            Console.ReadKey();
        }
    }
}
