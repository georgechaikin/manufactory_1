using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufactory.Additional
{
    class Values//TODO: разобраться с get и set для полей класса
    {
        /// <summary>
        /// Заголовки и соответствующие им номера в строке таблицы
        /// </summary>
        public static Dictionary<string, int> headings; //TODO: Сделать автоматическое заполнение
        /// <summary>
        /// Заголовки и соответствующие им номера в строке таблицы
        /// </summary>
        public static Dictionary<string, int> numericHeadings;
        /// <summary>
        /// Заголовки и соответствующие им номера в строке таблицы
        /// </summary>
        public static Dictionary<string, int> stringHeadings;

        /// <summary>
        /// Путь до файла
        /// </summary>
        public static string path;
        /// <summary>
        /// Название листа в excel файле
        /// </summary>
        public static string tableName;
        /// <summary>
        /// Номер строки, с которой начинается запись(изначально это номер строки после всех заголовков)
        /// </summary>
        public static int startrow;

        public static IWorkbook workbook;
        public static ISheet tableSheet;

        public Values(string tablePath, string TableNAme)
        {
            startrow = 5;//TODO: Потом прописать автоматический поиск стартовой строки
            path = tablePath;
            tableName = TableNAme;
            headings = new Dictionary<string, int>();
            numericHeadings = new Dictionary<string, int>();
            stringHeadings = new Dictionary<string, int>();

            //Пока headings будет заполняться вручную
            stringHeadings["Заказчик"] = 0;
            stringHeadings["Изделие/Наименование"] = 1;
            numericHeadings["Изделие/Кол-во"] = 2;
            stringHeadings["Материал/Вид"] = 3;
            stringHeadings["Материал/Размеры"] = 4;
            numericHeadings["Материал/Стоимость"] = 5;
            numericHeadings["Под.работы/Фрезеровка/Время"] = 6;
            numericHeadings["Под.работы/Фрезеровка/Стоимость"] = 7;
            numericHeadings["Под.работы/Товарка/Время"] = 8;
            numericHeadings["Под.работы/Товарка/Стоимость"] = 9;
            numericHeadings["Под.работы/Слесарка/Время"] = 10;
            numericHeadings["Под.работы/Слесарка/Стоимость"] = 11;
            numericHeadings["Под.работы/Сварка/Время"] = 12;
            numericHeadings["Под.работы/Сварка/Стоимость"] = 13;
            numericHeadings["Фрезерование/Время"] = 14;
            numericHeadings["Фрезерование/Стоимость"] = 15;
            numericHeadings["Токарные работы/Время"] = 16;
            numericHeadings["Токарные работы/Стоимость"] = 17;
            numericHeadings["Слесарная обработка/Время"] = 18;
            numericHeadings["Слесарная обработка/Стоимость"] = 19;
            numericHeadings["Сварочная работа/Время"] = 20;
            numericHeadings["Сварочная работа/Стоимость"] = 21;

            
            loadTable();

        }

        private static void loadTable()
        {
            #region Открываем xlsx файл
            if (!File.Exists(path))
            {
                //Какой-то код
                //Пока можно не писать
                MessageBox.Show("Не указан путь");
                Application.Exit();
                return;
            }

            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fileStream);
                tableSheet = (XSSFSheet)workbook.GetSheet(tableName);

            }
            if (tableSheet == null)
            {
                MessageBox.Show("table is null");
            }
            #endregion
            #region Ищем номер строки (startrow), с которого будем начинать заполнение
            var startRow = tableSheet.GetRow(startrow);

            //TODO: Может быть, что row будет null, нужно тогда его создавать
            while (startRow != null)
            {
                if (startRow.GetCell(0) == null)
                    break;
                else if (startRow.GetCell(0).ToString().Equals(String.Empty))
                    break;
                //MessageBox.Show(table_row.GetCell(0).ToString() + ": " + table_row.GetCell(0).CellType);
                startrow++;
                startRow = tableSheet.GetRow(startrow);

            }
            #endregion
            MessageBox.Show("Номер последней строки: " + startrow);
        }


        /*
        private void add_data(object sender, EventArgs e)
        {
            //addOrder_button.Enabled = false;
            StringBuilder stringBuilder = new StringBuilder();

            #region Проверка на заполненность полей
            foreach (Control textBox in this.Controls)
            {
                if (textBox is TextBox)
                    if (((TextBox)textBox).Text == null || ((TextBox)textBox).Text.Equals(String.Empty))
                    {
                        stringBuilder.Append("\n");
                        stringBuilder.Append(textBox.Name);
                    }
            }
            //TODO: Не забыть поменять Name у textbox'ов
            if (stringBuilder.Length != 0)
            {
                MessageBox.Show("Следующие поля пусты:" + stringBuilder.ToString());
                //addOrder_button.Enabled = true;
                return;
            }
            #endregion

            //Тут будет основной говнокод)))
            //...
            int i = 5;
            var table_row = tableSheet.GetRow(i);

            //Ищет незаполненную строку
            //TODO: Может быть, что row будет null, нужно тогда его создавать
            while (table_row != null)
            {
                if (table_row.GetCell(0) == null)
                    break;
                else if (table_row.GetCell(0).ToString().Equals(String.Empty))
                    break;
                //MessageBox.Show(table_row.GetCell(0).ToString() + ": " + table_row.GetCell(0).CellType);
                i++;
                table_row = tableSheet.GetRow(i);

            }

        }
        */
    }
}
