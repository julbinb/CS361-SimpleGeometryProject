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
    /// Команда вычисления периметра треугольника
    /// </summary>
    class TrianglePerimCommand : TriangleCommand
    {
        /// <summary>
        /// Конкретные вычисления для треугольника
        /// </summary>
        /// <returns>Результат выполнения команды</returns>
        protected override ICommandResult ExecTriangleCalc()
        {
            return new TypedCommandResult<double>(t.GetPerimeter());
        }
    }
}
