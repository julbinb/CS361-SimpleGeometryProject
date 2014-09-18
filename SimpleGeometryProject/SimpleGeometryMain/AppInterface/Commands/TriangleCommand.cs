using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using SimpleGeometry;

namespace SimpleGeometryMain.AppInterface.Commands
{
    /// <summary>
    /// Абстрактный класс-предок команд для работы с треугольником
    /// </summary>
    abstract class TriangleCommand : AbstractCommand
    {
        protected Triangle t = null;

        protected bool IsCorrect
        {
            get { return t != null; }
        }

        /// <summary>
        /// Предок команды для работы с треугольником (не инициализирован)
        /// </summary>
        public TriangleCommand() { }

        /// <summary>
        /// Предок команды для работы с треугольником
        /// </summary>
        /// <param name="sides">Массив из трёх длин сторон треугольника</param>
        public TriangleCommand(double[] sides)
        {
            Init(sides);
        }

        /// <summary>
        /// Предок команды для работы с треугольником
        /// </summary>
        /// <param name="vertices">Массив из трёх точек-вершин треугольника</param>
        public TriangleCommand(Point[] vertices)
        {
            Init(vertices);
        }

        /// <summary>
        /// Инифиулизирует треугольник
        /// </summary>
        /// <param name="sides">Массив из трёх длин сторон треугольника</param>
        public void Init(double[] sides)
        {
            Debug.Assert(sides != null && sides.Length == 3,
                    "Triangle must be determined by 3 sides");
            foreach (double side in sides)
                Debug.Assert(side > 0, "Triangle sides must be positive");
            _Init(sides);
        }

        /// <summary>
        /// Инифиулизирует треугольник
        /// </summary>
        /// <param name="vertices">Массив из трёх точек-вершин треугольника</param>
        public void Init(Point[] vertices)
        {
            Debug.Assert(vertices != null && vertices.Length == 3,
                "Triangle must be determined by 3 vertices");
            double a = GeometryCalcs.Distance(vertices[0], vertices[1]);
            double b = GeometryCalcs.Distance(vertices[1], vertices[2]);
            double c = GeometryCalcs.Distance(vertices[2], vertices[0]);
            _Init(new double[] { a, b, c });
        }

        /// <summary>
        /// Выполняет команду
        /// </summary>
        /// <returns>Результат выполнения команды</returns>
        public override ICommandResult Execute()
        {
            if (IsCorrect)
                return ExecTriangleCalc();
            else    // треугольник не существует, результат выполнения команды -- ошибка
                return new ErrorCommandResult("Triangle doesn't exist");
        }

        /// <summary>
        /// Конкретные вычисления для треугольника
        /// </summary>
        /// <returns>Результат выполнения команды</returns>
        protected abstract ICommandResult ExecTriangleCalc();

        /// <summary>
        /// Инициализация треугольника по трём сторонам
        /// </summary>
        /// <param name="sides">Массив из трёх длин сторон</param>
        private void _Init(double[] sides)
        {
            // могут быть заданы "плохие" точки, из-за которых стороны нулевые
            // проверка <= на всякий случай
            foreach (double side in sides)
                if (side <= 0)
                    return;
            // если треугольник с такими сторонами не существует, 
            // это некорректно заданная команда
            if (GeometryCalcs.TriangleExists(sides[0], sides[1], sides[2]))
                t = new Triangle(sides[0], sides[1], sides[2]);
        }
    }
}
