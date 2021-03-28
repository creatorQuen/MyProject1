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



        [TestCase(new int[] { -78, 0, -1 }, new int[] { -78, 0, -1, 3 })]
        [TestCase(new int[] { 0, -1, 14 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(new int[] { 0, -1, 3 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(new int[] { 0 }, new int[] { 0, -1 })]
        [TestCase(new int[] { }, new int[] { -1 })]

        public void RemoveLastItemTests(int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.RemoveLastItem();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 0, -1, 3 }, new int[] { -78, 0, -1, 3 })]
        [TestCase(new int[] { -1, 14, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(new int[] { 3 }, new int[] { -1, 3 })]
        [TestCase(new int[] { }, new int[] { 33 })]
        public void RemoveFirstItemTests(int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.RemoveFirstItem();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(1, new int[] { 0, -1, 14 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(3, new int[] { 0 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(1, new int[] { }, new int[] { 0 })]
        public void RemoveSomeItemsAtLastTests(int items, int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.RemoveSomeItemsAtLast(items);

            Assert.AreEqual(expected, actual);
        }

    }
}
