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
        /// Здесь происходит запуск основной формы. Также здесь создаётся экземпляр класса Values.
        /// в котором хранятся выжные переменные (вроде пути до файла и название листа, с которым производится работа)
        /// В Values так же задаются заголовки таблицы и их порядок (Зачем это нужно: см. в классе Values).
        /// Чтобы правильно считывать с TextBox'ов данные, им заданы AccessibleName, которые соответствуют
        /// названию определённого заголовка в Values.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm("Таблица заказов.xlsx", "Входящие"));

            //Кол-во столбцов и их названия пока регулируются в конструкторе Values
            Values values = new Values("Таблица заказов.xlsx", "Входящие");
            Application.Run(new NewAdd());
        }
    }
}
