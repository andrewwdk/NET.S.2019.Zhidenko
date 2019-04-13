using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._2
{
    public class Filter
    {
        /// <summary>
        /// Select all numbers which contain certain digit
        /// </summary>
        /// <param name="list">Initial list of numbers</param>
        /// <param name="digit">Digit</param>
        /// <returns>Numbers with certain digit</returns>
        public static List<int> FilterDigits(List<int> list, int digit)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }

            if (list.Count == 0)
            {
                throw new ArgumentException();
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentException();
            }

            List<int> filteredList = new List<int>();

            foreach (int number in list)
            {
                if (number.ToString().Contains(digit.ToString()))
                {
                    filteredList.Add(number);
                }
            }

            return filteredList;
        }
    }
}
