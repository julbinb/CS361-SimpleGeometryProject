using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace SimpleGeometry.Shapes.TriangleData
{
    /// <summary>
    /// Данные равностороннего треугольника
    /// </summary>
    class EquilateralTriangleData : ITriangleData
    {
        /// <summary>
        /// Множитель sqrt(3)/4 для вычисления площади
        /// </summary>
        private static double AREA_FACTOR = Math.Sqrt(3) / 4;

        /// <summary>
        /// Сторона треугольника
        /// </summary>
        private double side;

        /// <summary>
        /// Является ли треугольник равносторонним
        /// </summary>
        public bool IsEquilateral
        {
            get { return true; }
        }

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        public bool IsRightAngled
        {
            get { return false; }
        }

        /// <summary>
        /// Является ли треугольник равнобедренным
        /// </summary>
        public bool IsIsosceles
        {
            get { return true; }
        }

        /// <summary>
        /// Данные равностороннего треугольника
        /// </summary>
        /// <param name="side">Сторона треугольника</param>
        public EquilateralTriangleData(double side)
        {
            Debug.Assert(side > 0, "Triangle side must be positive");
            this.side = side;
        }

        /// <summary>
        /// Вычисляет периметр треугольника
        /// </summary>
        /// <returns>Периметр треугольника</returns>
        public double GetPerimeter()
        {
            return 3 * side;
        }

        /// <summary>
        /// Вычисляет площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public double GetArea()
        {
            return AREA_FACTOR * side * side;
        }
    }
}
