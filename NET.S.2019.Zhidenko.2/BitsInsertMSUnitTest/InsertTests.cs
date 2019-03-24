using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.S._2019.Zhidenko._2;

namespace BitsInsertMSUnitTest
{
    [TestClass]
    public class InsertTests
    {
        [TestMethod]
        public void Method_withNumbers_8and15_withIndexes_3and8_returns_120()
        {
            //Arrange
            int firstNumber = 8;
            int secondNumber = 15;
            int i = 3;
            int j = 8;
            int result;
            int expectedResult = 120;

            //Act
            result = BitsInsert.InsertNumber(firstNumber, secondNumber, i, j);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Method_withNumbers_15and15_withIndexes_0and0_returns_15()
        {
            //Arrange
            int firstNumber = 15;
            int secondNumber = 15;
            int i = 0;
            int j = 0;
            int result;
            int expectedResult = 15;

            //Act
            result = BitsInsert.InsertNumber(firstNumber, secondNumber, i, j);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Method_withNumbers_8and15_withIndexes_0and0_returns_9()
        {
            //Arrange
            int firstNumber = 8;
            int secondNumber = 15;
            int i = 0;
            int j = 0;
            int result;
            int expectedResult = 9;

            //Act
            result = BitsInsert.InsertNumber(firstNumber, secondNumber, i, j);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Method_withIndexes_4and3_returns_ArgumentException()
        {
            //Arrange
            int firstNumber = 8;
            int secondNumber = 15;
            int i = 4;
            int j = 3;

            //Assert
            Assert.ThrowsException<ArgumentException>(() => BitsInsert.InsertNumber(firstNumber, secondNumber, i, j));
        }

        [TestMethod]
        public void Method_withNegativeNumbers_returns_ArgumentException()
        {
            //Arrange
            int firstNumber = -8;
            int secondNumber = -15;
            int i = 4;
            int j = 3;

            //Assert
            Assert.ThrowsException<ArgumentException>(() => BitsInsert.InsertNumber(firstNumber, secondNumber, i, j));
        }
    }
}
