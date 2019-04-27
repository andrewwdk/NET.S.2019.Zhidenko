using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(T[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Matrix can't be null");
            }

            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Matrix should be square.");
            }
            else
            {
                this.Size = array.GetLength(0);
            }

            if (this.Size < 1)
            {
                throw new ArgumentException("Size of matrix can't be less than 1.");
            }

            T[,] newArray = new T[this.Size, this.Size];

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    newArray[i, j] = (i == j) ? array[i, j] : default(T);
                }
            }

            this.Array = newArray;
        }

        public override T this[int i, int j]
        {
            set
            {
                if (i != j)
                {
                    throw new InvalidOperationException("You can change only diagonal elements.");
                }

                this.Array[i, j] = value;
                this.OnChange(this, new MatrixChangeEventArgs<T>(i, j, value));
            }
        }

        /// <summary> Add one diagonal matrix to another.</summary>
        /// <param name="firstMatrix"> First matrix. </param>
        /// <param name="secondMatrix"> Second matrix. </param>
        /// <returns> Diagonal matrix. </returns>
        public static DiagonalMatrix<T> operator +(DiagonalMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
        {
            return new DiagonalMatrix<T>(((SquareMatrix<T>)firstMatrix + (SquareMatrix<T>)secondMatrix).Array);
        }
    }
}
