using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._2
{
    public class Root
    {
        /// <summary>
        /// Find Nth root of a number
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="root">Root</param>
        /// <param name="epsilon">Precision</param>
        /// <returns>Root of a number</returns>
        public static double FindNthRoot(double number, int root, double epsilon)
        {
            if (root < 1)
                throw new ArgumentOutOfRangeException();

            if (epsilon <= 0)
                throw new ArgumentOutOfRangeException();

            double x = number;
            double prevX = x + 1;

            while (Math.Abs(x - prevX) > epsilon)
            {
                prevX = x;
                x = (1 / (double)root) * (((root - 1) * prevX) + (number / Math.Pow(prevX, root - 1)));

            }

            int round = 0;
            while(epsilon < 1)
            {
                epsilon *= 10;
                round++;
            }

            return Math.Round(x, round);
        }
    }
}
