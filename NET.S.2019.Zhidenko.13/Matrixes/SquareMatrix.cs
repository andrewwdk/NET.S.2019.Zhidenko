using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes
{
    public class SquareMatrix<T>
    {
        private T[,] _array;

        public SquareMatrix()
        {
            MatrixChange += Notify;
        }

        public SquareMatrix(T[,] array) : this()
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
                Size = array.GetLength(0);
            }

            if (Size < 1)
            {
                throw new ArgumentException("Size of matrix can't be less than 1.");
            }

            this._array = array;
        }

        public delegate void MatrixEventHandler(object sender, MatrixChangeEventArgs<T> e);

        public event MatrixEventHandler MatrixChange;

        public int Size { get; protected set; }

        public T[,] Array
        {
            get
            {
                return _array;
            }

            protected set
            {
                _array = value;
            }
        }

        public virtual T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i > Size - 1 || j > Size - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[i, j];
            }

            set
            {
                if (i < 0 || j < 0 || i > Size - 1 || j > Size - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                _array[i, j] = value;
                OnChange(this, new MatrixChangeEventArgs<T>(i, j, value));
            }
        }

        /// <summary> Add one square matrix to another.</summary>
        /// <param name="firstMatrix"> First matrix. </param>
        /// <param name="secondMatrix"> Second matrix. </param>
        /// <returns> Square matrix. </returns>
        public static SquareMatrix<T> operator +(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            if (firstMatrix == null || secondMatrix == null)
            {
                throw new ArgumentNullException("Operands can't be null");
            }

            if (firstMatrix.Size != secondMatrix.Size)
            {
                throw new ArgumentException("Matrixes' sizes should be the same.");
            }

            T[,] newMatrix = new T[firstMatrix.Size, firstMatrix.Size];

            for (int i = 0; i < firstMatrix.Size; i++)
            {
                for (int j = 0; j < firstMatrix.Size; j++)
                {
                    newMatrix[i, j] = Convert.ChangeType((dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j], typeof(T));
                }
            }

            return new SquareMatrix<T>(newMatrix);
        }

        /// <summary> Method to do after event invoked.</summary>
        /// <param name="sender"> Sender. </param>
        /// <param name="e"> Arguments. </param>
        protected void Notify(object sender, MatrixChangeEventArgs<T> e)
        {
            Console.Write("Matrix element at position ({0}, {1}) changed on {2}", e.I, e.J, e.Element.ToString());
        }

        /// <summary> Method which invokes event.</summary>
        /// <param name="sender"> Sender. </param>
        /// <param name="e"> Arguments. </param>
        protected void OnChange(object sender, MatrixChangeEventArgs<T> e)
        {
             MatrixChange?.Invoke(sender, e);
        }
    }
}
