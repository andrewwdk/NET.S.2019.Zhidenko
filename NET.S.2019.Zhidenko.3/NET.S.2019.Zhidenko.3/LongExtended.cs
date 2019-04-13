using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._3
{
    public static class LongExtended
    {
        private const int BitsInByte = 8;

        /// <summary>
        /// Present long number in binary format
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns> Bits of long number</returns>
        public static string GetBinaryString(this long value, int size = BitsInByte * sizeof(long))
        {
            if (value == 0)
            {
                return new string('0', size);
            }

             string binaryString = string.Empty;

             while (value > 0)
             {
                 binaryString = (value % 2).ToString() + binaryString;
                 value /= 2;
             }

            int length = binaryString.Length;

            // -1 because 1 bit goes to sign
            for (int i = 0; i < (size - length); i++) 
            {
                 binaryString = "0" + binaryString;
            }

             return binaryString;
        }
    }
}
