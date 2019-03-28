using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._3
{
    public class GcdAlgorythms
    {
        public static int EuclideanGcd(params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();

            if (numbers.Length == 0 || numbers.Length == 1)
                throw new ArgumentException();

            int curGcd = SimpleEuclideanGcd(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
                curGcd = SimpleEuclideanGcd(curGcd, numbers[i]);

            return curGcd;
        }

        public static int EuclideanGcdWithTime(out long time, params int[] numbers)
        {
            Stopwatch timer = new Stopwatch();

            EuclideanGcd(numbers); //get result without time wasted on compilation

            timer.Start();
            int result = EuclideanGcd(numbers);
            timer.Stop();
            time = timer.ElapsedMilliseconds;

            return result;

        }

        private static int SimpleEuclideanGcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
                return b;

            if (b == 0)
                return a;

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }
    }
}
