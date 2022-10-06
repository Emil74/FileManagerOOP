using FileManager_OOP.CommandString;
using FileManager_OOP.Commnad;
using FileManager_OOP.Draw_Console_Window;
using FileManager_OOP.List_Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP.Proces_Enter_Command
{
    public static class Proces_EnterCommand
    {

        /// <summary>
        /// методы кнопки
        ///  
        /// </summary>
        /// <param name="WINDOW_WIDTH">Width</param>
        public static void ProcessEnterCommand(int WINDOW_WIDTH)
        {
            (int left, int top) = CursorPosition.GetCursorPosition();
            StringBuilder command = new StringBuilder();

            ConsoleKeyInfo key;
            char keyy;
            do
            {
                key = Console.ReadKey();
                keyy = key.KeyChar;

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow)
                {
                    command.Append(keyy);
                }

                (int currentLeft, int currentTop) = CursorPosition.GetCursorPosition();

                if (currentLeft == WINDOW_WIDTH - 2)
                {
                    Console.SetCursorPosition(currentLeft - 1, top);
                    Console.Write(" ");
                    Console.SetCursorPosition(currentLeft - 1, top);
                }
                if (key.Key == ConsoleKey.Backspace/*ConsoleKey.Backspace*/)
                {
                    if (command.Length > 0)
                        command.Remove(command.Length - 1, 1);

                    if (currentLeft >= left)
                    {
                        Console.SetCursorPosition(currentLeft, top);
                        Console.Write(" ");
                        Console.SetCursorPosition(currentLeft, top);
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top);
                    }
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, WINDOW_WIDTH, 3);

                    if (Command_List.listComand.Count == 0)   //если listCommand пусто тогда возвращает последный command
                    {
                        if (Properties.Settings.Default.Command != "")
                            Parse_Command_String.ParseCommandString(Properties.Settings.Default.Command);
                    }

                    Command_List.historyPointer--;    //каждый раз нажимаю UpArrow historyPointer--
                    if (Command_List.historyPointer == -1)
                    {
                        Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, WINDOW_WIDTH, 3);
                        Command_List.historyPointer = 0;
                    }

                    Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, WINDOW_WIDTH, 3);

                    if (Command_List.historyPointer > Command_List.listComand.Count)
                    {
                        Command_List.historyPointer = Command_List.listComand.Count - 1;
                    }
                    Console.Write(Command_List.listComand[Command_List.historyPointer]);
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, WINDOW_WIDTH, 3);
                    if (Command_List.listComand.Count == 0)
                    {
                        if (Properties.Settings.Default.Command != "")
                            Parse_Command_String.ParseCommandString(Properties.Settings.Default.Command);
                    }

                    Command_List.historyPointer++;
                    if (Command_List.historyPointer < Command_List.listComand.Count)
                    {
                        Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, WINDOW_WIDTH, 3);
                        Console.Write(Command_List.listComand[Command_List.historyPointer]);
                    }
                    else if (Command_List.historyPointer == Command_List.listComand.Count)
                    {
                        Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, WINDOW_WIDTH, 3);
                    }
                    else if (Command_List.historyPointer > Command_List.listComand.Count)
                    {
                        Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, WINDOW_WIDTH, 3);
                        Command_List.historyPointer = Command_List.listComand.Count;
                    }
                    else
                    {
                        Console.Write(Command_List.listComand[Command_List.historyPointer - 1]);
                        Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, WINDOW_WIDTH, 3);
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, WINDOW_WIDTH, 3);
            List_CommandList.ListCommand(command.ToString());

        }
    }
}
