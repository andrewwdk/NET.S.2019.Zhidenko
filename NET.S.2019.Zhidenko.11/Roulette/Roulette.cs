using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class Roulette
    {
        private const int MinRouletteValue = 0;
        private const int MaxRouletteValue = 36;

        public delegate void RouletteEventHandler(object sender, RouletteEventArgs e);

        public event RouletteEventHandler RouletteSpin, ZeroHit, RedHit, BlackHit, FirstDozenHit, SecondDozenHit, ThirdDozenHit,
            LowHit, HighHit, EvenHit, OddHit;

        /// <summary> Generate number on the roulette wheel </summary>
        /// <returns> Random number</returns>
        public int SpinRouletteWheel()
        {
            Random rand = new Random();
            var number = rand.Next(MinRouletteValue, MaxRouletteValue);

            OnRouletteSpin(this, new RouletteEventArgs(number));

            return number;
        }

        /// <summary> Invoke certain events </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void OnRouletteSpin(object sender, RouletteEventArgs e)
        {
            RouletteSpin?.Invoke(sender, e);

            if (e.IsZero)
            {
                ZeroHit?.Invoke(sender, e);
            }
            else
            {
                OnColorCheck(sender, e);
                OnDozenCheck(sender, e);
                OnParityCheck(sender, e);
                OnRangeCheck(sender, e);
            }
        }

        /// <summary> Invoke certain events depending on dozen</summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void OnDozenCheck(object sender, RouletteEventArgs e)
        {
            switch (e.Dozen)
            {
                case Dozens.First:
                    FirstDozenHit?.Invoke(sender, e);
                    break;
                case Dozens.Second:
                    SecondDozenHit?.Invoke(sender, e);
                    break;
                case Dozens.Third:
                    ThirdDozenHit?.Invoke(sender, e);
                    break;
            }
        }

        /// <summary> Invoke certain events depending on color</summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void OnColorCheck(object sender, RouletteEventArgs e)
        {
            switch (e.Color)
            {
                case Colors.Red:
                    RedHit?.Invoke(sender, e);
                    break;
                case Colors.Black:
                    BlackHit?.Invoke(sender, e);
                    break;
            }
        }

        /// <summary> Invoke certain events depending on parity</summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void OnParityCheck(object sender, RouletteEventArgs e)
        {
            switch (e.Parity)
            {
                case Parity.Even:
                    EvenHit?.Invoke(sender, e);
                    break;
                case Parity.Odd:
                    OddHit?.Invoke(sender, e);
                    break;
            }
        }

        /// <summary> Invoke certain events depending on range</summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void OnRangeCheck(object sender, RouletteEventArgs e)
        {
            switch (e.Range)
            {
                case Range.High:
                    HighHit?.Invoke(sender, e);
                    break;
                case Range.Low:
                    LowHit?.Invoke(sender, e);
                    break;
            }
        }
    }
}
