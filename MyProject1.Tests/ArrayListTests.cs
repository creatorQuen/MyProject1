using NUnit.Framework;

namespace MyProject1.Tests
{
    public class ArrayListTests
    {
        [TestCase("14", " 1, 2, 3, 14 ")]
        public void Add_StringTests(int value, string expected)
        {
            ArrayList arr = new ArrayList(new int[] { 1, 2, 3 });
            arr.Add(value);
            string actual = arr.ToString();

            Assert.AreEqual(expected, actual); 
        }

        [TestCase(14, new int[] {1, 2, 3, 14})]
        public void Add_ArrayTests(int value, int[] expectedArray)
        {
            ArrayList arr = new ArrayList(new int[] {1, 2, 3 });
            arr.Add(value);
            ArrayList actual = arr;
            

            Assert.AreEqual(expectedArray, actual);
        }

        [Test]
        public void Add_Array2Tests()
        {
            ArrayList expectedArr = new ArrayList(new int[] { 1, 2, 3, 14 });

            ArrayList arr = new ArrayList(new int[] { 1, 2, 3 });
            arr.Add(14);
            var actual = arr;

            Assert.AreEqual(expectedArr, actual);
        }


        [TestCase("-17", " -17, 1, 2, 3 ")]
        public void AddNumberAtFrontTests(int value, string expected)
        {
            ArrayList arr = new ArrayList(new int[] { 1, 2, 3 });
            arr.AddNumberAtFront(value);
            string actual = arr.ToString();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////
        /// </summary>

        [Test]
        public void Add_PutNumber_MustSomeArray()
        {
            ArrayList epxpectedArray = new ArrayList(new int[] { 1, 2, 3, 14 });
            ArrayList actualArray = new ArrayList(new int[] { 1, 2, 3 });

            actualArray.Add(14);

            Assert.AreEqual(epxpectedArray, epxpectedArray);
        }


        [Test]
        public void AddNumberAtFront_PutNumber_MustSomeArray()
        {
            ArrayList epxpectedArray = new ArrayList(new int[] { -15, 1, 2, 3});
            ArrayList actualArray = new ArrayList(new int[] { 1, 2, 3 });

            actualArray.Add(-15);

            Assert.AreEqual(epxpectedArray, epxpectedArray);
        }


        //// “¿  Õ≈ Õ¿ƒŒ
        //[Test]
        //public void AddNumberByIndex_PutNumberByIndex_MustSomeArray()
        //{
        //    ArrayList epxpectedArray = new ArrayList(new int[] { 1, 1, 2, 3 });
        //    ArrayList actualArray = new ArrayList(new int[] { 1, 1, 2, 66, 3 });

        //    actualArray.AddNumberByIndex(4, 66);

        //    Assert.AreEqual(epxpectedArray, epxpectedArray);
        //}

        [TestCase("-45", " 87, 545, -45, 14 ")]
        public void AddNumberByIndex_PutNumberByIndex_MustSomeArray(int value, string expected)
        {
            ArrayList arr = new ArrayList(new int[] { 87, 545, 14 });
            arr.AddNumberByIndex(2, -45);
            string actual = arr.ToString();

            Assert.AreEqual(expected, actual);
        }

    }
}