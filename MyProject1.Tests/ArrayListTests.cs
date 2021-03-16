using NUnit.Framework;

namespace MyProject1.Tests
{
    public class ArrayListTests
    {
        [TestCase("14", "1 2 3 14" )]
        public void AddTests(int value, string expected)
        {
            ArrayList arr = new ArrayList(new int[] { 1, 2, 3});
            arr.Add(value);
            string actual = arr.ToString();

            Assert.AreEqual(expected, actual);
        }


        //[TestCase(-17, new int[] { -17, 1, 2, 3, 4})]
        //public void AddNumberAtFrontTests(int value, int[] expected)
        //{
            


        //    Assert.AreEqual(expected, actual);
        //}
    }
}