using FileManager_OOP.CommandString;
using FileManager_OOP.Console_Size;
using FileManager_OOP.Draw_Console_Window;
using FileManager_OOP.List_Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP.Commnad
{
    public class List_CommandList
    {
        /// <summary>
        /// добавить комманд List<string>
        /// </summary>
        /// <param name="command">command каторый мы написали</param>
        public static void ListCommand(string command)
        {
            command = command.Trim();
            if (string.IsNullOrWhiteSpace(command))
            {
                Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, Size.WINDOW_WIDTH, 3);

            }

            if (command == "") //например я добавил 3 комманд и нажимаю UpArrow и потом Enter она возвращает command=""
                               //он принимает вес комманд как текуший директоря
            {
                if (Command_List.historyPointer != Command_List.listComand.Count)
                {
                    Parse_Command_String.ParseCommandString(Command_List.listComand[Command_List.historyPointer]);
                }
                else if (Command_List.historyPointer == Command_List.listComand.Count)
                {
                    Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, Size.WINDOW_WIDTH, 3);
                }
            }

            if (command == "\0")  //например я добавил 3 комманд и нажимаю DownArrow и потом Enter  возвращает command="\0"
                                  //он принимаеть все комманду как директория
            {
                Parse_Command_String.ParseCommandString(Command_List.listComand[Command_List.historyPointer]);
            }

            if (!Command_List.listComand.Contains(command))
            {
                Command_List.listComand.Add(command);
                Command_List.historyPointer = Command_List.listComand.Count;
            }
            else
            {
                Command_List.historyPointer = Command_List.listComand.Count;
                for (int i = 0; i < Command_List.listComand.Count; i++)
                {
                    if (Command_List.listComand[i] == command)
                    {
                        Parse_Command_String.ParseCommandString(Command_List.listComand[i]);
                    }
                }
            }

            Parse_Command_String.ParseCommandString(Command_List.listComand[Command_List.historyPointer - 1]);
        }

    }
}
