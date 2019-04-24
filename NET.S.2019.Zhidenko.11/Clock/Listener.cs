using System;

namespace Clock
{
    public class Listener
    {
        public Listener(Clock clock)
        {
            clock.TimeOut += TimeOut;
        }

        /// <summary> Write message in console when time is out </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void TimeOut(object sender, ClockEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
