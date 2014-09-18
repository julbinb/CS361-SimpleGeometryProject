using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeometryMain.AppInterface.Commands
{
    /// <summary>
    /// Неизвестная команда (не поддерживаемая приложением)
    /// </summary>
    class UnknownCommand : AbstractCommand
    {
        string cmd;

        public UnknownCommand(string cmd)
        {
            cmd = (cmd == null) ? "" : cmd;
            this.cmd = cmd;
        }

        /// <summary>
        /// Выполняет команду
        /// </summary>
        /// <returns>Результат выполнения команды</returns>
        public override ICommandResult Execute()
        {
            return new ErrorCommandResult(string.Format(
                "Unknown command '{0}'", cmd));
        }
    }
}
