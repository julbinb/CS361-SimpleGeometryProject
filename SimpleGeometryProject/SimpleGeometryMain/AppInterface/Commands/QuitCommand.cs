using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace SimpleGeometryMain.AppInterface.Commands
{
    /// <summary>
    /// Команда завершения приложения
    /// </summary>
    class QuitCommand :  AbstractCommand
    {
        /// <summary>
        /// Является ли данная команда командой завершения
        /// </summary>
        public override bool IsQuit
        {
            get { return true; }
        }

        /// <summary>
        /// Выполнение этой команды недопустимо
        /// </summary>
        /// <returns>Результат выполнения команды</returns>
        public override ICommandResult Execute()
        {
            Debug.Assert(false, "Quit command must be processed outside");
            throw new InvalidOperationException("Quit command must be processed outside");
        }
    }
}
