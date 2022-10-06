using FileManager_OOP.Console_Size;
using FileManager_OOP.Draw_Console_Window;
using FileManager_OOP.DrawGet_Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP.CommandString
{

    public static class Parse_Command_String
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
        /// Я неаписал так когда последные комманды cd или ls ... сохраняет последный комманд.можно все комманды так написат...
        /// 
        /// </summary>
        /// <param name="command">наш комманд</param>
        public static void ParseCommandString(string command)
        {
            string[] commandParams = command.ToLower().Split(' ');
            if (commandParams.Length > 0)
            {
                switch (commandParams[0])
                {
                    case "cd":
                        try
                        {
                            if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                            {
                                Directory__Info.currentDir = commandParams[1];
                                Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                                Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                Properties.Settings.Default.Command = command;
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);

                                if (!Directory.Exists("errors"))
                                {
                                    Directory.CreateDirectory("errors");
                                }
                                throw new Exception(/*commandParams[1]*/ command + "--Нет такой файл");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.SetCursorPosition(1, 19);

                            File.AppendAllText(@"errors/random_name_exception.txt", ex.Message + "\n");
                            Console.Write(ex.Message);
                        }
                        break;

                    case "ls":
                        try
                        {

                            if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                            {

                                if (commandParams.Length > 3 && commandParams[2] == "-p" && int.TryParse(commandParams[3], out int n))
                                {
                                    Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                    Draw_Tree.DrawTree(new DirectoryInfo(commandParams[1]), n);
                                    if (n != 0)
                                    {
                                        Properties.Settings.Default.Command = command;
                                        Properties.Settings.Default.Save();
                                    }
                                    else
                                    {
                                        throw new Exception(command + "--Нет такая страница");
                                    }
                                }
                                else
                                {
                                    Draw_Tree.DrawTree(new DirectoryInfo(commandParams[1]), 1);
                                    /*  Properties.Settings.Default.Command = command;
                                      Properties.Settings.Default.Save();*/
                                }
                            }
                            else
                            {
                                Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                                throw new Exception(command + "--Нет такой файл");
                            }
                        }
                        catch (Exception ex)
                        {
                            Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                            Console.SetCursorPosition(1, 19);

                            File.AppendAllText(@"errors/random_name_exception.txt", ex.Message + "\n");
                            Console.Write(command + " " + "--Нет такая страница");
                        }
                        break;

                    case "cp":
                        if (Directory.Exists(commandParams[1]))
                        {
                            try
                            {
                                if (commandParams.Length > 1 && Directory.Exists(commandParams[1]) && Directory.Exists(commandParams[2]))
                                {
                                    Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                    File_Folder_Info.CopyDirectory(commandParams[1], commandParams[2], true);
                                }
                                else
                                {
                                    // Проверьте, существует ли исходный каталог                               
                                    throw new DirectoryNotFoundException(command + "--Исходный каталог не найден");
                                }
                            }
                            catch (Exception ex)
                            {
                                Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                                Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);

                                Console.SetCursorPosition(1, 19);
                                File.AppendAllText(@"errors/random_name_exception.txt", ex.Message + "\n");
                                Console.Write(ex.Message);
                            }
                        }
                        else
                        {
                            //Copy File
                            try
                            {
                                if (commandParams.Length > 1 && File.Exists(commandParams[1]) && File.Exists(commandParams[2]))
                                {
                                    Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                    File_Folder_Info.CopyFile(commandParams[1], commandParams[2]);
                                }
                                else
                                {
                                    throw new FileNotFoundException(command + "--Исходный файл не найден");
                                }
                            }
                            catch (Exception ex)
                            {
                                Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                                Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);

                                Console.SetCursorPosition(1, 19);
                                File.AppendAllText(@"errors/random_name_exception.txt", ex.Message + "\n");
                                Console.Write(ex.Message);
                            }
                        }

                        break;

                    case "rm":
                        if (Directory.Exists(commandParams[1]))
                        {
                            //delete Folder
                            try
                            {
                                if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                                {
                                    Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                    File_Folder_Info.deleteFolder(commandParams[1]);
                                }
                                else
                                {
                                    throw new Exception(commandParams[1] + "--Нет такой фолдер");
                                }
                            }
                            catch (Exception ex)
                            {
                                Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                                Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                Console.SetCursorPosition(1, 19);

                                File.AppendAllText(@"errors/random_name_exception.txt", ex.Message + "\n");
                                Console.Write(ex.Message);
                            }
                        }

                        //delete File
                        else
                        {
                            try
                            {
                                if (commandParams.Length > 1 && File.Exists(commandParams[1]))
                                {
                                    Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                    File_Folder_Info.deleteFile(commandParams[1]);
                                }
                                else
                                {
                                    throw new Exception(commandParams[1] + "--Нет такой файл");
                                }
                            }
                            catch (Exception ex)
                            {
                                Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                                Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                Console.SetCursorPosition(1, 19);
                                File.AppendAllText(@"errors/random_name_exception.txt", ex.Message + "\n");
                                Console.Write(ex.Message);
                            }
                        }

                        break;

                    case "file":
                        //Info Folder
                        if (Directory.Exists(commandParams[1]))
                        {
                            try
                            {
                                if (commandParams.Length > 1)
                                {
                                    Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                                    Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                    File_Folder_Info.InfoFolder(commandParams[1]);
                                }
                                else
                                {
                                    throw new Exception(command + "--Нет файл");
                                }
                            }
                            catch (Exception ex)
                            {
                                Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                                Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                Console.SetCursorPosition(1, 19);

                                File.AppendAllText(@"errors/random_name_exception.txt", ex.Message + "\n");
                                Console.Write(ex.Message);
                            }
                        }
                        //Info File
                        else
                        {
                            try
                            {
                                if (commandParams.Length > 1)
                                {
                                    Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                    Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);

                                    File_Folder_Info.InfoFile(commandParams[1]);
                                }
                                else
                                {
                                    throw new Exception(command + "--Нет файл");
                                }
                            }
                            catch (Exception ex)
                            {
                                Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                                Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);
                                Console.SetCursorPosition(1, 19);
                                File.AppendAllText(@"errors/random_name_exception.txt", ex.Message + "\n");
                                Console.Write(ex.Message);
                            }
                        }

                        break;

                    case "exit":
                        Environment.Exit(1);
                        break;

                    default:
                        Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
                        Draw_Window.DrawWindow(0, 18, Size.WINDOW_WIDTH, 8);

                        Console.SetCursorPosition(1, 19);
                        if (command == "")
                            Console.Write("Введите команд");

                        else
                            Console.Write(command + "--Нет такая команда");
                        break;
                }
            }
            Update_Console.Console_Update.UpdateConsole();
        }

    }
}
