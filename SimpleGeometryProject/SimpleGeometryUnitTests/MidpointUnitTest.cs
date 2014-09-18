using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SimpleGeometry;

namespace SimpleGeometryUnitTests
{
    [TestClass]
    public class MidpointUnitTest
    {
        [TestMethod]
        public void TestCoordsMidPoint()
        {
            Assert.AreEqual(new Point(0.5, -1.5), GeometryCalcs.Midpoint(-4.5, -3, 5.5, 0),
                "midpoint coords #1");
        }
    }
}
