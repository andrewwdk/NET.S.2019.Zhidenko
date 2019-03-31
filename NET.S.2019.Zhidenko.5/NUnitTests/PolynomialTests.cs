using System;
using NUnit.Framework;
using NET.S._2019.Zhidenko._5;

namespace NUnitTests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void PolynomialConstructor_WithNullArray_ReturnArgumentNullException()
        {
            double[] array = null;

            Assert.Throws<ArgumentNullException>(() => new Polynomial(array));
        }

       /* [TestCase(new double[] { })]
        public void PolynomialConstructor_With_0_elements_ReturnArgumentException(double[] array)
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(array));
        }*/

        [TestCase(new double[] { 1, 1, 1 }, 1, ExpectedResult = 3)]
        [TestCase(new double[] { 0, 0, 0 }, 1, ExpectedResult = 0)]
        [TestCase(new double[] { -1, -1, -1 }, -1, ExpectedResult = -1)]
        public double GetResult_ReturnsCorrectResult(double[] array, double value)
        {
            Polynomial p = new Polynomial(array);

            return p.GetResult(value);
        }

        [TestCase(new double[] { 1, 1, 1}, ExpectedResult = "x^2 + x + 1")]
        [TestCase(new double[] { 0, 1, 1 }, ExpectedResult = "x + 1")]
        [TestCase(new double[] { 5, 5, 1 }, ExpectedResult = "5x^2 + 5x + 1")]
        [TestCase(new double[] { -1, -4, 1 }, ExpectedResult = "-x^2 - 4x + 1")]
        public string ToString_ReturnCorrectPolinom(double[] array)
        {
            Polynomial p = new Polynomial(array);

            return p.ToString();
        }

        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 1, 1}, new double[] { 2, 2, 2})]
        [TestCase(new double[] { 1, 1 }, new double[] { 1, 1, 1 }, new double[] { 1, 2, 2 })]
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 1 }, new double[] { 1, 2, 2 })]
        public void AddOnePolynomToAnother_ReturnsCorrectResult(double[] array1, double[] array2, double[] resultArray)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial expctedPolynom = new Polynomial(resultArray);
            Polynomial actualPolynom;

            actualPolynom = p1 + p2;

            Assert.AreEqual(expctedPolynom, actualPolynom);
        }

        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 1, 1 }, new double[] {})]
        [TestCase(new double[] { 1, 1 }, new double[] { 1, 1, 1 }, new double[] { -1, 0, 0})]
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 1 }, new double[] { 1, 0, 0})]
        [TestCase(new double[] { 3, 3, 3 }, new double[] { 1, 1, 1 }, new double[] { 2, 2, 2})]
        [TestCase(new double[] { 3, 3, 3 }, new double[] { 3, 1, 1 }, new double[] { 2, 2 })]
        public void SubstructOnePolynomFromAnother_ReturnsCorrectResult(double[] array1, double[] array2, double[] resultArray)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial expctedPolynom = new Polynomial(resultArray);
            Polynomial actualPolynom;

            actualPolynom = p1 - p2;

            Assert.AreEqual(expctedPolynom, actualPolynom);
        }

        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3 }, new double[] { 3, 8, 14, 8, 3 })]
        public void MultiplyOnePolynomWithAnother_ReturnsCorrectResult(double[] array1, double[] array2, double[] resultArray)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial expctedPolynom = new Polynomial(resultArray);
            Polynomial actualPolynom;

            actualPolynom = p1 * p2;

            Assert.AreEqual(expctedPolynom, actualPolynom);
        }
    } 
}
