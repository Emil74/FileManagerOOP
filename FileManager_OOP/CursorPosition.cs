using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP
{
    public static class CursorPosition
    {

        /// <summary>
        /// Позиция курсора
        /// </summary>
        /// <returns></returns>
        public static (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft, Console.CursorTop);
        }

    }
}
