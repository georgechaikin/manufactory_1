using Manufactory.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufactory
{
    static class Program
    {
        static Dictionary<string, int> headings;
        /// <summary>
        /// Ставит в соответствие заголовки и номер строки
        /// </summary>
        static void setHeadings()
        {

        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm("Таблица заказов.xlsx", "Входящие"));
            Values values = new Values("Таблица заказов.xlsx", "Входящие");
            Application.Run(new NewAdd("Таблица заказов.xlsx", "Входящие",headings));
        }
    }
}
