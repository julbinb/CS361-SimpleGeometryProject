using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using SimpleGeometryMain.AppInterface;

namespace SimpleGeometryMain
{
    class Program
    {
        private const string CONSOLE_INPUT = "user$ ";

        /// <summary>
        /// Объект интерпретатора команд
        /// </summary>
        private static TextCommandInterpreter interpreter = new TextCommandInterpreter();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Simple Geometry Project with console command interface!");
            Console.WriteLine("Print 'quit' to exit.");
            Console.WriteLine();

            while (true)
            {
                Console.Write(CONSOLE_INPUT);
                string cmdText = interpreter.PrepareCommand(Console.ReadLine());
                // пустой ввод
                if (cmdText == "")
                    continue;
                AbstractCommand cmd;
                try
                {
                    interpreter.Parse(cmdText, out cmd);
                }
                catch (Exception e)
                {
                    Console.WriteLine("### Internal parse-command error! ###");
                    Console.WriteLine(e.Message);
                    continue;
                }
                if (cmd.IsQuit)
                    break;
                try
                {
                    var result = cmd.Execute();
                    Console.WriteLine(result.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("### Internal exec-command error! ###");
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            Console.WriteLine("Have a good day!");
        }
    }
}
