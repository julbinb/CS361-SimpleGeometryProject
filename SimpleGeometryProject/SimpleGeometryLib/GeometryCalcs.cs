using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;           // для использования Debug.Assert

namespace SimpleGeometry
{
    /// <summary>
    /// Статический класс, предоставляющий методы простых
    /// геометрических вычислений
    /// </summary>
    public static class GeometryCalcs
    {
        /// <summary>
        /// Константа для сравнения вещественных чисел на равенство
        /// </summary>
        public const double DOUBLE_EPSILON = 0.0000001;

        /// <summary>
        /// Определяет равенство вещественных значений a и b
        /// </summary>
        /// <param name="a">Первое значение</param>
        /// <param name="b">Второе значение</param>
        /// <returns>Истину, если вещественные значения a и b считаются равными</returns>
        public static bool DoubleAreEqual(double a, double b)
        {
            return Math.Abs(a - b) < DOUBLE_EPSILON;
        }

        // Расстояние между точками
        // ----------------------------------------------------------------

        /// <summary>
        /// Вычисляет расстояние между точками a и b
        /// </summary>
        /// <param name="a">Точка на плоскости</param>
        /// <param name="b">Точка на плоскости</param>
        /// <returns>Расстояние между точками a и b</returns>
        public static double Distance(Point a, Point b)
        { 
            double dx = a.X - b.X, dy = a.Y - b.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            Debug.Assert(dist >= 0, "Distance can't be negative");
            return dist;
        }

        /// <summary>
        /// Вычисляет расстояние между точками (ax, xy) и (bx, by)
        /// </summary>
        /// <param name="ax">Абсцисса точки a</param>
        /// <param name="ay">Ордината точки a</param>
        /// <param name="bx">Абсцисса точки b</param>
        /// <param name="by">Ордината точки b</param>
        /// <returns>Расстояние между точками (ax, xy) и (bx, by)</returns>
        public static double Distance(double ax, double ay, double bx, double by)
        {
            return Distance(new Point(ax, ay), new Point(bx, by));
        }

        // Середина отрезка
        // ----------------------------------------------------------------

        /// <summary>
        /// Вычисляет середину отрезка ab
        /// </summary>
        /// <param name="a">Один конец отрезка</param>
        /// <param name="b">Другой конец отрезка</param>
        /// <returns>Точку — середину отрезка ab</returns>
        public static Point Midpoint(Point a, Point b)
        {
            return new Point((a.X + b.X) / 2, (a.Y + b.Y) / 2);
        }

        /// <summary>
        /// Вычисляет середину отрезка (ax, ay)..(bx, by)
        /// </summary>
        /// <param name="ax">Абсцисса первого конца отрезка</param>
        /// <param name="ay">Ордината первого конца отрезка</param>
        /// <param name="bx">Абсцисса второго конца отрезка</param>
        /// <param name="by">Ордината второго конца отрезка</param>
        /// <returns>Точку — середину отрезка (ax, ay)..(bx, by)</returns>
        public static Point Midpoint(double ax, double ay, double bx, double by)
        {
            return Midpoint(new Point(ax, ay), new Point(bx, by));
        }

        // Свойства треугольника
        // ----------------------------------------------------------------

        public static bool TriangleExists(double a, double b, double c)
        {
            Debug.Assert(a > 0, "Triangle side-a must be positive");
            Debug.Assert(b > 0, "Triangle side-b must be positive");
            Debug.Assert(c > 0, "Triangle side-c must be positive");
            return (a <= b + c) && (b <= c + a) && (c <= a + b);
        }

        public static bool TriangleIsEquilateral(double a, double b, double c)
        {
            Debug.Assert(a > 0, "Triangle side-a must be positive");
            Debug.Assert(b > 0, "Triangle side-b must be positive");
            Debug.Assert(c > 0, "Triangle side-c must be positive");
            return DoubleAreEqual(a, b) && DoubleAreEqual(b, c);
        }

        public static bool TriangleIsRightAngled(double a, double b, double c)
        {
            Debug.Assert(a > 0, "Triangle side-a must be positive");
            Debug.Assert(b > 0, "Triangle side-b must be positive");
            Debug.Assert(c > 0, "Triangle side-c must be positive");
            // массив сторон треугольника
            double[] sides = new double[] { a, b, c };
            // сортируем стороны по длине
            Array.Sort(sides);
            // теперь, если треугольник прямоугольный, катеты это sides[0], sides[1]
            return DoubleAreEqual(sides[0] * sides[0] + sides[1] * sides[1], sides[2] * sides[2]);
        }
    }
}
