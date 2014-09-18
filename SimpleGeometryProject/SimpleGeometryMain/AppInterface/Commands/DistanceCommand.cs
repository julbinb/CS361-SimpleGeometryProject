using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleGeometry;

namespace SimpleGeometryMain.AppInterface.Commands
{
    /// <summary>
    /// Команда вычисления расстояния между точками
    /// </summary>
    class DistanceCommand : AbstractCommand
    {
        double result;

        /// <summary>
        /// Команда вычисления расстояния между точками
        /// </summary>
        /// <param name="a">Первая точка</param>
        /// <param name="b">Вторая точка</param>
        public DistanceCommand(Point a, Point b)
        {
            result = GeometryCalcs.Distance(a, b);
        }

        /// <summary>
        /// Выполняет команду
        /// </summary>
        /// <returns>Результат выполнения команды</returns>
        public override ICommandResult Execute()
        {
            return new TypedCommandResult<double>(result);
        }
    }
}
