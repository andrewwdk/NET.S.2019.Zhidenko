using System;
using Matrixes;
using NUnit.Framework;

namespace NUnit
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void SumOfTwoSquareMatrixReturnCorrectREsult()
        {
            SquareMatrix<int> firstMatrix = new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            SquareMatrix<int> secondMatrix = new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            SquareMatrix<int> expectedMatrix = new SquareMatrix<int>(new int[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } });

            SquareMatrix<int> actualMatrix = firstMatrix + secondMatrix;

            Assert.AreEqual(actualMatrix.Array, expectedMatrix.Array);
        }

        [Test]
        public void SumOfTwoDiagonalMatrixReturnCorrectResult()
        {
            DiagonalMatrix<int> firstMatrix = new DiagonalMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            DiagonalMatrix<int> secondMatrix = new DiagonalMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            DiagonalMatrix<int> expectedMatrix = new DiagonalMatrix<int>(new int[,] { { 2, 0, 0 }, { 0, 10, 0 }, { 0, 0, 18 } });

            DiagonalMatrix<int> actualMatrix = firstMatrix + secondMatrix;

            Assert.AreEqual(actualMatrix.Array, expectedMatrix.Array);
        }

        [Test]
        public void SumOfTwoSymmetricMatrixReturnCorrectResult()
        {
            SymmetricMatrix<int> firstMatrix = new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            SymmetricMatrix<int> secondMatrix = new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            SymmetricMatrix<int> expectedMatrix = new SymmetricMatrix<int>(new int[,] { { 2, 4, 6 }, { 4, 10, 12 }, { 6, 12, 18 } });

            SymmetricMatrix<int> actualMatrix = firstMatrix + secondMatrix;

            Assert.AreEqual(actualMatrix.Array, expectedMatrix.Array);
        }

        [Test]
        public void SumOfSymmetricAndDiagonalMatrixReturnCorrectResult()
        {
            SymmetricMatrix<int> firstMatrix = new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            DiagonalMatrix<int> secondMatrix = new DiagonalMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            SymmetricMatrix<int> expectedMatrix = new SymmetricMatrix<int>(new int[,] { { 2, 2, 3 }, { 2, 10, 6 }, { 3, 6, 18 } });

            SymmetricMatrix<int> actualMatrix = firstMatrix + secondMatrix;

            Assert.AreEqual(actualMatrix.Array, expectedMatrix.Array);
        }
    } 
}
