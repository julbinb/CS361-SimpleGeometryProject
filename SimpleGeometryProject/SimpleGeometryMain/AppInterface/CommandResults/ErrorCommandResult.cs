using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace SimpleGeometryMain.AppInterface
{
    /// <summary>
    /// Результат выполнения команды -- ошибка
    /// </summary>
    class ErrorCommandResult : ICommandResult
    {
        /// <summary>
        /// Текст ошибки
        /// </summary>
        private string message;

        /// <summary>
        /// Результат выполнения команды -- ошибка
        /// </summary>
        /// <param name="msg">Текст ошибки</param>
        public ErrorCommandResult(string msg)
        {
            Debug.Assert(msg != null && msg != "", "Error message can't be empty");
            this.message = msg;
        }

        public override string ToString()
        {
            return "ERROR! " + message;
        }
    }
}
