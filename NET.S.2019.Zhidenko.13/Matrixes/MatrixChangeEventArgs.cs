using System;

namespace Matrixes
{
    public class MatrixChangeEventArgs<T> : EventArgs
    {
        public MatrixChangeEventArgs(int i, int j, T element)
        {
            this.I = i;
            this.J = j;
            this.Element = element;
        }

        public int I { get; private set; }

        public int J { get; private set; }

        public T Element { get; private set; }
    }
}
