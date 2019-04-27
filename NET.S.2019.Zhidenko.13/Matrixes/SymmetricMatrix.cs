using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(T[,] array)
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
                for (int j = i; j < this.Size; j++)
                {
                    newArray[i, j] = array[i, j];

                    if (i != j)
                    {
                        newArray[j, i] = newArray[i, j];
                    }
                }
            }

            this.Array = newArray;
        }

        public override T this[int i, int j]
        {
            set
            {
                this.Array[i, j] = value;

                if (i != j)
                {
                    this.Array[j, i] = value;
                } 
 
                this.OnChange(this, new MatrixChangeEventArgs<T>(i, j, value));
            }
        }

        /// <summary> Add one symmetric matrix to another.</summary>
        /// <param name="firstMatrix"> First matrix. </param>
        /// <param name="secondMatrix"> Second matrix. </param>
        /// <returns> Symmetric matrix. </returns>
        public static SymmetricMatrix<T> operator +(SymmetricMatrix<T> firstMatrix, SymmetricMatrix<T> secondMatrix)
        {
            return new SymmetricMatrix<T>(((SquareMatrix<T>)firstMatrix + (SquareMatrix<T>)secondMatrix).Array);
        }

        /// <summary> Add symmetric matrix to diagonal matrix.</summary>
        /// <param name="firstMatrix"> Symmetric matrix. </param>
        /// <param name="secondMatrix"> Diagonal matrix. </param>
        /// <returns> Symmetric matrix. </returns>
        public static SymmetricMatrix<T> operator +(SymmetricMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
        {
            return new SymmetricMatrix<T>(((SquareMatrix<T>)firstMatrix + (SquareMatrix<T>)secondMatrix).Array);
        }

        /// <summary> Add diagonal matrix to symmetric matrix.</summary>
        /// <param name="firstMatrix"> Diagonal matrix. </param>
        /// <param name="secondMatrix"> Symmetric matrix. </param>
        /// <returns> Symmetric matrix. </returns>
        public static SymmetricMatrix<T> operator +(DiagonalMatrix<T> firstMatrix, SymmetricMatrix<T> secondMatrix)
        {
            return new SymmetricMatrix<T>(((SquareMatrix<T>)firstMatrix + (SquareMatrix<T>)secondMatrix).Array);
        }
    }
}
