using System;

namespace NET.S._2019.Zhidenko._5
{
    /// <summary>Class for polynomials</summary>
    public class Polynomial
    {
        /// <summary>Coefficients of polynomial</summary>
        private double[] coefs;

        /// <summary>Initializes a new instance of the Polynomial class</summary>
        /// <param name="coefs"> Coefficients for polynomial</param>
        public Polynomial(double[] coefs)
        {
            if (coefs == null)
            {
                throw new ArgumentNullException();
            }

            this.coefs = new double[coefs.Length];

            for (int i = 0; i < coefs.Length; i++)
            {
                this.coefs[i] = coefs[i];
            }
        }

        /// <summary>Gets count of coefficients</summary>
        public int Length
        {
            get
            {
                return this.coefs.Length;
            }
        }

        /// <summary>Accessor to coefficients</summary>
        /// <param name="index"> Index of needed coefficient</param>
        /// <returns> Coefficient with certain index </returns>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index > this.coefs.Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.coefs[index];
            }
        }

        /// <summary> Add one polynomial to another</summary>
        /// <param name="firstPolynom"> The first polynomial</param>
        /// <param name="secondPolynom"> The second polynomial</param>
        /// <returns> New polynomial which is sum of two polynomials </returns>
        public static Polynomial operator +(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            if (firstPolynom == null && secondPolynom == null)
            {
                return null;
            }

            if (firstPolynom == null)
            {
                return secondPolynom;
            }

            if (secondPolynom == null)
            {
                return firstPolynom;
            }

            Polynomial smallerPolynom, biggerPolynom;

            if (firstPolynom.Length < secondPolynom.Length)
            {
                smallerPolynom = firstPolynom;
                biggerPolynom = secondPolynom;
            }
            else
            {
                biggerPolynom = firstPolynom;
                smallerPolynom = secondPolynom;
            }

            double[] newArray = new double[biggerPolynom.Length];

            int i = smallerPolynom.Length - 1, j = biggerPolynom.Length - 1;
            for (; i >= 0; i--, j--)
            {
                newArray[j] = smallerPolynom[i] + biggerPolynom[j];
            }

            for (; j >= 0; j--)
            {
                newArray[j] = biggerPolynom[j];
            }

            return new Polynomial(newArray);
        }

        /// <summary>Subtract one polynomial from another</summary>
        /// <param name="firstPolynom"> The first polynomial</param>
        /// <param name="secondPolynom"> The second polynomial</param>
        /// <returns> New polynomial which is subtraction of two polynomials </returns>
        public static Polynomial operator -(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            if (firstPolynom == null && secondPolynom == null)
            {
                return null;
            }

            if (secondPolynom == null)
            {
                return firstPolynom;
            }

            double[] newCoefs;

            if (firstPolynom == null)
            {
                newCoefs = new double[secondPolynom.Length];

                for (int i = 0; i < secondPolynom.Length; i++)
                {
                    newCoefs[i] = (-1) * secondPolynom[i];
                }

                return new Polynomial(newCoefs);
            }

            if (firstPolynom.Length >= secondPolynom.Length)
            {
                int i = firstPolynom.Length - 1, j = secondPolynom.Length - 1;
                newCoefs = new double[firstPolynom.Length];

                for (; j >= 0; i--, j--)
                {
                    newCoefs[i] = firstPolynom[i] - secondPolynom[j];
                }

                for (; i >= 0; i--)
                {
                    newCoefs[i] = firstPolynom[i];
                }
            }
            else
            {
                int i = firstPolynom.Length - 1, j = secondPolynom.Length - 1;
                newCoefs = new double[secondPolynom.Length];

                for (; i >= 0; i--, j--)
                {
                    newCoefs[j] = firstPolynom[i] - secondPolynom[j];
                }

                for (; j >= 0; j--)
                {
                    newCoefs[j] = (-1) * secondPolynom[j];
                }
            }

            newCoefs = DeleteZeros(newCoefs);

            return new Polynomial(newCoefs);
        }

        /// <summary>Multiply one polynomial with another</summary>
        /// <param name="firstPolynom"> The first polynomial</param>
        /// <param name="secondPolynom"> The second polynomial</param>
        /// <returns> New polynomial which is multiplication of two polynomials </returns>
        public static Polynomial operator *(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            if (firstPolynom == null && secondPolynom == null)
            {
                return null;
            }

            if (firstPolynom == null)
            {
                return secondPolynom;
            }

            if (secondPolynom == null)
            {
                return firstPolynom;
            }

            double[] newCoefs = new double[firstPolynom.Length + secondPolynom.Length - 1];

            for (int i = 0; i < firstPolynom.Length; i++)
            {
                for (int j = 0; j < secondPolynom.Length; j++)
                {
                    newCoefs[i + j] += firstPolynom[i] * secondPolynom[j];
                }
            }

            return new Polynomial(newCoefs);
        }

        /// <summary>Compare two polynomials</summary>
        /// <param name="firstPolynom">The first polynomial</param>
        /// <param name="secondPolynom">The second polynomial</param>
        /// <returns>Result of comparison of two polynomials</returns>
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

        /// <summary>Compare two polynomials</summary>
        /// <param name="firstPolynom">The first polynomial</param>
        /// <param name="secondPolynom">The second polynomial</param>
        /// <returns>Result of comparison of two polynomials</returns>
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

        /// <summary>Calculate result of polynomial with certain X</summary>
        /// <param name="value"> Value of X</param>
        /// <returns> Result of polynomial </returns>
        public double GetResult(double value)
        {
            double result = 0;

            for (int i = this.coefs.Length - 1; i >= 0; i--)
            {
                result += this.coefs[i] * Math.Pow(value, i);
            }

            return result;
        }

        /// <summary>Transform polynomial to a string</summary>
        /// <returns> Polynomial string</returns>
        public override string ToString()
        {
            string result = string.Empty;

            for (int i = 0; i < this.coefs.Length; i++)
            {
                if (this.coefs[i] == 0)
                {
                    continue;
                }

                if (result == string.Empty)
                {
                    if (Math.Abs(this.coefs[i]) != 1)
                    {
                        result += this.coefs[0].ToString();
                    }
                    else if (this.coefs[i] == -1)
                    {
                        result += "-";
                    }
                }
                else
                {
                    result += (this.coefs[i] > 0) ? " + " : " - ";

                    if (Math.Abs(this.coefs[i]) != 1 || i == this.coefs.Length - 1)
                    {
                        result += Math.Abs(this.coefs[i]).ToString();
                    }
                }

                if (i != this.coefs.Length - 2 && i != this.coefs.Length - 1)
                {
                    result += "x^" + (this.coefs.Length - i - 1).ToString();
                }
                else if (i == this.coefs.Length - 2)
                {
                    result += "x";
                }
            }

            return result;
        }

        /// <summary>Hash function</summary>
        /// <returns> Hash of polynomial</returns>
        public override int GetHashCode()
        {
            return this.coefs.GetHashCode();
        }

        /// <summary>Compare two polynomials </summary>
        /// <param name="obj"> Polynomial to compare</param>
        /// <returns> Result of comparison </returns>
        public override bool Equals(object obj)
        {
            Polynomial p = (Polynomial)obj;

            if (p == null)
            {
                return false;
            }

            if (this.coefs.Length != p.Length)
            {
                return false;
            }

            for (int i = 0; i < this.coefs.Length; i++)
            {
                if (this.coefs[i] != p[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>Delete unnecessary members of polynomial</summary>
        /// <param name="coefs">Initial coefficients</param>
        /// <returns>Coefficients without 0 at the beginning</returns>
        private static double[] DeleteZeros(double[] coefs)
        {
            int countOfMembersToDelete = 0;
            int indexOfFirstNotZero = 0;

            for (int i = 0; i < coefs.Length; i++)
            {
                if (coefs[i] == 0)
                {
                    countOfMembersToDelete++;
                }
                else
                {
                    indexOfFirstNotZero = i;
                    break;
                }
            }

            double[] newCoefs = new double[coefs.Length - countOfMembersToDelete];

            for (int i = 0; i < newCoefs.Length; i++, indexOfFirstNotZero++)
            {
                newCoefs[i] = coefs[indexOfFirstNotZero];
            }

            return newCoefs;
        }
    }
}
