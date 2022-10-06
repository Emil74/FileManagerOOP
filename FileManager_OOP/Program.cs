using FileManager_OOP.CommandString;
using FileManager_OOP.Console_Size;
using FileManager_OOP.Draw_Console_Window;
using FileManager_OOP.List_Command;
using FileManager_OOP.Update_Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /// <summary>
            /// cd C:\Source --Директория
            /*Вывод дерева файловой системы с условием “пейджинга”          
               ls C:\Source -p 2
               Копирование каталога
               cp C:\Source D:\Target
               Копирование файла
               cp C:\Source\source.txt D:\Target\target.txt
               Удаление каталога рекурсивно
               rm C:\Source
               Удаление файла
               rm C:\Source\source.txt
               Вывод информации
               file C:\Source\source.txt
            */

            File.Delete(Directory__Info.currentDir + @"\errors\random_name_exception.txt");//удалит этот файл когда начинает программа 

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "FileManager";
            Console.SetWindowSize(Size.WINDOW_WIDTH, Size.WINDOW_HEIGHT);
            Console.SetBufferSize(Size.WINDOW_WIDTH, Size.WINDOW_HEIGHT);
            Console.Title = Directory__Info.currentDir;

            Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
            Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
            if (Properties.Settings.Default.Command != "")
                Parse_Command_String.ParseCommandString(Properties.Settings.Default.Command);
            Console_Update.UpdateConsole();

            Console.ReadKey(true);
        }
    }
}
