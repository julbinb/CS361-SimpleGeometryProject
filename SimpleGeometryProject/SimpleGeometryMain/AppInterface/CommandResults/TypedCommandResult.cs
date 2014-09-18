using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace SimpleGeometryMain.AppInterface
{
    /// <summary>
    /// Результат выполнения команды -- некоторое значение
    /// </summary>
    class TypedCommandResult<T> : ICommandResult
    {
        /// <summary>
        /// Логическое значение результата
        /// </summary>
        private T val;

        /// <summary>
        /// Результат выполнения команды -- некоторое значение
        /// </summary>
        /// <param name="val">Значение результата</param>
        public TypedCommandResult(T val)
        {
            this.val = val;
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }
}
