using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using SimpleGeometry.Shapes.TriangleData;

namespace SimpleGeometry
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// Данные треугольника для вычислений
        /// </summary>
        private ITriangleData data = null;

        /// <summary>
        /// Является ли треугольник равносторонним
        /// </summary>
        public bool IsEquilateral 
        {
            get { return data.IsEquilateral; }
        }

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        public bool IsRightAngled
        {
            get { return data.IsRightAngled; }
        }

        /// <summary>
        /// Является ли треугольник равнобедренным
        /// </summary>
        public bool IsIsosceles
        {
            get { return data.IsIsosceles; }
        }

        /// <summary>
        /// Треугольник, задаваемый длинами сторон
        /// </summary>
        /// <param name="side1">Первая сторона</param>
        /// <param name="side2">Вторая сторона</param>
        /// <param name="side3">Третья сторона</param>
        public Triangle(double side1, double side2, double side3)
        {
            // массив сторон треугольника
            double[] sides = new double[] { side1, side2, side3 };
            _Init(sides);
        }
        /// <summary>
        /// Треугольник, задаваемый вершинами
        /// </summary>
        /// <param name="v1">Первая вершина</param>
        /// <param name="v2">Вторая вершина</param>
        /// <param name="v3">Третья вершина</param>
        public Triangle(Point v1, Point v2, Point v3)
        {
            // массив сторон треугольника
            double[] sides = new double[] { GeometryCalcs.Distance(v1, v2),
                GeometryCalcs.Distance(v2, v1), GeometryCalcs.Distance(v1, v3) };
            _Init(sides);
        }

        /// <summary>
        /// Вычисляет периметр треугольника
        /// </summary>
        /// <returns>Периметр треугольника</returns>
        public double GetPerimeter()
        {
            double result = data.GetPerimeter();
            Debug.Assert(result > 0, "Perimeter must be positive");
            return result;
        }

        /// <summary>
        /// Вычисляет площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public double GetArea()
        {
            double result = data.GetArea();
            Debug.Assert(result > 0, "Area must be positive");
            return result;
        }

        // Приватные вспомогательные методы
        // ----------------------------------------------------------------

        /// <summary>
        /// Инициализация треугольника по сторонам
        /// </summary>
        /// <param name="sides">Массив сторон</param>
        private void _Init(double[] sides)
        {
            Debug.Assert(sides != null);
            Debug.Assert(sides.Length == 3);
            _CheckSides(sides);
            _InitTriangleData(sides);
        }

        /// <summary>
        /// Проверяет корректность сторон треугольника
        /// </summary>
        /// <param name="sides">Массив сторон треугольника</param>
        private void _CheckSides(double[] sides)
        {
            Debug.Assert(sides[0] > 0, "Triangle side 1 must be positive");
            Debug.Assert(sides[1] > 0, "Triangle side 2 must be positive");
            Debug.Assert(sides[2] > 0, "Triangle side 3 must be positive");
            Debug.Assert(GeometryCalcs.TriangleExists(sides[0], sides[1], sides[2]), "Triangle must exist");
        }

        /// <summary>
        /// Инициализирует данные треугольника по массиву его сторон
        /// </summary>
        /// <param name="sides">Массив сторон треугольника</param>
        private void _InitTriangleData(double[] sides)
        {
            // сортируем стороны по длине
            Array.Sort(sides);
            // треугольник может быть равносторонним
            if (GeometryCalcs.TriangleIsEquilateral(sides[0], sides[1], sides[2]))
                this.data = new EquilateralTriangleData(sides[0]);
            // треугольник может быть прямоугольным (первые два элемента после сортировки — катеты)
            else if (GeometryCalcs.TriangleIsRightAngled(sides[0], sides[1], sides[2]))
                this.data = new RightAngledTriangleData(sides[0], sides[1], sides[2]);
            // обычный треугольник, задаваемый сторонами
            else
                this.data = new SemiScaleneTriangleData(sides[0], sides[1], sides[2]);
        }
    }
}
