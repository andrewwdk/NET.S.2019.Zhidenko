using System;
using System.Collections;

namespace NET.S._2019.Zhidenko._2
{
    public class BitsInsert
    {
        /// <summary>
        /// Insert bits of one number into another number
        /// </summary>
        /// <param name="firstNumber">The first number</param>
        /// <param name="secondNumber">The second number</param>
        /// <param name="i">Start index</param>
        /// <param name="j">End index</param>
        /// <returns>New number</returns>
        public static int InsertNumber(int firstNumber, int secondNumber, int i, int j)
        {
            if (firstNumber < 0 || secondNumber < 0)
            {
                throw new ArgumentException();
            }

            if (i < 0 || j < 0 || i > j || i > 31 || j > 31)
            {
                throw new ArgumentException();
            }

            BitArray firstNumberBits = new BitArray(BitConverter.GetBytes(firstNumber));
            BitArray secondNumberBits = new BitArray(BitConverter.GetBytes(secondNumber));

            int secondArrayIndex = 0;
            while (i <= j)
            {
                firstNumberBits[i] = secondNumberBits[secondArrayIndex];
                i++;
                secondArrayIndex++;
            }

            int[] array = new int[1];
            firstNumberBits.CopyTo(array, 0);

            return array[0];
        }
    }
}
