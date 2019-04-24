using System;

namespace Clock
{
    public class ClockEventArgs : EventArgs
    {
        public ClockEventArgs(int time)
        {
            this.Time = time;
            this.Message = "Timer's ended in " + time + " miliseconds";
        }

        public int Time { get; private set; }

        public string Message { get; private set; }
    }
}
