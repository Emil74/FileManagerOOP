using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP.Draw_Console_Window
{
    public static class Draw_Console
    {
        /// <summary>
        /// Отрисовать консоль
        /// </summary>
        /// <param name="dir">Текущая директория</param>
        /// <param name="x">Начальная позиция по оси X</param>
        /// <param name="y">Начальная позиция по оси Y</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        public static void DrawConsole(string dir, int x, int y, int width, int height)
        {
            Draw_Window.DrawWindow(x, y, width, height);
            Console.SetCursorPosition(x + 1, y + height / 2);
            Console.Write($"{dir}>");
        }

    }
}
