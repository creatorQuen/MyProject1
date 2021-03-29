using NUnit.Framework;
using System;

namespace MyProject1.Tests
{
    public class LinkedListTests
    {
        [TestCase(0, new int[] { 0 }, new int[] { })]
        [TestCase(-78, new int[] { 0, -1, 3, -78 }, new int[] { 0, -1, 3 })]
        [TestCase(0, new int[] { 0, -1, 3, 0 }, new int[] { 0, -1, 3 })]
        public void AddTests(int value, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(-78, new int[] { -78, 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(14, new int[] { 14, 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(0, new int[] { 0 }, new int[] { })]
        public void AddNumberAtFrontTests(int value, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
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
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddNumberByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { -78, 0, -1 }, new int[] { -78, 0, -1, 3 })]
        [TestCase(new int[] { 0, -1, 14 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(new int[] { 0, -1, 3 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(new int[] { 0 }, new int[] { 0, -1 })]
        [TestCase(new int[] {  }, new int[] { -1 })]
        
        public void RemoveLastItemTests(int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.RemoveLastItem();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 0, -1, 3 }, new int[] { -78, 0, -1, 3 })]
        [TestCase(new int[] { -1, 14, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(new int[] { 3 }, new int[] { -1, 3 })]
        [TestCase(new int[] { }, new int[] { 33 })]
        public void RemoveFirstItemTests(int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.RemoveFirstItem();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, new int[] { 0, -1, 3 }, new int[] { -78, 0, -1, 3 })]
        [TestCase(1, new int[] { 0, 14, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(3, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(0, new int[] { }, new int[] { 33 })]
        public void RemoveByIndexTests(int index, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(1, new int[] { 0, -1, 14 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(3, new int[] { 0 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(1, new int[] {  }, new int[] { 0 })]
        public void RemoveSomeItemsAtLastTests(int items, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.RemoveSomeItemsAtLast(items);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, new int[] { 0, -1, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(1, new int[] { -1, 14, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(3, new int[] { 14 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(1, new int[] {  }, new int[] { 3})]
        public void RemoveSomeItemsAtFrontTests(int items, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.RemoveSomeItemsAtFront(items);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, 0, new int[] { 0, -1, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(1, 2, new int[] { 0, 3, 5, 7 }, new int[] { 0, -1, 14, 3, 5, 7 })]
        [TestCase(3, 1, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(5, 4, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 5, 5, 5, 5 })]
        [TestCase(4, 3, new int[] { 2, 2, 2, 2, 2 }, new int[] { 2, 2, 2, 2, 7, 7, 7, 2 })]
        public void RemoveByIndexElementsTests(int index, int items, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.RemoveByIndexElements(index, items);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, 0, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(1, -1, new int[] { 0, -1 })]
        [TestCase(3, 14, new int[] { 0, -1, 3, 14 })]
        public void GetByIndexTests(int index, int expected, int[] actualArray)
        {
            LinkedList arr = new LinkedList(actualArray);
            int actual = arr.GetByIndex(index);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(66, 3, new int[] { 0, -1, 3, 66, 77, 66 })]
        [TestCase(1, -1, new int[] { 0, -1 })]
        [TestCase(-1, 1, new int[] { 0, -1, 3, 14 })]
        [TestCase(14, 0, new int[] { 14 })]
        public void GetIndexByItemTests(int value, int expected, int[] actualArray)
        {
            LinkedList arr = new LinkedList(actualArray);
            int actual = arr.GetIndexByItem(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, 12, new int[] { 12, -1, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(2, -78, new int[] { 0, -1, -78, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(1, 45, new int[] { 0, 45, 3, 14 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(0, 45, new int[] { 45 }, new int[] { -1 })]
        [TestCase(2, 33, new int[] { -1, 100, 33 }, new int[] { -1 , 100, 500 })]
        public void ChangeItemByIndexTests(int index, int value, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.ChangeItemByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 7, 6, 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 608, 77, 66, 3, -1, 0 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(new int[] { 3, 14, 8, -1, 0 }, new int[] { 0, -1, 8, 14, 3})]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        public void ReverseItemsTests(int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.ReverseItems();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(608, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(0, new int[] { 0, -1, 0, -1, 0 })]
        [TestCase(0, new int[] { 0 })]
        public void FindMaximumNumberTests(int expected, int[] actualArray)
        {
            LinkedList arr = new LinkedList(actualArray);
            int actual = arr.FindMaximumNumber();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(-12, new int[] { 0, -12, 3, 66, 77, 608 })]
        [TestCase(-96, new int[] { 12, 0, -9, 66, 77, -96 })]
        [TestCase(-1, new int[] { 0, -1, 0, -1, 0 })]
        [TestCase(0, new int[] { 0 })]
        public void FindMinimumNumberTests(int expected, int[] actualArray)
        {
            LinkedList arr = new LinkedList(actualArray);
            int actual = arr.FindMinimumNumber();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(5, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(4, new int[] { 12, 0, -9, 66, 77, -96 })]
        [TestCase(0, new int[] { 0, -1, 0, -1, 0 })]
        [TestCase(0, new int[] { 0 })]
        public void FindIndexOfMaximumNumberTests(int expected, int[] actualArray)
        {
            LinkedList arr = new LinkedList(actualArray);
            int actual = arr.FindIndexOfMaximumNumber();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(1, new int[] { 0, -12, 3, 66, 77, 608 })]
        [TestCase(1, new int[] { 0, -1, 0, -1, 0 })]
        [TestCase(0, new int[] { 0 })]
        public void FindIndexOfMinimumNumberTests(int expected, int[] actualArray)
        {
            LinkedList arr = new LinkedList(actualArray);
            int actual = arr.FindIndexOfMinimumNumber();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { -1, 0, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(new int[] { -7, 0, 1, 58, 99, 100 }, new int[] { 100, 99, -7, 58, 1, 0 })]
        [TestCase(new int[] { -1, 0, 3, 8, 14 }, new int[] { 0, -1, 8, 14, 3 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        public void SortNumberUpTests(int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.SortNumberUp();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 608, 77, 66, 3, 0, -1 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(new int[] { 14, 8, 3, 0, -1 }, new int[] { 0, -1, 8, 14, 3 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        public void SortNumberDownTests(int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.SortNumberDown();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, 0, new int[] { -1, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(1, -1, new int[] { 0, -1, 14, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(14, 3, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(55, 4, new int[] { 11, 22, 33, 44, 66, 77 }, new int[] { 11, 22, 33, 44, 55, 66, 77 })]
        public void RemoveFirstByValueAndGetIndexTests(int value, int expectedIndex, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList arrActual = new LinkedList(actualArray);
            int actual = arrActual.RemoveFirstByValueAndGetIndex(value);

            Assert.AreEqual(expectedIndex, actual);
            Assert.AreEqual(expected, arrActual);
            
        }



        [TestCase(3, 1, new int[] { 0, -1, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(0, 2, new int[] { -1, 3 }, new int[] { 0, -1, 0, 3 })]
        [TestCase(14, 0, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(5, 4, new int[] { 3, 4, 6, 7 }, new int[] { 3, 4, 5, 5, 5, 5, 6, 7 })]
        [TestCase(88, 1, new int[] { 11, 22, 33, 44, 55, 66, 77 }, new int[] { 11, 22, 33, 44, 55, 66, 77, 88 })]
        public void RemoveAllByValueTests(int value, int expectedValue, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList arrActual = new LinkedList(actualArray);
            int actual = arrActual.RemoveAllByValue(value);

            Assert.AreEqual(expected, arrActual);
            Assert.AreEqual(expectedValue, actual);
        }



        [TestCase(new int[] { 55, 55, 55 }, new int[] { 0, -1, 3, 66, 77, 608, 55, 55, 55 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(new int[] { 55, 55, 55 }, new int[] { -1, 55, 55, 55 }, new int[] { -1 })]
        [TestCase(new int[] { 55, 55, 55 }, new int[] { 55, 55, 55 }, new int[] { })]
        public void AddListAtLastTests(int[] arr, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddListAtLast(arr);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 11, 11, 11 }, new int[] { 11, 11, 11, 0, -1, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(new int[] { 11, 11, 11 }, new int[] { 11, 11, 11, -1 }, new int[] { -1 })]
        [TestCase(new int[] { 11, 11, 11 }, new int[] { 11, 11, 11 }, new int[] { })]
        public void AddListAtFrontTests(int[] arr, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddListAtFront(arr);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(2, new int[] { 55, 55, 55 }, new int[] { 0, -1, 55, 55, 55, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(1, new int[] { 55, 55, 55 }, new int[] { 0, 55, 55, 55, 9 }, new int[] { 0, 9 })]
        [TestCase(0, new int[] { 55, 55, 55 }, new int[] { 55, 55, 55 }, new int[] { })]
        public void AddListByIndexTests(int index, int[] arr, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddListByIndex(index, arr);

            Assert.AreEqual(expected, actual);
        }
    }
}
