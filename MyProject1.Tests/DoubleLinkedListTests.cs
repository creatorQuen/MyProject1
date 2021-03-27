using NUnit.Framework;
using System;

namespace MyProject1.Tests
{
    public class DoubleLinkedListTests
    {
        [TestCase(0, new int[] { 0 }, new int[] { })]
        [TestCase(-78, new int[] { 0, -1, 3, -78 }, new int[] { 0, -1, 3 })]
        [TestCase(0, new int[] { 0, -1, 3, 0 }, new int[] { 0, -1, 3 })]
        public void AddTests(int value, int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(-78, new int[] { -78, 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(14, new int[] { 14, 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(0, new int[] { 0 }, new int[] { })]
        public void AddNumberAtFrontTests(int value, int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.AddNumberAtFront(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, -78, new int[] { -78, 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(2, 14, new int[] { 0, -1, 14, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(3, 14, new int[] { 0, -1, 3, 14 }, new int[] { 0, -1, 3 })]
        [TestCase(1, 14, new int[] { 0, 14 }, new int[] { 0 })]
        [TestCase(0, 33, new int[] { 33 }, new int[] { })]
        public void AddNumberByIndexTests(int index, int value, int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.AddNumberByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }
    }
}
