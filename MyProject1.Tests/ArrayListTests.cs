using NUnit.Framework;
using System;

namespace MyProject1.Tests
{
    public class ArrayListTests
    {
        [TestCase(-78, new int[] { 0, -1, 3, -78 }, new int[] { 0, -1, 3 })]
        [TestCase(0, new int[] { 0, -1, 3, 0 }, new int[] { 0, -1, 3 })]
        [TestCase(0, new int[] { 0 }, new int[] { })]
        public void AddTests(int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(-78, new int[] { -78, 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(14, new int[] { 14, 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(0, new int[] { 0 }, new int[] { })]
        public void AddNumberAtFrontTests(int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddNumberAtFront(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, -78, new int[] { -78, 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(2, 14, new int[] { 0, -1, 14, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(3, 14, new int[] { 0, -1, 3, 14 }, new int[] { 0, -1, 3 })]
        [TestCase(0, 33, new int[] { 33 }, new int[] { })]
        public void AddNumberByIndexTests(int index, int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddNumberByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, 56)]
        [TestCase(100, 12)]
        public void AddNumberByIndex_UserIndexOutOfRage_ShouldIndexOutOfRangeException(int index, int value)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<IndexOutOfRangeException>(() => expected.AddNumberByIndex(index, value));
        }



        [TestCase(new int[] { -78, 0, -1 }, new int[] { -78, 0, -1, 3 })]
        [TestCase(new int[] { 0, -1, 14 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(new int[] { 0, -1, 3 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(new int[] { }, new int[] { 33 })]
        public void RemoveLastItemTests(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveLastItem();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 0, -1, 3 }, new int[] { -78, 0, -1, 3 })]
        [TestCase(new int[] { -1, 14, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(new int[] { -1, 3, 14 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(new int[] { }, new int[] { 33 })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirstItemTests(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveFirstItem();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, new int[] { 0, -1, 3 }, new int[] { -78, 0, -1, 3 })]
        [TestCase(1, new int[] { 0, 14, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(3, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3, 14 })]
        [TestCase(0, new int[] { }, new int[] { 33 })]
        public void RemoveItemByIndexTests(int index, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveItemByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1)]
        [TestCase(100)]
        public void RemoveItemByIndex_UserIndexOutOfRage_ShouldIndexOutOfRangeException(int index)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<IndexOutOfRangeException>(() => expected.RemoveItemByIndex(index));
        }



        [TestCase(0, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3 })]
        [TestCase(1, new int[] { 0, -1, 14 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(3, new int[] { 0 }, new int[] { 0, -1, 3, 14 })]
        public void RemoveSomeItemsAtLastTests(int items, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveSomeItemsAtLast(items);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100)]
        public void RemoveSomeItemsAtLast_ItemsLargeThanSizeArray_ShouldArgumentOutOfRangeException(int items)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<ArgumentOutOfRangeException>(() => expected.RemoveSomeItemsAtLast(items));
        }

        [TestCase(-2)]
        public void RemoveSomeItemsAtLast_ItemsNegativeQuantity_ShouldArgumentException(int items)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<ArgumentException>(() => expected.RemoveSomeItemsAtLast(items));
        }



        [TestCase(0, new int[] { 0, -1, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(1, new int[] { -1, 14, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(3, new int[] { 14 }, new int[] { 0, -1, 3, 14 })]
        public void RemoveSomeItemsAtFrontTests(int items, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveSomeItemsAtFront(items);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100)]
        public void RemoveSomeItemsAtFront_ItemsLargeThanSizeArray_ShouldArgumentOutOfRangeException(int items)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<ArgumentOutOfRangeException>(() => expected.RemoveSomeItemsAtFront(items));
        }

        [TestCase(-2)]
        public void RemoveSomeItemsAtFront_ItemsNegativeQuantity_ShouldArgumentException(int items)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<ArgumentException>(() => expected.RemoveSomeItemsAtFront(items));
        }



        [TestCase(0, 0, new int[] { 0, -1, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(2, 2, new int[] { 0, -1 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(3, 1, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3, 14 })]
        public void RemoveByIndexElementsTests(int index, int items, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveByIndexElements(index, items);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 2)]
        public void RemoveByIndexElements_IndexOutOfRange_ShouldIndexOutOfRangeException(int index, int items)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<IndexOutOfRangeException>(() => expected.RemoveByIndexElements(index, items));
        }

        [TestCase(3, 7)]
        public void RemoveByIndexElements_ItemsAfterIndexMoreThanLength_ShouldIndexOutOfRangeException(int index, int items)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<IndexOutOfRangeException>(() => expected.RemoveByIndexElements(index, items));
        }

        [TestCase(1, -2)]
        public void RemoveByIndexElements_ItemsNegativeQuantity_ShouldArgumentException(int index, int items)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<ArgumentException>(() => expected.RemoveByIndexElements(index, items));
        }



        [TestCase(0, 0,new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(1, -1, new int[] { 0, -1 })]
        [TestCase(3, 14, new int[] { 0, -1, 3, 14 })]
        public void GetByIndexTests(int index, int expected, int[] actualArray)
        {
            ArrayList arr = new ArrayList(actualArray);
            int actual = arr.GetByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100)]
        public void GetByIndex_IndexOutOfRange_ShouldIndexOutOfRangeException(int index)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<IndexOutOfRangeException>(() => expected.GetByIndex(index));
        }



        [TestCase(66, 3, new int[] { 0, -1, 3, 66, 77, 66 })]
        [TestCase(1, -1, new int[] { 0, -1 })]
        [TestCase(-1, 1, new int[] { 0, -1, 3, 14 })]
        public void GetIndexByItemTests(int value, int expected, int[] actualArray)
        {
            ArrayList arr = new ArrayList(actualArray);
            int actual = arr.GetIndexByItem(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, 12, new int[] { 12, -1, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(2, -78, new int[] { 0, -1, -78, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(1, 45, new int[] { 0, 45, 3, 14 }, new int[] { 0, -1, 3, 14 })]
        public void ChangeItemByIndexTests(int index, int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.ChangeItemByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 34)]
        public void ChangeItemByIndex_IndexOutOfRange_ShouldIndexOutOfRangeException(int index, int value)
        {
            ArrayList expected = new ArrayList(new int[] { 0, -1, 3, 14 });

            Assert.Throws<IndexOutOfRangeException>(() => expected.ChangeItemByIndex(index, value));
        }



        [TestCase(new int[] { 608, 77, 66, 3, -1, 0 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase( new int[] { 3, 14, 8, -1, 0 }, new int[] { 0, -1, 8, 14, 3 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        public void ReverseItemsTests(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.ReverseItems();

            Assert.AreEqual(expected, actual);
        }

        [TestCase()]
        public void ReverseItems_EmptyArray_ShouldArgumentException()
        {
            ArrayList expected = new ArrayList(new int[] { });

            Assert.Throws<ArgumentException>(() => expected.ReverseItems());
        }



        [TestCase(608, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(0, new int[] { 0, -1, 0, -1, 0 })]
        [TestCase(0, new int[] { 0 })]
        public void FindMaximumNumberTests(int expected, int[] actualArray)
        {
            ArrayList arr = new ArrayList(actualArray);
            int actual = arr.FindMaximumNumber();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(-12, new int[] { 0, -12, 3, 66, 77, 608 })]
        [TestCase(-1, new int[] { 0, -1, 0, -1, 0 })]
        [TestCase(0, new int[] { 0 })]
        public void FindMinimumNumberTests(int expected, int[] actualArray)
        {
            ArrayList arr = new ArrayList(actualArray);
            int actual = arr.FindMinimumNumber();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(5, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(0, new int[] { 0, -1, 0, -1, 0 })]
        [TestCase(0, new int[] { 0 })]
        public void FindIndexOfMaximumNumberTests(int expected, int[] actualArray)
        {
            ArrayList arr = new ArrayList(actualArray);
            int actual = arr.FindIndexOfMaximumNumber();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(1, new int[] { 0, -12, 3, 66, 77, 608 })]
        [TestCase(1, new int[] { 0, -1, 0, -1, 0 })]
        [TestCase(0, new int[] { 0 })]
        public void FindIndexOfMinimumNumberTests(int expected, int[] actualArray)
        {
            ArrayList arr = new ArrayList(actualArray);
            int actual = arr.FindIndexOfMinimumNumber();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { -1, 0, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(new int[] { -1, 0, 3, 8, 14 }, new int[] { 0, -1, 8, 14, 3 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        public void BubbleSortNumberUpTests(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.BubbleSortNumberUp();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 608, 77, 66, 3, 0, -1 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(new int[] { 14, 8, 3, 0, -1 }, new int[] { 0, -1, 8, 14, 3 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        public void BublbeSortNumberDownTests(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.BubbleSortNumberDown();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, 0, new int[] { -1, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(1, -1, new int[] { 0, -1, 14, 3 }, new int[] { 0, -1, 14, 3 })]
        [TestCase(14, 3, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3, 14 })]
        public void RemoveFirstByValueAndGetIndexTests(int value, int expectedIndex, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList arrActual = new ArrayList(actualArray);
            int actual = arrActual.RemoveFirstByValueAndGetIndex(value);
            
            Assert.AreEqual(expected, arrActual);
            Assert.AreEqual(expectedIndex, actual);
        }



        [TestCase(3, 1, new int[] { 0, -1, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(0, 2, new int[] { -1, 3 }, new int[] { 0, -1, 0, 3 })]
        [TestCase(14, -1, new int[] { 0, -1, 3 }, new int[] { 0, -1, 3})]
        public void RemoveAllByValueTests(int value, int expectedValue, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList arrActual = new ArrayList(actualArray);
            int actual = arrActual.RemoveAllByValue(value);

            Assert.AreEqual(expected, arrActual);
            Assert.AreEqual(expectedValue, actual);
        }



        [TestCase(new int[] { 55, 55, 55 }, new int[] { 0, -1, 3, 66, 77, 608, 55, 55, 55 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(new int[] { 55, 55, 55 }, new int[] { -1, 55, 55, 55 }, new int[] { -1 })]
        [TestCase(new int[] { 55, 55, 55 }, new int[] { 55, 55, 55 }, new int[] { })]
        public void AddArrayAtLastTests(int[] arr, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddArrayAtLast(arr);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 11, 11, 11 }, new int[] { 11, 11, 11, 0, -1, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(new int[] { 11, 11, 11 }, new int[] { 11, 11, 11, -1}, new int[] { -1 })]
        [TestCase(new int[] { 11, 11, 11 }, new int[] { 11, 11, 11 }, new int[] { })]
        public void AddArrayAtFrontTests(int[] arr, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddArrayAtFront(arr);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(2, new int[] { 55, 55, 55 }, new int[] { 0, -1, 55, 55, 55, 3, 66, 77, 608 }, new int[] { 0, -1, 3, 66, 77, 608 })]
        [TestCase(1, new int[] { 55, 55, 55 }, new int[] { 0, 55, 55, 55, 9 }, new int[] { 0, 9})]
        [TestCase(0, new int[] { 55, 55, 55 }, new int[] { 55, 55, 55 }, new int[] { })]
        public void AddArrayByIndexTests(int index, int[] arr, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddArrayByIndex(index, arr);

            Assert.AreEqual(expected, actual);
        }



    }
}