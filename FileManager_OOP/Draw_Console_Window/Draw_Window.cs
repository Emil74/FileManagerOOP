using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP.Draw_Console_Window
{
    public static class Draw_Window
    {

        /// <summary>
        /// Отрисовать окно
        /// </summary>
        /// <param name="x">Начальная позиция по оси X</param>
        /// <param name="y">Начальная позиция по оси Y</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        public static void DrawWindow(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            // header - шапка
            Console.Write("╔");
            for (int i = 0; i < width - 2; i++) // 2 - уголки
                Console.Write("═");
            Console.Write("╗");

            Console.SetCursorPosition(x, y + 1);
            for (int i = 0; i < height - 2; i++)
            {
                Console.Write("║");
                for (int j = x + 1; j < x + width - 1; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("║");
            }

            // footer - подвал
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++) // 2 - уголки
                Console.Write("═");
            Console.Write("╝");
            Console.SetCursorPosition(x, y);
        }
    }
}
