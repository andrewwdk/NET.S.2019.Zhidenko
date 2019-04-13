using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace NET.S._2019.Zhidenko._2
{
    public class NumberFinder
    {
        private static int Time { get; set; }

        /// <summary>
        /// Find next bigger number and show time by StopWatch
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="time">Time</param>
        /// <returns>Next bigger number if it's possible or null if not</returns>
        public static int? FindNextBiggerNumberAndGetTimeByStopWatch(int number, out long time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int? finalNumber = FindNextBiggerNumber(number);

            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return finalNumber;
        }

        /// <summary>
        /// Find next bigger number and show time by Timer
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="time">Time</param>
        /// <returns>Next bigger number if it's possible or null if not</returns>
        public static int? FindNextBiggerNumberAndGetTimeByTimer(int number, out long time)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(TimerProc);
            timer.Start();

            int? finalNumber = FindNextBiggerNumber(number);

            timer.Stop();
            time = Time;
            return finalNumber;
        }

        /// <summary>
        /// Find next bigger number
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>Next bigger number if it's possible or null if not</returns>
        public static int? FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException();
            }

            if (number <= 9)
            {
                return null;
            }

            if (number == int.MaxValue)
            {
                return null;
            }

            int num = number, index = 0;
            List<int> listOfDigits = new List<int>();

            while (num > 0)
            {
                listOfDigits.Add(num % 10);
                num /= 10;
            }

            listOfDigits.Reverse();

            // find 1st digit from the end that bigger than the next
            for (int i = listOfDigits.Count - 1; i > 0; i--)
            {
                if (listOfDigits[i] > listOfDigits[i - 1])
                {
                    index = i;
                    break;
                }
            }

            if (index == 0)
            {
                return null;
            }

            // find the smallest digit from right side of the digit which will be swaped(index - 1)
            int smallestDigitIndex = index;
            for (int j = index + 1; j < listOfDigits.Count; j++)
            {
                if (listOfDigits[j] < listOfDigits[smallestDigitIndex] && listOfDigits[j] > listOfDigits[index - 1])
                {
                    smallestDigitIndex = j;
                }
            }

            Swap(listOfDigits, index - 1, smallestDigitIndex);

            for (int i = index; i < listOfDigits.Count; i++)
            {
                for (int j = i + 1; j < listOfDigits.Count; j++)
                {
                    if (listOfDigits[i] > listOfDigits[j])
                    {
                        Swap(listOfDigits, i, j);
                    }
                }
            }

            return GetFinalNumber(listOfDigits);
        }

        /// <summary>
        /// Increment time
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private static void TimerProc(object sender, ElapsedEventArgs e)
        {
            Time++;
        }

        /// <summary>
        /// Swap two elements in list
        /// </summary>
        /// <param name="list">Initial list</param>
        /// <param name="i">Index of the first element</param>
        /// <param name="j">Index of the second element</param>
        private static void Swap(List<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /// <summary>
        /// Make number from list of digits
        /// </summary>
        /// <param name="list">Initial list</param>
        /// <returns>Final number</returns>
        private static int GetFinalNumber(List<int> list)
        {
            int num = 0;
            int degree = 1;

            for (int k = list.Count - 1; k >= 0; k--)
            {
                num += list[k] * degree;
                degree *= 10;
            }

            return num;
        }
    }
}
