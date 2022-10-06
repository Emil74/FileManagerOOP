using FileManager_OOP.Console_Size;
using FileManager_OOP.Draw_Console_Window;
using FileManager_OOP.PageNumber;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileManager_OOP.DrawGet_Tree
{
    public static class Draw_Tree
    {

        /// <summary>
        /// Отрисовать делево каталогов
        /// </summary>
        /// <param name="dir">Директория</param>
        /// <param name="page">Страница</param>
        public static void DrawTree(DirectoryInfo dir, int page)
        {

            StringBuilder tree = new StringBuilder();
            Get_Tree.GetTree(tree, dir, "", true);
            Draw_Window.DrawWindow(0, 0, Size.WINDOW_WIDTH, 18);
            (int currentLeft, int currentTop) = CursorPosition.GetCursorPosition();
            int pageLines = 16;


            string[] lines = tree.ToString().Split(new char[] { '\n' });

            int pageTotal = (lines.Length + pageLines - 1) / pageLines;
            try
            {
                if (page > pageTotal || page == 0)
                {
                    Console.SetCursorPosition(1, 19);
                    throw new Exception(" Нет такая страница");
                }

                else
                {
                    //footer
                    Number_Page.NumberPage(lines, page, pageLines);
                    string footer = $"╡ {page} of {pageTotal} elements {Properties.Settings.Default.numberElement} ╞";
                    Console.SetCursorPosition(Size.WINDOW_WIDTH / 2 - footer.Length / 2, 17);
                    Console.WriteLine(footer);
                }
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(1, 19);
                Console.Write(ex.Message);
            }

            for (int i = (page - 1) * pageLines, counter = 0; i < page * pageLines; i++, counter++)
            {
                if (lines.Length - 1 > i)
                {
                    Console.SetCursorPosition(currentLeft + 1, currentTop + 1 + counter);

                    Console.WriteLine(lines[i]);
                }
            }
        }
    }
}
