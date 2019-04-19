using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence
{
    public class Fibonacci
    {
        /// <summary> Generate Fibonacci sequence</summary>
        /// <returns> Next Fibonacci number</returns>
        public static IEnumerable<int> GetNext()
        {
            yield return 1;
            yield return 1;

            var lastNumber = 1;
            var preLastNumber = 1;

            for (;;)
            {
                var currentNumber = lastNumber + preLastNumber;
                preLastNumber = lastNumber;
                lastNumber = currentNumber;

                yield return currentNumber;
            }
        }
    }
}
