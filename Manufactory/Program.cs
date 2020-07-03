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
            Application.Run(new NewAdd());
        }
    }
}
