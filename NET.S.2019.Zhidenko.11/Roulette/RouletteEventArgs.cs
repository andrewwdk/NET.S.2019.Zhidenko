using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public enum Dozens
    {
        First = 1,
        Second,
        Third,
        None
    }

    public enum Colors
    {
        Red,
        Black,
        None
    }

    public enum Parity
    {
        Even,
        Odd,
        None
    }

    public enum Range
    {
        Low,
        High,
        None
    }

    public class RouletteEventArgs : EventArgs
    {
        private const int FirstDozenMax = 12;
        private const int SecondDozenMax = 24;
        private const int LowRangeMax = 18;

        private readonly int[] blackNumbers = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };

        public RouletteEventArgs(int number)
        {
            this.DefineProperties(number);
        }

        public int Number { get; private set; }

        public bool IsZero { get; private set; }

        public Dozens Dozen { get; private set; }

        public Colors Color { get; private set; }

        public Parity Parity { get; private set; }

        public Range Range { get; private set; }

        /// <summary> Initialize all properties </summary>
        /// <param name="number"> Roulette number</param>
        private void DefineProperties(int number)
        {
            this.Number = number;

            if (number == 0)
            {
                this.IsZero = true;
                this.Dozen = Dozens.None;
                this.Color = Colors.None;
                this.Parity = Parity.None;
                this.Range = Range.None;
            }
            else
            {
                this.IsZero = false;

                if (number <= FirstDozenMax)
                {
                    this.Dozen = Dozens.First;
                }
                else
                { 
                    this.Dozen = (number <= SecondDozenMax) ? Dozens.Second : Dozens.Third;
                }

                this.Range = (number <= LowRangeMax) ? Range.Low : Range.High;
                this.Parity = (number % 2 == 0) ? Parity.Even : Parity.Odd;
                this.Color = this.blackNumbers.Contains(number) ? Colors.Black : Colors.Red;   
            }
        }
    }
}
