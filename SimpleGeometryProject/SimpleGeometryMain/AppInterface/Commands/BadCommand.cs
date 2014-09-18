using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeometryMain.AppInterface.Commands
{
    /// <summary>
    /// Некорректная команда
    /// </summary>
    class BadCommand : AbstractCommand
    {
        /// <summary>
        /// Текст команды
        /// </summary>
        string cmdText;

        /// <summary>
        /// Некорректная команда
        /// </summary>
        public BadCommand(string cmd)
        {
            cmd = (cmd == null) ? "" : cmd;
            this.cmdText = cmd;
        }

        /// <summary>
        /// Выполняет команду
        /// </summary>
        /// <returns>Результат выполнения команды</returns>
        public override ICommandResult Execute()
        {
            return new ErrorCommandResult(string.Format(
                "Bad command '{0}'", cmdText));
        }
    }
}
