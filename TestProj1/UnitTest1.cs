using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProj1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(Sum(2,4) == 6);
        }

        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
