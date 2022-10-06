using FileManager_OOP.Console_Size;
using FileManager_OOP.Draw_Console_Window;
using FileManager_OOP.Proces_Enter_Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP.Update_Console
{
    public static class Console_Update
    {

        /// <summary>
        /// обновляеть консола
        /// </summary>
        public static void UpdateConsole()
        {
            Draw_Console.DrawConsole(Directory__Info.currentDir, 0, 26, Size.WINDOW_WIDTH, 3);
            Proces_EnterCommand.ProcessEnterCommand(Size.WINDOW_WIDTH);
        }
    }
}
