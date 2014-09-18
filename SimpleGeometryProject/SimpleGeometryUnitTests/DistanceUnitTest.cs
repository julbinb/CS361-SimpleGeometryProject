using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SimpleGeometry;

namespace TestSimpleGeometry
{
    [TestClass]
    public class DistanceUnitTest
    {
        /// <summary>
        /// Константа для сравнения вещественных чисел на равенство
        /// </summary>
        public const double DOUBLE_EPSILON = 0.000001;

        [TestMethod]
        public void TestPointDistance()
        {
            Assert.AreEqual(3.5, GeometryCalcs.Distance(new Point(0, 0), new Point(3.5, 0)),
                "test dist #1");
            Assert.AreEqual(4.75, GeometryCalcs.Distance(new Point(-1, -3), new Point(-1, 1.75)),
                "test dist #2");
        }

        [TestMethod]
        public void TestCoordsDistance()
        {
            Assert.AreEqual(26.121783, GeometryCalcs.Distance(-1.5, -7, -25.345, -17.666), DOUBLE_EPSILON,
                "test dist coord #1");
            Assert.AreEqual(5, GeometryCalcs.Distance(-2, 1, 2, -2),
                "test dist coord #2");
        }
    }
}
