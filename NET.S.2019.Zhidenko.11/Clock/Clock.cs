using System;
using System.Timers;

namespace Clock
{
    public class Clock
    {
        private Timer _timer;
        private int _time;

        public delegate void ClockEventHandler(object sender, ClockEventArgs e);

        public event ClockEventHandler TimeOut;

        public int Time
        {
            get
            {
                return _time;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Timer can't be set on negative value.");
                }

                _time = value;
            }
        }

        /// <summary> Start timer. </summary>
        /// <param name="time"> Time </param>
        public void StartTimer(int time)
        {
            Time = time;
            _timer = new Timer(time);
            _timer.Elapsed += new ElapsedEventHandler(TimerProc);
            _timer.Start();
        }

        /// <summary> Method which is called when time is out. </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void TimerProc(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            OnTimeOut(this, new ClockEventArgs(Time));
        }

        /// <summary> Invoke TimeOut event </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void OnTimeOut(object sender, ClockEventArgs e)
        {
            TimeOut?.Invoke(sender, e);
        }
    }
}
