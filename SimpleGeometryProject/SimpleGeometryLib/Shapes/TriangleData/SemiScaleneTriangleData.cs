using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace SimpleGeometry.Shapes.TriangleData
{
    /// <summary>
    /// Данные треугольника, который не является прямоугольным и
    /// не является равносторонним.
    /// Стороны хранятся в отсортированном виде
    /// </summary>
    class SemiScaleneTriangleData : AllSidesInfoTriangleData
    {
        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        public override bool IsRightAngled
        {
            get { return false; }
        }

        /// <summary>
        /// Является ли треугольник равнобедренным
        /// </summary>
        public override bool IsIsosceles
        {
            get
            {
                // стороны упорядочены по возрастанию, поэтому либо первые две равны,
                // либо вторые две
                return GeometryCalcs.DoubleAreEqual(side1, side2)
                    || GeometryCalcs.DoubleAreEqual(side2, side3);
            }
        }

        /// <summary>
        /// Данные треугольника, который не является прямоугольным и
        /// не является равносторонним.
        /// Стороны должны быть заданы в отсортированном виде
        /// </summary>
        /// <param name="side1">Первая сторона (самая короткая)</param>
        /// <param name="side2">Вторая сторона (средняя по длине)</param>
        /// <param name="side3">Третья сторона (самая длинная)</param>
        public SemiScaleneTriangleData(double side1, double side2, double side3)
            : base(side1, side2, side3)
        {
            Debug.Assert(side1 > 0, "Triangle side 1 must be positive");
            Debug.Assert(side2 > 0, "Triangle side 2 must be positive");
            Debug.Assert(side3 > 0, "Triangle side 3 must be positive");
            Debug.Assert(GeometryCalcs.TriangleExists(side1, side2, side3), "Triangle must exist");
            Debug.Assert(side1 <= side2 && side2 <= side3, "Triangle sides must be sorted");
        }
    }
}
