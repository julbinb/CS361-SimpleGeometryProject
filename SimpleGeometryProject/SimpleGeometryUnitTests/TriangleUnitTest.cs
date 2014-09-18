using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SimpleGeometry;

namespace TestSimpleGeometry
{
    [TestClass]
    public class TriangleUnitTest
    {
        /// <summary>
        /// Константа для сравнения вещественных чисел на равенство
        /// </summary>
        public const double DOUBLE_EPSILON = 0.0000001;

        private Triangle t1_eq = new Triangle(3.5, 3.5, 3.5);
        private Triangle t2_eq = new Triangle(12.278, 12.278, 12.278);

        private Triangle t3_rh = new Triangle(3, 4, 5);
        private Triangle t4_rh = new Triangle(5, 4, 3);
        private Triangle t5_rh = new Triangle(3, 5, 4);
        private Triangle t6_rh = new Triangle(
            new Point(-1, -2.5), new Point(-1, 6.3), new Point(4, -2.5));
        private Triangle t7_rh = new Triangle(
            new Point(4, -2.5), new Point(-1, -2.5), new Point(-1, 6.3));

        private Triangle t8_isl = new Triangle(7, 6, 7);
        private Triangle t9_isl = new Triangle(6, 7, 7);
        private Triangle t10_isl = new Triangle(0.7, 0.7, 1.36);

        /// <summary>
        /// Тесты для проверки вида треугольника
        /// </summary>
        [TestMethod]
        public void TestTriangleKind()
        {
            _CheckEquilateral(t1_eq, "t1_eq");
            _CheckEquilateral(t2_eq, "t2_eq");

            _CheckRightAngledDiffSides(t3_rh, "t3_rh");
            _CheckRightAngledDiffSides(t4_rh, "t4_rh");
            _CheckRightAngledDiffSides(t5_rh, "t5_rh");

            _CheckRightAngledIsosceles(t6_rh, "t6_rh");
            _CheckRightAngledIsosceles(t7_rh, "t7_rh");

            _CheckIsosceles(t8_isl, "t8_isl");
            _CheckIsosceles(t9_isl, "t9_isl");
            _CheckIsosceles(t10_isl, "t10_isl");
        }

        private void _CheckEquilateral(Triangle t, string name)
        {
            Assert.IsTrue(t.IsEquilateral, name + " 1");
            Assert.IsTrue(t.IsIsosceles, name + " 2");
            Assert.IsFalse(t.IsRightAngled, name + " 3");
        }

        private void _CheckRightAngledDiffSides(Triangle t, string name)
        {
            Assert.IsFalse(t.IsEquilateral, name + " 1");
            Assert.IsFalse(t.IsIsosceles, name + " 2");
            Assert.IsTrue(t.IsRightAngled, name + " 3");
        }

        private void _CheckRightAngledIsosceles(Triangle t, string name)
        {
            Assert.IsFalse(t.IsEquilateral, name + " 1");
            Assert.IsFalse(t.IsIsosceles, name + " 2");
            Assert.IsTrue(t.IsRightAngled, name + " 3");
        }

        private void _CheckIsosceles(Triangle t, string name)
        {
            Assert.IsFalse(t.IsEquilateral, name + " 1");
            Assert.IsTrue(t.IsIsosceles, name + " 2");
            Assert.IsFalse(t.IsRightAngled, name + " 3");
        }
    }
}
