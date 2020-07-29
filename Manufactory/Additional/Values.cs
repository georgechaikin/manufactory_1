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
        /// Заголовки и соответствующие им номера в строке таблицы (числовые значения)
        /// </summary>
        public static Dictionary<string, int> numericHeadings;
        /// <summary>
        /// Заголовки и соответствующие им номера в строке таблицы (строчные значения)
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
        /// Номер строки, с которой начинается запись
        /// </summary>
        public static int startRowIndex;
        /// <summary>
        /// Текущий номер строки, с которой будет производиться запись
        /// </summary>
        public static int currentRowIndex;
        /// <summary>
        /// Excel файл, с которым производится работа
        /// </summary>
        public static IWorkbook workbook;
        /// <summary>
        /// Лист в файле, с которым производится работа
        /// </summary>
        public static ISheet tableSheet;
        /// <summary>
        /// Кол-во заказов, необходимых для отображения в таблице актуальных заказов
        /// </summary>
        public static int numberOfActualOrders;
        /// <summary>
        /// Кол-во заказов, необходимых для отображения в таблице прошлых заказов
        /// </summary>
        public static int numberOfPastOrders;

        public Values(string tablePath, string TableName)//TODO: добавить параметры данных для других полей
        {
            startRowIndex = 4;//TODO: Потом прописать автоматический поиск стартовой строки
            currentRowIndex = 4;
            path = tablePath;
            tableName = TableName;
            headings = new Dictionary<string, int>();
            numericHeadings = new Dictionary<string, int>();
            stringHeadings = new Dictionary<string, int>();
            headings = new Dictionary<string, int>();
            numberOfActualOrders = 0;
            numberOfPastOrders = 5;

            //Пока headings будет заполняться вручную
            numericHeadings["Номер заявки"] = 0;
            stringHeadings["Заказчик"] = 1;
            stringHeadings["Изделие/Тип заказа"] = 2;
            stringHeadings["Изделие/Наименование"] = 3;
            numericHeadings["Изделие/Кол-во"] = 4;
            stringHeadings["Изделие/Вид"] = 5;
            stringHeadings["Материал/Вид"] = 6;
            stringHeadings["Материал/Тип"] = 7;
            stringHeadings["Материал/Размеры"] = 8;
            numericHeadings["Материал/Стоимость"] = 9;
            numericHeadings["Под.работы/Фрезеровка/Время"] = 10;
            numericHeadings["Под.работы/Фрезеровка/Стоимость"] = 11;
            numericHeadings["Под.работы/Токарка/Время"] = 12;
            numericHeadings["Под.работы/Токарка/Стоимость"] = 13;
            numericHeadings["Под.работы/Слесарка/Время"] = 14;
            numericHeadings["Под.работы/Слесарка/Стоимость"] = 15;
            numericHeadings["Под.работы/Сварка/Время"] = 16;
            numericHeadings["Под.работы/Сварка/Стоимость"] = 17;
            numericHeadings["Фрезерование/Время"] = 18;
            numericHeadings["Фрезерование/Стоимость"] = 19;
            numericHeadings["Токарные работы/Время"] = 20;
            numericHeadings["Токарные работы/Стоимость"] = 21;
            numericHeadings["Слесарная обработка/Время"] = 22;
            numericHeadings["Слесарная обработка/Стоимость"] = 23;
            numericHeadings["Сварочная работа/Время"] = 24;
            numericHeadings["Сварочная работа/Стоимость"] = 25;
            numericHeadings["Стоимость 1 шт."] = 26;//
            numericHeadings["Итоговая стоимость"] = 27;//

            headings = numericHeadings.Union(stringHeadings).ToDictionary(s=>s.Key,s=>s.Value);
            
            //loadTable();

        }
        /// <summary>
        /// Загружает таблицу
        /// </summary>
        public static void loadTable()
        {
            #region Открываем xlsx файл
            if (!File.Exists(path))
            {
                //Выходим из приложения, если файла не существует
                //Потом можно добавить сюда что-нибудь(к примеру логи, исключения и т.п.)
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
            var startRow = tableSheet.GetRow(currentRowIndex);

            //TODO: Может быть, что row будет null, нужно тогда его создавать
            while (startRow != null)
            {
                if (startRow.GetCell(0) == null)
                    break;
                else if (startRow.GetCell(0).ToString().Equals(String.Empty))
                    break;
                //MessageBox.Show(table_row.GetCell(0).ToString() + ": " + table_row.GetCell(0).CellType);
                currentRowIndex++;
                startRow = tableSheet.GetRow(currentRowIndex);

            }
            //startRow = tableSheet.CreateRow(currentRowIndex);
            #endregion
            MessageBox.Show("Номер последней строки: " + currentRowIndex);
        }

    }
}
