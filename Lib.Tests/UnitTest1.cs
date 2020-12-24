using Microsoft.VisualStudio.TestTools.UnitTesting;
using SourceCode;

namespace Lib.Tests
{

    [TestClass]
    public class UnitTest1
    {
        Point point1;

        [TestMethod]
        [DataRow("1", "1" ,"1")]
        [DataRow("1.", "1" ,"1")]
        [DataRow("a", "1" ,"1")]
        [DataRow("1^2", "1" ,"1")]
        public void TestIsAPoint(string x, string y, string result)
        {
            bool IsPoint = result == "0" ? false : true;
            point1 = new Point(x, y);
            Assert.AreEqual(IsPoint, point1.IsAPoint());
        }

    }
}
