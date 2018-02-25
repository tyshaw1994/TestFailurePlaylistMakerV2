using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProj2
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsTrue(Difference(5, 3) == 2);
        }

        public int Difference(int x, int y)
        {
            return x - y;
        }
    }
}
