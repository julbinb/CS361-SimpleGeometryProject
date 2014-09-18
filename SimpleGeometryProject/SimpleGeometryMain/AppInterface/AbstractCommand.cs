using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeometryMain.AppInterface
{
    /// <summary>
    /// Абстрактный класс команды, которую выполняет приложение
    /// </summary>
    abstract class AbstractCommand
    {
        protected AbstractCommand() { }

        /// <summary>
        /// Является ли данная команда командой завершения
        /// </summary>
        public virtual bool IsQuit
        {
            get { return false; }
        }

        /// <summary>
        /// Выполняет команду
        /// </summary>
        /// <returns>Результат выполнения команды</returns>
        public abstract ICommandResult Execute();
    }
}
