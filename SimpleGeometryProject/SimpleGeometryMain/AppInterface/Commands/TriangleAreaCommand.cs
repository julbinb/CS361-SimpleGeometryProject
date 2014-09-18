using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleGeometry;

using System.Diagnostics;

namespace SimpleGeometryMain.AppInterface.Commands
{
    /// <summary>
    /// Команда вычисления площади треугольника
    /// </summary>
    class TriangleAreaCommand : TriangleCommand
    {
        /// <summary>
        /// Конкретные вычисления для треугольника
        /// </summary>
        /// <returns>Результат выполнения команды</returns>
        protected override ICommandResult ExecTriangleCalc()
        {
            return new TypedCommandResult<double>(t.GetArea());
        }
    }
}
