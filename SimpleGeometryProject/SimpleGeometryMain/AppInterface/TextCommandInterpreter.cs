using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using SimpleGeometry;
using SimpleGeometryMain.AppInterface.Commands;

namespace SimpleGeometryMain.AppInterface
{
    /*
     Commands:
     *  dist x1 y1 xy y2
     *  midpoint x1 y1 x2 y2
     *  trngl.area s1 s2 s3
     *  trngl.area x1 y1 x2 y2 x3 y3 
     *  trngl.perim s1 s2 s3
     *  trngl.perim x1 y1 x2 y2 x3 y3 
     *  trngl.is-right s1 s2 s3
     *  trngl.is-right x1 y1 x2 y2 x3 y3 
     *  trngl.is-eq s1 s2 s3
     *  trngl.is-eq x1 y1 x2 y2 x3 y3 
       
     ';' and '$' -- ignored symbols, you can use it in command
     for convenience
     */

    /// <summary>
    /// Класс-интерпретатор текстовых команд
    /// </summary>
    class TextCommandInterpreter
    {
        /// <summary>
        /// Вид команды
        /// </summary>
        enum CommandKind { UNDEFINED, DISTANCE, 
            TRIANGLE_AREA, TRIANGLE_PERIM, 
            TRIANGLE_IS_RIGHT, TRIANGLE_IS_EQUIL }

        public const char DELIM = ' ';
        public readonly char[] IGNORED_SYMBOLS = new char[] { ';', '$' };

        private string currCmdText;

        /// <summary>
        /// Обрабатывает текстовую команду, подготавливая к анализу
        /// (удаляет пробелы и игнорируемые символы)
        /// </summary>
        /// <param name="cmdText">Исходный текст команды</param>
        /// <returns>Команду, подготовленную к анализу</returns>
        public string PrepareCommand(string cmdText)
        {
            cmdText = cmdText.ToLower();
            Func<string, char, string> removeAll = (string s, char c) => 
            {
                while (s.Contains(c))
                    s = s.Remove(s.IndexOf(c), 1);
                return s;
            };
            foreach (char ignored in IGNORED_SYMBOLS)
                cmdText = removeAll(cmdText, ignored);
            return cmdText.Trim();
        }

