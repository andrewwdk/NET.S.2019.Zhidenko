using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._5
{
    public class Polynomial
    {
        private double[] coefs;

          /// <summary>
          /// Constructor which create a polinom
          /// </summary>
          /// <param name="coef"> Coefficients for polinom</param>
        public Polynomial(double[] coefs)
        {
            if (coefs == null)
                throw new ArgumentNullException();

            /*if (coefs.Length == 0)
                throw new ArgumentException();*/

            this.coefs = new double[coefs.Length];

            for (int i = 0; i < coefs.Length; i++)
                this.coefs[i] = coefs[i];
        }

        /// <summary>
        /// Count of coefs
        /// </summary>
        public int Length { get { return coefs.Length; } }

        /// <summary>
        /// Accesor to coefs
        /// </summary>
        /// <param name="index"> Index of needed coef</param>
        /// <returns> Coef with certain index </returns>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index > coefs.Length - 1)
                    throw new IndexOutOfRangeException();

                return coefs[index];
            }
        }

        /// <summary>
        /// Calculate result of polinom with certain X
        /// </summary>
        /// <param name="value"> Value of X</param>
        /// <returns> Result of polinom </returns>
        public double GetResult(double value)
        {
            double result = 0;

            for (int i = coefs.Length - 1; i >= 0; i--)
                result += coefs[i] * Math.Pow(value, i);

            return result;
        }

        /// <summary>
        /// Transform polinom to a string
        /// </summary>
        /// <returns> Polinomial sting</returns>
        public override string ToString()
        {
            string result = "";

            for(int i = 0; i < coefs.Length; i++)
            {
                if (coefs[i] == 0)
                    continue;

                if (result == "")
                {
                    if (Math.Abs(coefs[i]) != 1)
                    {
                        result += coefs[0].ToString();
                    }
                    else if (coefs[i] == -1)
                        result += "-";            
                }
                else
                {
                    result += (coefs[i] > 0) ? " + " : " - ";

                    if (Math.Abs(coefs[i]) != 1 || i == coefs.Length - 1)
                        result += Math.Abs(coefs[i]).ToString();
                }

                if (i != coefs.Length - 2 && i != coefs.Length - 1)
                {
                    result += ("x^" + (coefs.Length - i - 1).ToString());
                }
                else if (i == coefs.Length - 2)
                    result += "x";
            }
            return result;
        }

        /// <summary>
        /// Hash function
        /// </summary>
        /// <returns> Hash of polynom</returns>
        public override int GetHashCode()
        {
            return coefs.GetHashCode();
        }

        /// <summary>
        /// Compare two polynoms
        /// </summary>
        /// <param name="obj"> Polynom to compare</param>
        /// <returns> Result of comparison </returns>
        public override bool Equals(object obj)
        {
            Polynomial p = (Polynomial)obj;

            if (p == null)
                return false;

            if (coefs.Length != p.Length)
                return false;

            for(int i = 0; i < coefs.Length; i++)
            {
                if (coefs[i] != p[i])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Add one polynom to another
        /// </summary>
        /// <param name="firstPolinom"> The first polynom</param>
        /// <param name="secondPolinom"> The second polynom</param>
        /// <returns> New polynom which is sum of two polynoms </returns>
        public static Polynomial operator +(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            if (firstPolinom == null && secondPolinom == null)
                return null;

            if (firstPolinom == null)
                return secondPolinom;

            if (secondPolinom == null)
                return firstPolinom;

            Polynomial smallerPolinom, biggerPolinom;

            if(firstPolinom.Length < secondPolinom.Length)
            {
                smallerPolinom = firstPolinom;
                biggerPolinom = secondPolinom;
            }
            else
            {
                biggerPolinom = firstPolinom;
                smallerPolinom = secondPolinom;
            }

            double[] newArray = new double[biggerPolinom.Length];

            int i = smallerPolinom.Length - 1, j = biggerPolinom.Length - 1;
            for(; i >= 0; i--, j--)
            {
                newArray[j] = smallerPolinom[i] + biggerPolinom[j];
            }

            for (; j >= 0; j--)
            {
                newArray[j] = biggerPolinom[j];
            }

            return new Polynomial(newArray);
        }

        /// <summary>
        /// Substruct one polynom from another
        /// </summary>
        /// <param name="firstPolinom"> The first polynom</param>
        /// <param name="secondPolinom"> The second polynom</param>
        /// <returns> New polynom which is substruction of two polynoms </returns>
        public static Polynomial operator -(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            if (firstPolinom == null && secondPolinom == null)
                return null;

            if (secondPolinom == null)
                return firstPolinom;

            double[] newCoefs;

            if (firstPolinom == null)
            {
                newCoefs = new double[secondPolinom.Length];

                for (int i = 0; i < secondPolinom.Length; i++)
                    newCoefs[i] = (-1) * secondPolinom[i];

                return new Polynomial(newCoefs);
            }

            if(firstPolinom.Length >= secondPolinom.Length)
            {
                int i = firstPolinom.Length - 1, j = secondPolinom.Length - 1;
                newCoefs = new double[firstPolinom.Length];

                for (; j >= 0; i--, j--)
                {
                    newCoefs[i] = firstPolinom[i] - secondPolinom[j];
                }

                for (; i >= 0; i--)
                {
                    newCoefs[i] = firstPolinom[i];
                }
            }
            else
            {
                int i = firstPolinom.Length - 1, j = secondPolinom.Length - 1;
                newCoefs = new double[secondPolinom.Length];

                for (; i >= 0; i--, j--)
                {
                    newCoefs[j] = firstPolinom[i] - secondPolinom[j];
                }

                for (; j >= 0; j--)
                {
                    newCoefs[j] = (-1) * secondPolinom[j];
                }
            }

            newCoefs = DeleteZeros(newCoefs);

            return new Polynomial(newCoefs);
        }

        /// <summary>
        /// Delete unneccesary members of polynom
        /// </summary>
        /// <param name="coefs">Initial coefficients</param>
        /// <returns>Coefficients without 0 at the beggining</returns>
        private static double[] DeleteZeros(double[] coefs)
        {
            int countOfMembersToDelete = 0;
            int indexOfFirstNotZero = 0;

            for(int i =0;i<coefs.Length;i++)
                if(coefs[i] == 0)
                {
                    countOfMembersToDelete++;
                }
                else
                {
                    indexOfFirstNotZero = i;
                    break;
                }

            double[] newCoefs = new double[coefs.Length - countOfMembersToDelete];

            for (int i = 0; i < newCoefs.Length; i++, indexOfFirstNotZero++)
                newCoefs[i] = coefs[indexOfFirstNotZero];

            return newCoefs;
        }

        /// <summary>
        /// Multiply one polynom with another
        /// </summary>
        /// <param name="firstPolinom"> The first polynom</param>
        /// <param name="secondPolinom"> The second polynom</param>
        /// <returns> New polynom which is multiplication of two polynoms </returns>
        public static Polynomial operator *(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            if (firstPolinom == null && secondPolinom == null)
                return null;

            if (firstPolinom == null)
                return secondPolinom;

            if (secondPolinom == null)
                return firstPolinom;

            double[] newCoefs = new double[firstPolinom.Length + secondPolinom.Length - 1];

            for (int i = 0; i < firstPolinom.Length; i++)
                for (int j = 0; j < secondPolinom.Length; j++)
                    newCoefs[i + j] += firstPolinom[i] * secondPolinom[j];

            return new Polynomial(newCoefs);
        }

        /// <summary>
        /// Compare two polynoms.
        /// </summary>
        /// <param name="firstPolynom">The first polinom</param>
        /// <param name="secondPolynom">The second polinom</param>
        /// <returns>Result of comparison of two polinoms</returns>
        public static bool operator ==(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            if ((object)firstPolynom == null || (object)secondPolynom == null || firstPolynom.Length != secondPolynom.Length)
            {
                return false;
            }

            for (int i = 0; i < firstPolynom.Length; i++)
            {
                if (firstPolynom[i] != secondPolynom[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Compare two polynoms.
        /// </summary>
        /// <param name="firstPolynom">The first polynom</param>
        /// <param name="secondPolynom">The second polynom</param>
        /// <returns>Result of comparison of two polinoms</returns>
        public static bool operator !=(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            if (firstPolynom.Length != secondPolynom.Length || firstPolynom == null || secondPolynom == null)
            {
                return true;
            }

            for (int i = 0; i < firstPolynom.Length; i++)
            {
                if (firstPolynom[i] != secondPolynom[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
