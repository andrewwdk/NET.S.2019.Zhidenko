using System;
using System.Collections.Generic;
using BinarySearchTree;
using NUnit.Framework;

namespace NUnit
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void PreorderingTraversingForDefaulIntComparer()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 6, 5, 8, 2, 9, 10, 4, 7 });
            int[] expectedArray = new int[] { 6, 5, 2, 4, 8, 7, 9, 10 };
            List<int> actualList = new List<int>();

            foreach(int element in tree.PreorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void InorderingTraversingForDefaulIntComparer()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 6, 5, 8, 2, 9, 10, 4, 7 });
            int[] expectedArray = new int[] { 2, 4, 5, 6, 7, 8, 9, 10 };
            List<int> actualList = new List<int>();

            foreach (int element in tree.InorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void PostorderingTraversingForDefaulIntComparer()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 6, 5, 8, 2, 9, 10, 4, 7 });
            int[] expectedArray = new int[] { 4, 2, 5, 7, 10, 9, 8, 6 };
            List<int> actualList = new List<int>();

            foreach (int element in tree.PostorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void PreorderingTraversingForInjectedIntComparer()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new IntComparerByAbs() ,new int[] { -6, 5, 8, -2, 9, 10, 4, -7 });
            int[] expectedArray = new int[] { -6, 5, -2, 4, 8, -7, 9, 10 };
            List<int> actualList = new List<int>();

            foreach (int element in tree.PreorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void InorderingTraversingForInjectedIntComparer()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new IntComparerByAbs(), new int[] { -6, 5, 8, -2, 9, 10, 4, -7 });
            int[] expectedArray = new int[] { -2, 4, 5, -6, -7, 8, 9, 10 };
            List<int> actualList = new List<int>();

            foreach (int element in tree.InorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void PostorderingTraversingForInjectedIntComparer()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new IntComparerByAbs() ,new int[] { -6, 5, 8, -2, 9, 10, 4, -7 });
            int[] expectedArray = new int[] { 4, -2, 5, -7, 10, 9, 8, -6 };
            List<int> actualList = new List<int>();

            foreach (int element in tree.PostorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void PreorderingTraversingForDefaulStringComparer()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "d", "b", "c", "a", "e" });
            string[] expectedArray = new string[] { "d", "b", "a", "c", "e" };
            List<string> actualList = new List<string>();

            foreach (string element in tree.PreorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void InorderingTraversingForDefaulStringComparer()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "d", "b", "c", "a", "e" });
            string[] expectedArray = new string[] { "a", "b", "c", "d", "e" };
            List<string> actualList = new List<string>();

            foreach (string element in tree.InorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void PostorderingTraversingForDefaulStringComparer()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "d", "b", "c", "a", "e" });
            string[] expectedArray = new string[] { "a", "c", "b", "e", "d" };
            List<string> actualList = new List<string>();

            foreach (string element in tree.PostorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void PreorderingTraversingForInjectedStringComparer()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new StringComparerByLength(),
                new string[] { "aaaa", "aa", "aaa", "a", "aaaaa" });
            string[] expectedArray = new string[] { "aaaa", "aa", "a", "aaa", "aaaaa" };
            List<string> actualList = new List<string>();

            foreach (string element in tree.PreorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void InorderingTraversingForInjectedStringComparer()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new StringComparerByLength(),
                new string[] { "aaaa", "aa", "aaa", "a", "aaaaa" });
            string[] expectedArray = new string[] { "a", "aa", "aaa", "aaaa", "aaaaa" };
            List<string> actualList = new List<string>();

            foreach (string element in tree.InorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void PostorderingTraversingForInjectedStringComparer()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new StringComparerByLength(),
                new string[] { "aaaa", "aa", "aaa", "a", "aaaaa" });
            string[] expectedArray = new string[] { "a", "aaa", "aa", "aaaaa", "aaaa" };
            List<string> actualList = new List<string>();

            foreach (string element in tree.PostorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void PreorderingTraversingForDefaultBookComparer()
        {
            Book book1 = new Book("1", "name1", "author1", "publisher1", 2000, 100, 100);
            Book book2 = new Book("2", "name2", "author2", "publisher2", 2000, 100, 100);
            Book book3 = new Book("3", "name3", "author3", "publisher3", 2000, 100, 100);
            Book book4 = new Book("4", "name4", "author4", "publisher4", 2000, 100, 100);
            Book book5 = new Book("5", "name5", "author5", "publisher5", 2000, 100, 100);
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(new Book[] { book4, book2, book3, book1, book5});
            Book[] expectedArray = new Book[] { book4, book2, book3, book1, book5 };
            List<Book> actualList = new List<Book>();

            foreach (Book element in tree.PreorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void PreorderingTraversingForInjectedBookComparer()
        {
            Book book1 = new Book("1", "name1", "author1", "publisher1", 2000, 100, 100);
            Book book2 = new Book("2", "name2", "author2", "publisher2", 2000, 100, 100);
            Book book3 = new Book("3", "name3", "author3", "publisher3", 2000, 100, 100);
            Book book4 = new Book("4", "name4", "author4", "publisher4", 2000, 100, 100);
            Book book5 = new Book("5", "name5", "author5", "publisher5", 2000, 100, 100);
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(new BookComparerByIsbn(), new Book[] { book4, book2, book3, book1, book5 });
            Book[] expectedArray = new Book[] { book4, book2, book1, book3, book5 };
            List<Book> actualList = new List<Book>();

            foreach (Book element in tree.PreorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }

        [Test]
        public void PreorderingTraversingForInjectedPointComparer()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);
            Point point3 = new Point(3, 3);
            Point point4 = new Point(4, 4);
            Point point5 = new Point(5, 5);
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new PointComparerBySquareDistance(), new Point[] { point4, point2, point3, point1, point5 });
            Point[] expectedArray = new Point[] { point4, point2, point1, point3, point5 };
            List<Point> actualList = new List<Point>();

            foreach (Point element in tree.PreorderTraversing())
            {
                actualList.Add(element);
            }

            Assert.AreEqual(expectedArray, actualList.ToArray());
        }
    }
}
