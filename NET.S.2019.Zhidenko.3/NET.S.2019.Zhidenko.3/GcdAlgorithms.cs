using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._3
{
    public class GcdAlgorythms
    {
        /// <summary>
        /// Calculate GCD of 2, 3 amd more numbers by Euclidean algorythm
        /// </summary>
        /// <param name="numbers">Numbers to get GCD of</param>
        /// <returns>GCD of 2, 3 amd more numbers</returns>
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

        /// <summary>
        /// Calculate GCD of 2, 3 amd more numbers by Euclidean algorythm and show time
        /// </summary>
        /// <param name="numbers">Numbers to get GCD of</param>
        /// <param name="time">Time of execution</param>
        /// <returns>GCD of 2, 3 amd more numbers</returns>
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

        /// <summary>
        /// Calculate GCD of 2 numbers by Euclidean algorythm
        /// </summary>
        /// <param name="a">First number to get GCD of</param>
        /// <param name="b">Second number to get GCD of</param>
        /// <returns>GCD of 2 numbers</returns>
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

        /// <summary>
        /// Calculate GCD of 2, 3 amd more numbers by Stein algorythm
        /// </summary>
        /// <param name="numbers">Numbers to get GCD of</param>
        /// <returns>GCD of 2, 3 amd more numbers</returns>
        public static int SteinGcd(params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();

            if (numbers.Length == 0 || numbers.Length == 1)
                throw new ArgumentException();

            int curGcd = RecursiveSteinGcd(Math.Abs(numbers[0]), Math.Abs(numbers[1]));

            for (int i = 2; i < numbers.Length; i++)
                curGcd = RecursiveSteinGcd(curGcd, Math.Abs(numbers[i]));

            return curGcd;
        }

        /// <summary>
        /// Calculate GCD of 2, 3 amd more numbers by Stein algorythm and show time
        /// </summary>
        /// <param name="numbers">Numbers to get GCD of</param>
        /// <param name="time">Time of execution</param>
        /// <returns>GCD of 2, 3 amd more numbers</returns>
        public static int SteinGcdWithTime(out long time, params int[] numbers)
        {
            Stopwatch timer = new Stopwatch();

            SteinGcd(numbers); //get result without time wasted on compilation

            timer.Start();
            int result = SteinGcd(numbers);
            timer.Stop();
            time = timer.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Calculate GCD of 2 numbers by Stein algorythm
        /// </summary>
        /// <param name="a">First number to get GCD of</param>
        /// <param name="b">Second number to get GCD of</param>
        /// <returns>GCD of 2 numbers</returns>
        private static int RecursiveSteinGcd(int a, int b)
        {
            if (a == b)
                return a;

            if (a == 0)
                return b;

            if (b == 0)
                return a;

            if ((~a & 1) != 0) // if a is even
            {
                if ((b & 1) != 0) //if a is even and b is odd
                    return RecursiveSteinGcd(a >> 1, b); //then a/2
                else // if a and b are even
                    return RecursiveSteinGcd(a >> 1, b >> 1) << 1; // then 2*RecursiveSteinGcd(a/2, b/2)
            }

            if ((~b & 1) != 0) //if a is odd and b is even
                return RecursiveSteinGcd(a, b >> 1); //then b/2

            if (a > b) //if both are odd then reduce bigger one and devide it by 2
            {
                return RecursiveSteinGcd((a - b) >> 1, b);
            }
            else
            {
                return RecursiveSteinGcd((b - a) >> 1, a);
            }
        }
    }
}
