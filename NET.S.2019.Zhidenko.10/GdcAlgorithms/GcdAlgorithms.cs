using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GdcAlgorithms
{
    public class GcdAlgorythms
    {
        private delegate int GcdMethod(int x, int y);

        /// <summary>
        /// Calculate GCD of 2, 3 and more numbers by Euclidean algorithm
        /// </summary>
        /// <param name="numbers">Numbers to get GCD of</param>
        /// <returns>GCD of 2, 3 and more numbers</returns>
        public static int EuclideanGcd(params int[] numbers)
        {
            GcdMethod method = SimpleEuclideanGcd;

            return CalculateGcd(method, numbers);
        }

        /// <summary>
        /// Calculate GCD of 2, 3 and more numbers by Euclidean algorithm and show time
        /// </summary>
        /// <param name="numbers">Numbers to get GCD of</param>
        /// <param name="time">Time of execution</param>
        /// <returns>GCD of 2, 3 and more numbers</returns>
        public static int EuclideanGcdWithTime(out long time, params int[] numbers)
        {
            GcdMethod method = SimpleEuclideanGcd;

            return CalculateGcdWithTime(out time, method, numbers);
        }

        /// <summary>
        /// Calculate GCD of 2, 3 and more numbers by Stein algorithm
        /// </summary>
        /// <param name="numbers">Numbers to get GCD of</param>
        /// <returns>GCD of 2, 3 and more numbers</returns>
        public static int SteinGcd(params int[] numbers)
        {
            GcdMethod method = RecursiveSteinGcd;
            return CalculateGcd(method, numbers);
        }

        /// <summary>
        /// Calculate GCD of 2, 3 and more numbers by Stein algorithm and show time
        /// </summary>
        /// <param name="numbers">Numbers to get GCD of</param>
        /// <param name="time">Time of execution</param>
        /// <returns>GCD of 2, 3 and more numbers</returns>
        public static int SteinGcdWithTime(out long time, params int[] numbers)
        {
            GcdMethod method = RecursiveSteinGcd;

            return CalculateGcdWithTime(out time, method, numbers);
        }

        /// <summary> Calculate GCD of 2, 3 and more numbers by certain algorithm </summary>
        /// <param name="numbers">Numbers to get GCD of</param>
        /// <param name="method"> GCD algorithm</param>
        /// <returns>GCD of 2, 3 and more numbers</returns>
        private static int CalculateGcd(GcdMethod method, params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            if (numbers.Length == 0 || numbers.Length == 1)
            {
                throw new ArgumentException();
            }

            int curGcd = method(Math.Abs(numbers[0]), Math.Abs(numbers[1]));

            for (int i = 2; i < numbers.Length; i++)
            {
                curGcd = method(curGcd, Math.Abs(numbers[i]));
            }

            return curGcd;
        }

        /// <summary> Calculate GCD of 2, 3 and more numbers by certain algorithm and show time </summary>
        /// <param name="numbers">Numbers to get GCD of</param>
        /// <param name="time">Time of execution</param>
        /// <param name="method"> GCD algorithm</param>
        /// <returns>GCD of 2, 3 and more numbers</returns>
        private static int CalculateGcdWithTime(out long time, GcdMethod method, params int[] numbers)
        {
            Stopwatch timer = new Stopwatch();

            CalculateGcd(method, numbers); // get result without time wasted on compilation

            timer.Start();
            int result = CalculateGcd(method, numbers);
            timer.Stop();
            time = timer.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Calculate GCD of 2 numbers by Euclidean algorithm
        /// </summary>
        /// <param name="a">First number to get GCD of</param>
        /// <param name="b">Second number to get GCD of</param>
        /// <returns>GCD of 2 numbers</returns>
        private static int SimpleEuclideanGcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

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
        /// Calculate GCD of 2 numbers by Stein algorithm
        /// </summary>
        /// <param name="a">First number to get GCD of</param>
        /// <param name="b">Second number to get GCD of</param>
        /// <returns>GCD of 2 numbers</returns>
        private static int RecursiveSteinGcd(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            // if a is even
            if ((~a & 1) != 0) 
            {
                // if a is even and b is odd
                if ((b & 1) != 0) 
                {
                    return RecursiveSteinGcd(a >> 1, b); // then a/2
                }
                else
                {
                    // if a and b are even
                    return RecursiveSteinGcd(a >> 1, b >> 1) << 1; // then 2*RecursiveSteinGcd(a/2, b/2)
                }
            }

            // if a is odd and b is
            if ((~b & 1) != 0)  
            {
                return RecursiveSteinGcd(a, b >> 1); // then b/2
            }

            // if both are odd then reduce bigger one and devide it by 2
            if (a > b) 
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
