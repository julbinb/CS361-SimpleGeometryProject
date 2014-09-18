using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace SimpleGeometry.Shapes.TriangleData
{
    /// <summary>
    /// Данные прямоугольного треугольника
    /// </summary>
    class RightAngledTriangleData : AllSidesInfoTriangleData
    {
        /// <summary>
        /// Первый катет
        /// </summary>
        private double Cathetus1
        {
            get { return this.side1; }
            set { this.side1 = value; }
        }
        /// <summary>
        /// Второй катет
        /// </summary>
        private double Cathetus2
        {
            get { return this.side2; }
            set { this.side2 = value; }
        }
        /// <summary>
        /// Гипотенуза
        /// </summary>
        private double Hypotenuse
        {
            get { return this.side3; }
            set { this.side3 = value; }
        }

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        public override bool IsRightAngled
        {
            get { return true; }
        }

        /// <summary>
        /// Является ли треугольник равнобедренным
        /// </summary>
        public override bool IsIsosceles
        {
            get { return GeometryCalcs.DoubleAreEqual(Cathetus1, Cathetus2); }
        }

        /// <summary>
        /// Данные прямоугольного треугольника
        /// </summary>
        /// <param name="cathetus1">Первый катет</param>
        /// <param name="cathetus2">Второй катет</param>
        /// <param name="hypotenuse">Гипотенуза</param>
        public RightAngledTriangleData(double cathetus1, double cathetus2, double hypotenuse)
            : base(cathetus1, cathetus2, hypotenuse)
        {
            Debug.Assert(cathetus1 > 0, "Triangle cathetus 1 must be positive");
            Debug.Assert(cathetus2 > 0, "Triangle cathetus 2 must be positive");
            Debug.Assert(hypotenuse > 0, "Triangle hypotenuse must be positive");
            Debug.Assert(cathetus1 <= hypotenuse && cathetus2 <= hypotenuse, "Invalid sides");
            Debug.Assert(GeometryCalcs.TriangleIsRightAngled(cathetus1, cathetus2, hypotenuse),
                "This class must be used for right-angled triangle");
        }

        /// <summary>
        /// Вычисляет площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public override double GetArea()
        {
            return Cathetus1 * Cathetus2 / 2;
        }
    }
}
