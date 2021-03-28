using System;
using NUnit.Framework;

namespace MyProject1.Tests
{
    public class ExpetimentTests
    {
        [TestCase(new int[] { 0, 8 }, new int[] { 0, -1, 3 })]
        public void RemoveLastItemTestsDobleREMOVE(int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.RemoveLastItem();
            actual.RemoveLastItem();
            actual.AddNumberByIndex(1, 8);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 8 }, new int[] { })]
        public void RemoveLastItemTestsDobleREMOVEandAdd(int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.RemoveLastItem();
            actual.RemoveLastItem();
            actual.AddNumberByIndex(0, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -78, 8, 0 }, new int[] { -78, 0, -1, 3 })]
        public void RemoveLastItemTestsDobleREMOVEandAddsdfsdf(int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.RemoveLastItem();
            actual.RemoveLastItem();
            actual.AddNumberByIndex(1, 8);

            Assert.AreEqual(expected, actual);
        }

    }
}
