using FileManager_OOP.Console_Size;
using FileManager_OOP.Draw_Console_Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP
{
    public static class File_Folder_Info
    {
        /// <summary>
        /// Копирование каталогов
        /// </summary>
        /// <param name="sourceDir">исходный каталог</param>
        /// <param name="destinationDir">каталог назначения</param>
        /// <param name="recursive">скопировать рекурсивно</param>
        public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Получить информацию об исходном каталоге
            var dir = new DirectoryInfo(sourceDir);

            // Кэшируйте каталоги, прежде чем мы начнем копирование
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Получить файлы в исходном каталоге и скопировать в целевой каталог
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                    Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                    string targetFilePath = Path.Combine(destinationDir, file.Name);
                    file.CopyTo(targetFilePath);
                }
                catch (Exception)
                {
                    Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                    Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                    Console.SetCursorPosition(1, 19);
                    Console.Write("Этот файл уже сущесвует");
                }
            }

            // Если рекурсивно и копируются подкаталоги, рекурсивно вызовите этот метод
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        /// <summary>
        /// копироват файла
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        public static void CopyFile(string sourceFile, string destinationFile)
        {
            FileInfo fileInf = new FileInfo(sourceFile);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(destinationFile, true);
            }
        }

        /// <summary>
        /// Информация файла
        /// </summary>
        /// <param name="path"></param>
        public static void InfoFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            Console.SetCursorPosition(1, 19);
            Console.WriteLine($"Имя Файла {fileInfo.Name}");
            Console.SetCursorPosition(1, 20);
            Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
            Console.SetCursorPosition(1, 21);
            Console.WriteLine($"Размер: {fileInfo.Length} КБ");
        }

        /// <summary>
        /// Информация фолдера
        /// </summary>
        /// <param name="path"></param>
        public static void InfoFolder(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            Console.SetCursorPosition(1, 19);
            Console.WriteLine($"Имя фолдера {dirInfo.Name}");
            Console.SetCursorPosition(1, 20);
            Console.WriteLine($"Время создания: {dirInfo.CreationTime}");
            Console.SetCursorPosition(1, 21);
            Console.WriteLine($"Полный имя фолдера: {dirInfo} ");
        }

        /// <summary>
        /// удалит файл
        /// </summary>
        /// <param name="file"></param>
        public static void deleteFile(string file)
        {
            File.Delete(file);
        }

        /// <summary>
        /// удалит фолдер
        /// </summary>
        /// <param name="folder"></param>
        public static void deleteFolder(string folder)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(folder);
                DirectoryInfo[] diA = di.GetDirectories();
                FileInfo[] fi = di.GetFiles();
                foreach (FileInfo f in fi)
                {
                    f.Delete();
                }

                foreach (FileInfo df in fi)
                {
                    if (df.Length == 0)
                        return;
                    deleteFolder(df.FullName);
                }

                if (di.GetDirectories().Length == 0 && di.GetFiles().Length == 0) di.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

    }
}
