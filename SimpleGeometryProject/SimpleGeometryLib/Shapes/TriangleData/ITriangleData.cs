using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeometry.Shapes.TriangleData
{
    /// <summary>
    /// Интерфейс данных, задающих параметры треугольника
    /// </summary>
    interface ITriangleData
    {
        /// <summary>
        /// Является ли треугольник равносторонним
        /// </summary>
        bool IsEquilateral { get; }

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        bool IsRightAngled { get; }

        /// <summary>
        /// Является ли треугольник равнобедренным
        /// </summary>
        bool IsIsosceles { get; }

        /// <summary>
        /// Вычисляет периметр треугольника
        /// </summary>
        /// <returns>Периметр треугольника</returns>
        double GetPerimeter();

        /// <summary>
        /// Вычисляет площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        double GetArea();
    }
}
