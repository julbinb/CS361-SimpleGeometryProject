using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SimpleGeometry;

namespace SimpleGeometryUnitTests
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

        private Triangle t11_scal = new Triangle(11, 8, 9.5);
        private Triangle t12_scal = new Triangle(new Point(-1.75, -0.6),
            new Point(0.2, -2.4), new Point(1.375, 2));

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

            _CheckScalene(t11_scal, "t11_scal");
            _CheckScalene(t12_scal, "t11_scal");
        }

        /// <summary>
        /// Тесты для проверки вычисления периметра
        /// </summary>
        [TestMethod]
        public void TestTrianglePerimeter()
        {
            Assert.AreEqual(10.5, t1_eq.GetPerimeter(), DOUBLE_EPSILON,
                "t1_eq perimeter");
            Assert.AreEqual(36.834, t2_eq.GetPerimeter(), DOUBLE_EPSILON,
                "t2_eq perimeter");

            Assert.AreEqual(12, t3_rh.GetPerimeter(), DOUBLE_EPSILON,
                "t3_rh perimeter");
            Assert.AreEqual(12, t4_rh.GetPerimeter(), DOUBLE_EPSILON,
                "t4_rh perimeter");
            Assert.AreEqual(12, t5_rh.GetPerimeter(), DOUBLE_EPSILON,
                "t5_rh perimeter");

            Assert.AreEqual(23.92126474, t6_rh.GetPerimeter(), DOUBLE_EPSILON,
                "t6_rh perimeter");
            Assert.AreEqual(23.92126474, t7_rh.GetPerimeter(), DOUBLE_EPSILON,
                "t7_rh perimeter");

            Assert.AreEqual(20, t8_isl.GetPerimeter(), DOUBLE_EPSILON,
                "t8_isl perimeter");
            Assert.AreEqual(20, t9_isl.GetPerimeter(), DOUBLE_EPSILON,
                "t9_isl perimeter");

            Assert.AreEqual(28.5, t11_scal.GetPerimeter(), DOUBLE_EPSILON,
                "t11_scal perimeter");
            Assert.AreEqual(11.273130733, t12_scal.GetPerimeter(), DOUBLE_EPSILON,
                "t12_scal perimeter");
        }

        /// <summary>
        /// Тесты для проверки вычисления площади
        /// </summary>
        [TestMethod]
        public void TestTriangleArea()
        {
            double area = t1_eq.GetArea();
            Assert.AreEqual(5.30440559, area, DOUBLE_EPSILON,
                "t1_eq area");
            area = t2_eq.GetArea();
            Assert.AreEqual(65.27635477, area, DOUBLE_EPSILON,
                "t2_eq area");

            area = t3_rh.GetArea();
            Assert.AreEqual(6, area, DOUBLE_EPSILON,
                "t3_rh area");
            area = t4_rh.GetArea();
            Assert.AreEqual(6, area, DOUBLE_EPSILON,
                "t4_rh area");
            area = t5_rh.GetArea();
            Assert.AreEqual(6, area, DOUBLE_EPSILON,
                "t5_rh area");

            area = t6_rh.GetArea();
            Assert.AreEqual(22, area, DOUBLE_EPSILON,
                "t6_rh area");
            area = t7_rh.GetArea();
            Assert.AreEqual(22, area, DOUBLE_EPSILON,
                "t7_rh area");

            area = t8_isl.GetArea();
            Assert.AreEqual(18.97366596, area, DOUBLE_EPSILON,
                "t8_isl area");
            area = t9_isl.GetArea();
            Assert.AreEqual(18.97366596, area, DOUBLE_EPSILON,
                "t9_isl area");
            area = t10_isl.GetArea();
            Assert.AreEqual(0.11297008, area, DOUBLE_EPSILON,
                "t10_isl area");

            area = t11_scal.GetArea();
            Assert.AreEqual(37.07967561, area, DOUBLE_EPSILON,
                "t11_scal area");
            area = t12_scal.GetArea();
            Assert.AreEqual(5.3475, area, DOUBLE_EPSILON,
                "t12_scal area");
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

        private void _CheckScalene(Triangle t, string name)
        {
            Assert.IsFalse(t.IsEquilateral, name + " 1");
            Assert.IsFalse(t.IsIsosceles, name + " 2");
            Assert.IsFalse(t.IsRightAngled, name + " 3");
        }
    }
}
