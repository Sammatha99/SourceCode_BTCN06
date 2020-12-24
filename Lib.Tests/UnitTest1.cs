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
        Triangle triangle;

        [TestMethod]
        [DataRow("1", "1" ,true)]
        [DataRow("1.", "1" ,true)]
        [DataRow("a", "1" ,false)]
        [DataRow("1^2", "1" ,false)]
        public void TestIsAPoint(string x, string y, bool expectedResult)
        {
            point1 = new Point(x, y);
            Assert.AreEqual(expectedResult, point1.IsAPoint());
        }

        [TestMethod]
        [DataRow("1", "1", "2","-3", 4.123105626)]
        [DataRow("1", "2", "3","4", 2.828427125)]
        [DataRow("-1", "-2", "0","3", 5.099019514)]
        public void TestGetDistanceBetween2Points(string x1, string y1, string x2, string y2, double expectedResult)
        {
            point1 = new Point(x1, y1);
            point2 = new Point(x2, y2);
            double result = Point.getDistanceBetween2Points(point1, point2);
            Assert.IsTrue(Math.Abs(result - expectedResult) < Delta);
        }

        [TestMethod]
        [DataRow(2, 2, 2, true)]
        [DataRow(3, 4, 5, true)]
        [DataRow(2, 2, 4, false)]
        public void TestIsAtriangle(double edge1, double edge2, double edge3, bool expectedResult)
        {
            triangle = new Triangle(edge1, edge2, edge3);
            Assert.AreEqual(expectedResult, triangle.IsATriangle());
        }

        [TestMethod]
        [DataRow(2, 2, 2, "đều")]
        [DataRow(3, 4, 5, "vuông")]
        [DataRow(2, 2, 2.828427125, "vuông cân")]
        [DataRow(4, 7.21, 10.77, "thường")]
        public void TestGetTypeOfTriangle(double edge1, double edge2, double edge3, string expectedResult)
        {
            triangle = new Triangle(edge1, edge2, edge3);
            Assert.AreEqual(expectedResult.ToLower(), triangle.GetTypeOfTriangle().Trim().ToLower());
        }

        [TestMethod]
        [DataRow(2, 2, 2, 6)]
        [DataRow(3, 4, 5, 12)]
        [DataRow(2, 2, 2.83, 6.83)]
        [DataRow(4, 7.21, 10.77, 21.98)]
        public void TestGetPerimeter(double edge1, double edge2, double edge3, double expectedResult)
        {
            triangle = new Triangle(edge1, edge2, edge3);
            Assert.IsTrue(Math.Abs(triangle.GetPerimeter() - expectedResult) < Delta);
        }
    }
}
