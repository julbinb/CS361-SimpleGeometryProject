using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeometry
{
    /// <summary>
    /// Точка на плоскости
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Абсцисса
        /// </summary>
        private double x;
        /// <summary>
        /// Ордината
        /// </summary>
        private double y;

        /// <summary>
        /// Абсцисса
        /// </summary>
        public double X 
        {
            get { return x; }
        }
        /// <summary>
        /// Ордината
        /// </summary>
        public double Y
        {
            get { return y; }
        }

        /// <summary>
        /// Точка на плоскости
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
