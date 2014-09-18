using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeometryMain.AppInterface.Commands
{
    /// <summary>
    /// Команда справки
    /// </summary>
    class HelpCommand : AbstractCommand
    {
        private const string HELP_MESSAGE = "You can use following commands: \n"
           + "* <dist x1 y1 x2 y2> \n"
           + "* <midpoint x1 y1 x2 y2> \n"
           + "* <trngl.area s1 s2 s3> or <trngl.area x1 y1 x2 y2 x3 y3> \n"
           + "* <trngl.perim s1 s2 s3> or <trngl.perim x1 y1 x2 y2 x3 y3> \n"
           + "* <trngl.is-right s1 s2 s3> or <trngl.is-right x1 y1 x2 y2 x3 y3> \n"
           + "* <trngl.is-eq s1 s2 s3> or <trngl.is-eq x1 y1 x2 y2 x3 y3> \n"
           + "* <trngl.is-isos s1 s2 s3> or <trngl.is-isos x1 y1 x2 y2 x3 y3> \n"
           + "<s1 s2 s3> define sides of triangle, <x1 y1 x2 y2 x3 y3> define coordinates of vertices; \n"
           + "';' and '$' are ignored symnols, you can use it for convenience. \n"
           + "\n"
           + "Examples: \n"
           + "dist -1,5 2 2,5 5 >>> 5 \n"
           + "trngl.area 0 0; 3 0; 0 4 >>> 6 \n";

        /// <summary>
        /// Команда справки
        /// </summary>
        public HelpCommand() { }

        /// <summary>
        /// Выполняет команду
        /// </summary>
        /// <returns>Результат выполнения команды</returns>
        public override ICommandResult Execute()
        {
            return new TypedCommandResult<string>(HELP_MESSAGE);
        }
    }
}
