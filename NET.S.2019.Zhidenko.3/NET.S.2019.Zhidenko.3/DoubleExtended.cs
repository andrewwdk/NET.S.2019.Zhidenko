using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._3
{
    public static class DoubleExtended
    {
        const int maxOffset = 1023;
        const int bitsForMantissa = 52;
        const int bitsForExponent = 11;

        /// <summary>
        /// Present double number in IEEE754 format
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns> Bits of double number </returns>
        public static string GetBinaryString(this double number)
        {
            //Double number consists of S(sign, 1 bit), E(exponent, 11 bits), M(mantissa, 52 bits)
            // (-1)^S * 1,M * 2^(E - 1023), 1023 = 2^(11 - 1) - 1

            string S, E, M;

            if (number < 0 || double.IsNaN(number) || double.IsNegativeInfinity(number) || double.IsNegativeInfinity(1 / number))
            {
                S = "1";
            }
            else
            {
                S = "0";
            }

            number = Math.Abs(number);

            // Imagine E as window and M as offset in this window. Possible windows are [0, 1], [1, 2], [2, 4] ... [2^127, 2^128]
            // So find power of 2 of left part of window
            int valueOfE;

            if (double.IsInfinity(number) || double.IsNaN(number))
            {
                valueOfE = (int)Math.Pow(2, 11) - 1;
            }
            else
            {
                valueOfE = GetE(ref number);
            }

            
            E = ((long)valueOfE).GetBinaryString(bitsForExponent);

            M = FractionDecimalToBinary(number - 1);

            return S + E + M;
        }

        /// <summary>
        /// Find offset
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns> Offset </returns>
        private static int GetE(ref double value)
        {
            int result = 0;

            if (value < 1)
            {
                if (value == 0.0)
                {
                    return result;
                }
                else
                {
                    while (value < 1)
                    {
                        value = value * 2;
                        result--;
                    }
                }
            }
            else
            {
                while (value > 2)
                {
                    value = value / 2;
                    result++;
                }
            }

            result = result + maxOffset;

            if (result < 0)
            {
                return 0;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Convert fraction part of a number to binary format
        /// </summary>
        /// <param name="number">Fraction part</param>
        /// <returns> String of bits </returns>
        private static string FractionDecimalToBinary(double fraction)
        {
            if (double.IsNegativeInfinity(fraction))
            {
                fraction = 0;
            }

            if (double.IsNaN(fraction))
            {
                fraction = 0.5;
            }

            string result = "";
            int integerOverflow = 0;
            int length = bitsForMantissa;

            if (fraction == 0)
            {
                fraction = Math.Pow(2, -bitsForMantissa);
            }

            for (int i = 0; i < length; i++)
            {
                fraction *= 2;
                integerOverflow = (int)fraction % 2;
                fraction -= integerOverflow;
                result += integerOverflow.ToString();
            }

            return result;
        }
    
    }
}
