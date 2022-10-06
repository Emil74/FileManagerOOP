using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP.PageNumber
{
    public static class Number_Page
    {
        /// <summary>
        /// нумбер страница
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="page"></param>
        /// <param name="pageLines"></param>
        public static void NumberPage(string[] lines, int page, int pageLines)
        {
            int line = lines.Length - 1;

            int c = line / 16;
            int b = line % 16;
            if (page <= c)
            {
                Properties.Settings.Default.numberElement = pageLines;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.numberElement = b;
                Properties.Settings.Default.Save();
            }
        }
    }
}
