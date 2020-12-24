using Microsoft.VisualStudio.TestTools.UnitTesting;
using SourceCode;
using System;
using System.Globalization;

namespace Lib.Tests
{

    [TestClass]
    public class UnitTest1
    {
        double Delta = 0.00001;
        Point point1;
        Point point2;

        [TestMethod]
        [DataRow("1", "1" ,"1")]
        [DataRow("1.", "1" ,"1")]
        [DataRow("a", "1" ,"1")]
        [DataRow("1^2", "1" ,"1")]
        public void TestIsAPoint(string x, string y, string expectedResult)
        {
            bool IsPoint = expectedResult == "0" ? false : true;
            point1 = new Point(x, y);
            Assert.AreEqual(IsPoint, point1.IsAPoint());
        }

        [TestMethod]
        [DataRow("1", "1", "2","-3", "4.123105626")]
        [DataRow("1", "2", "2","-3", "2.828427125")]
        [DataRow("-1", "-2", "0","3", "5.099019514")]
        public void TestGetDistanceBetween2Points(string x1, string y1, string x2, string y2, string expectedResult)
        {
            point1 = new Point(x1, y1);
            point2 = new Point(x2, y2);
            double result = Point.getDistanceBetween2Points(point1, point2);
            double ExpectedResult = double.Parse(expectedResult, CultureInfo.InvariantCulture.NumberFormat);
            Assert.IsTrue(Math.Abs(result - ExpectedResult) < Delta);
        }

    }
}
