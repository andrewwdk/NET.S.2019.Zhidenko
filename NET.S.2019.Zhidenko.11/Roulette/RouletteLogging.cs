using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class RouletteLogging
    {
        public RouletteLogging(Roulette roulette)
        {
            roulette.BlackHit += BlackHit;
            roulette.EvenHit += EvenHit;
            roulette.FirstDozenHit += FirstDozenHit;
            roulette.HighHit += HighRangeHit;
            roulette.LowHit += LowRangeHit;
            roulette.OddHit += OddHit;
            roulette.RedHit += RedHit;
            roulette.RouletteSpin += RouletteWheelSpin;
            roulette.SecondDozenHit += SecondDozenHit;
            roulette.ThirdDozenHit += ThirdDozenHit;
            roulette.ZeroHit += ZeroHit;
        }

        /// <summary> Write log into file when roulette spin is happened </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void RouletteWheelSpin(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//Spin.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Write log into file when zero falls </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void ZeroHit(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//Zero.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Write log into file when red falls </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void RedHit(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//Red.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Write log into file when black falls </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void BlackHit(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//Black.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Write log into file when first dozen falls </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void FirstDozenHit(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//FirstDozen.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Write log into file when second dozen falls </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void SecondDozenHit(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//SecondDozen.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Write log into file when third dozen falls </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void ThirdDozenHit(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//ThirdDozen.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Write log into file when low range falls </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void LowRangeHit(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//LowRange.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Write log into file when high range falls </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void HighRangeHit(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//HighRange.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Write log into file when even falls </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void EvenHit(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//Even.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Write log into file when odd falls </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Arguments </param>
        private void OddHit(object sender, RouletteEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("D://Курсы//Odd.txt"))
            {
                sw.WriteLine(GetString(e.Number, DateTime.Now));
            }
        }

        /// <summary> Make string which represents time and fell number </summary>
        /// <param name="time"> Current time </param>
        /// <param name="number"> Fell number </param>
        /// <returns> String representation</returns>
        private string GetString(int number, DateTime time)
        {
            return time.ToString() + " Number - " + number;
        }
    }
}
