using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace SimpleGeometry.Shapes.TriangleData
{
    /// <summary>
    /// Абстрактный класс данных треугольника (не являющегося равносторонним), 
    /// заданного тремя сторонами
    /// </summary>
    abstract class AllSidesInfoTriangleData : ITriangleData
    {
        /// <summary>
        /// Первая сторона
        /// </summary>
        protected double side1;
        /// <summary>
        /// Вторая сторона
        /// </summary>
        protected double side2;
        /// <summary>
        /// Третья сторона
        /// </summary>
        protected double side3;

        /// <summary>
        /// Является ли треугольник равносторонним
        /// </summary>
        public bool IsEquilateral
        {
            get { return false; }
        }

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        public abstract bool IsRightAngled { get; }

        /// <summary>
        /// Является ли треугольник равнобедренным
        /// </summary>
        public virtual bool IsIsosceles
        {
            get
            {
                return GeometryCalcs.DoubleAreEqual(side1, side2)
                    || GeometryCalcs.DoubleAreEqual(side2, side3)
                    || GeometryCalcs.DoubleAreEqual(side3, side1);
            }
        }

        /// <summary>
        /// Данные обычного (не равностороннего) треугольника, заданного тремя сторонами
        /// </summary>
        /// <param name="cathetus1">Первая сторона</param>
        /// <param name="cathetus2">Вторая сторона</param>
        /// <param name="hypotenuse">Третья сторона</param>
        protected AllSidesInfoTriangleData(double side1, double side2, double side3)
        {
            Debug.Assert(side1 > 0, "Triangle side 1 must be positive");
            Debug.Assert(side2 > 0, "Triangle side 2 must be positive");
            Debug.Assert(side3 > 0, "Triangle side 3 must be positive");
            Debug.Assert(GeometryCalcs.TriangleExists(side1, side2, side3), "Triangle must exist");
            Debug.Assert(!GeometryCalcs.TriangleIsEquilateral(side1, side2, side3),
                "This class must be used for non-equilateral triangle");
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        /// <summary>
        /// Вычисляет периметр треугольника
        /// </summary>
        /// <returns>Периметр треугольника</returns>
        public double GetPerimeter()
        {
            return side1 + side2 + side3;
        }

        /// <summary>
        /// Вычисляет площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public virtual double GetArea()
        {
            double p = GetPerimeter() / 2;
            return p * (p - side1) * (p - side2) * (p - side3);
        }
    }
}