        public bool Parse(string cmdText, out AbstractCommand cmd)
        {
            Debug.Assert(cmdText == PrepareCommand(cmdText),
                "Parse method must be called after preparing of command");
            currCmdText = cmdText;
            if (cmdText == "quit")
            {
                cmd = new QuitCommand();
                return true;
            }
            else if (cmdText == "help")
            {
                cmd = new HelpCommand();
                return true;
            }
            // разбиваем всю команду на составляющие элементы
            string[] allParts = cmdText.Split(new char[] { DELIM }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Assert(allParts.Length > 0, "Empty command must not be here");
            // по умолчанию результат -- неизвестная команда
            cmd = new UnknownCommand(cmdText);
            // название команды
            string cmdName = allParts[0];
            CommandKind cmdType;
            // команда может быть неизвестна
            if (!_TryParseCommand(cmdName, out cmdType))
                return false;
            Debug.Assert(cmdType != CommandKind.UNDEFINED,
                "CommandKind.UNDEFINED must be cought by _TryParseCommand (it should returns false)");
            // оставшиеся кусочки команды
            string[] args = allParts.Skip(1).ToArray();
            switch (cmdType)
            {
                case CommandKind.DISTANCE:
                    return _TryParseDistance(args, out cmd);
                // остались только команды треугольника
                default:
                    return _TryParseTriangle(cmdType, args, out cmd);
            }
        }

        /// <summary>
        /// Находит тип команды, которому соответствует строка cmdTypeText,
        /// и записывает его в cmdKind.
        /// </summary>
        /// <param name="cmdTypeText">Текстовое представление команды</param>
        /// <param name="cmdKind">Тип команды</param>
        /// <returns>Истину, если удалось рапарсить команду, и ложь в противном случае</returns>
        private bool _TryParseCommand(string cmdTypeText, out CommandKind cmdKind)
        {
            Debug.Assert(cmdTypeText == cmdTypeText.Trim(), "Command must be without spaces");
            cmdKind = CommandKind.UNDEFINED;
            switch (cmdTypeText)
            {
                case "dist": 
                    cmdKind = CommandKind.DISTANCE;
                    break;
                case "trngl.area": 
                    cmdKind = CommandKind.TRIANGLE_AREA;
                    break;
                case "trngl.perim": 
                    cmdKind = CommandKind.TRIANGLE_PERIM;
                    break;
                case "trngl.is-right": 
                    cmdKind = CommandKind.TRIANGLE_IS_RIGHT;
                    break;
                case "trngl.is-eq": 
                    cmdKind = CommandKind.TRIANGLE_IS_EQUIL;
                    break;
                default:
                    return false;
            }
            return true;
        }

        private bool _TryParseDistance(string[] argsText, out AbstractCommand cmd)
        {
            // здесь может некорректный формат команды
            cmd = new BadCommand(this.currCmdText);
            if (argsText.Length != 4)
                return false;
            // на каждую точку по две координаты
            Point[] points = new Point[argsText.Length / 2];
            for (int i = 0; i < points.Length; ++i)
                if (!_TryParsePoint(argsText[2 * i], argsText[2 * i + 1], ref points[i]))
                    return false;
            cmd = new DistanceCommand(points[0], points[1]);
            return true;
        }

        private bool _TryParseTriangle(CommandKind cmdKind, string[] argsText, out AbstractCommand cmd)
        {
            // здесь может некорректный формат команды
            cmd = new BadCommand(this.currCmdText);
            // команда работы с треугольником принимает лидо длины строн (3 аргумента), 
            // либо координаты вершин (6 аргументов)
            if (argsText.Length != 3 && argsText.Length != 6) 
                return false;
            TriangleCommand trnglCmd = null;
            // создаём конкретную команду
            switch (cmdKind)
            { 
                case CommandKind.TRIANGLE_AREA:
                    trnglCmd = new TriangleAreaCommand();
                    break;
                case CommandKind.TRIANGLE_PERIM:
                    trnglCmd = new TrianglePerimCommand();
                    break;
                case CommandKind.TRIANGLE_IS_RIGHT:
                    trnglCmd = new TriangleIsRightCommand();
                    break;
                case CommandKind.TRIANGLE_IS_EQUIL:
                    trnglCmd = new TriangleIsRightCommand();
                    break;
                default:
                    Debug.Assert(false, "_TryParseTriangle must be called only for triangle commands");
                    break;
            }
            // инициализируем данными треугольника
            if (argsText.Length == 3)
            {
                double[] sides;
                if (!_TryParseTriangleSides(argsText, out sides))
                    return false;
                trnglCmd.Init(sides);
            }
            else
            {
                Debug.Assert(argsText.Length == 6, "This case only for 6 args-coordinates");
                Point[] vertices;
                if (!_TryParseTriangleVertices(argsText, out vertices))
                    return false;
                trnglCmd.Init(vertices);
            }
            cmd = trnglCmd;
            return true;
        }

        private bool _TryParsePoint(string xText, string yText, ref Point p)
        {
            double x, y;
            if (!double.TryParse(xText, out x))
                return false;
            if (!double.TryParse(yText, out y))
                return false;
            p = new Point(x, y);
            return true;
        }

        private bool _TryParseTriangleSides(string[] argsText, out double[] sides)
        {
            Debug.Assert(argsText.Length == 3, "_TryParseTriangleSides must be called for 3 args (3 sides)");
            sides = new double[argsText.Length];
            for (int i = 0; i < argsText.Length; ++i)
                if (!double.TryParse(argsText[i], out sides[i]))
                    return false;
            return true;
        }

        private bool _TryParseTriangleVertices(string[] argsText, out Point[] vertices)
        {
            Debug.Assert(argsText.Length == 6, "_TryParseTriangleVertices must be called for 6 args (3 points)");
            // на каждую точку по две координаты
            vertices = new Point[argsText.Length / 2];
            for (int i = 0; i < vertices.Length; ++i)
                if (!_TryParsePoint(argsText[2 * i], argsText[2 * i + 1], ref vertices[i]))
                    return false;
            return true;
        }
    }
}
