using System;
using Clock;

namespace ConsoleApplicationForClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock.Clock clock = new Clock.Clock();
            Listener listener = new Listener(clock);

            clock.StartTimer(10000);

            Console.ReadKey();
        }
    }
}
