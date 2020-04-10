using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // File.Exists()

using NPOI.XSSF.UserModel; // XSSFWorkbook, XSSFSheet

namespace Manufactory
{
    public partial class MainForm : Form
    {
        private XSSFWorkbook workbook;
        private XSSFSheet tableSheet;
        private int actualDataGridViewSize;
        private int pastDataGridViewSize;
        public string workbookPath 
        {
            get;
        }
        public string sheetName
        {
            get;
        }

        public MainForm(string path,string tableName)
        {
            InitializeComponent();
            actualDataGridViewSize = 0;
            pastDataGridViewSize = 0;
            this.Load += (object sender, EventArgs e) => this.LoadTable(path, tableName, sender, e);
            addOrder_button.Click += (object sender, EventArgs e) =>this.openAddOrderForm(path,tableName,sender,e);
            this.workbookPath = path;
            this.sheetName = tableName;
        }

        //Загружает форму
        private void LoadTable(string path,string tableName,object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                //код для обработки исключения
            }

            //Открываем workbook
            using (var file_stream=new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(file_stream);
                tableSheet = (XSSFSheet)workbook.GetSheet(tableName);
            }


            //Добавляем столбцы
            pastDataGridView.Columns.Add("Заказчик", "Заказчик");
            pastDataGridView.Columns.Add("Наименование", "Наименование изделия");
            pastDataGridView.Columns.Add("Кол-во", "Кол-во изделия");
            pastDataGridView.Columns.Add("Вид", "Вид материала");
            pastDataGridView.Columns.Add("Размеры", "Размеры материала");
            pastDataGridView.Columns.Add("Стоимость", "стоимость материала");
            
            //Считываем талибцу(нужные нам столбцы)
            int i = 5;
            //Записываем в цикле каждую строку
            while (tableSheet.GetRow(i) != null)
            {
                if (tableSheet.GetRow(i).GetCell(0) == null)
                    break;

                //Добавляем строку
                pastDataGridView.Rows.Add();
                //Записываем данные в строку(см. сверху названия столбцов, их всего 6 штук)
                for (int j = 0; j < 6; j++)
                {
                    var cell = tableSheet.GetRow(i).GetCell(j);
                    if (cell != null)
                    {
                        //Заполняем ячейку в зависимости от типа данных
                        //Можно потом добавить не только считывание строчек и цифр, а также формул(возможно и ссылок, надо потом попробовать)
                        switch (cell.CellType)
                        {
                            case NPOI.SS.UserModel.CellType.Numeric:
                                pastDataGridView.Rows[i-5].Cells[j].Value = tableSheet.GetRow(i).GetCell(j).NumericCellValue;
                                break;
                            case NPOI.SS.UserModel.CellType.String:
                                pastDataGridView.Rows[i-5].Cells[j].Value = tableSheet.GetRow(i).GetCell(j).StringCellValue;
                                break;
                        }
                    }
                    else
                    {
                        //Код для обработки исключения
                    }

                }
                i++;
        }

            pastDataGridViewSize = i - 5;

            //Добавляем актуальные заказы

            //Добавляем столбцы
            //TODO: Добавить возможность заполнять произвольное кол-во столбцов
            actualDataGridView.Columns.Add("Заказчик", "Заказчик");
            actualDataGridView.Columns.Add("Наименование", "Наименование изделия");
            actualDataGridView.Columns.Add("Кол-во", "Кол-во изделия");
            actualDataGridView.Columns.Add("Вид", "Вид материала");
            actualDataGridView.Columns.Add("Размеры", "Размеры материала");
            actualDataGridView.Columns.Add("Стоимость", "Стоимость материала");

            //Актуальные заказы(Последние три)(Можно как-нибудь и отрегулировать кол-во)
            int actual_order_number = 5;

            int size = pastDataGridView.Rows.Count;
            for (int index = 0; index < actual_order_number; index++)
            {
                //Добавляем строку
                actualDataGridView.Rows.Add();
                for (int j = 0; j < 6; j++)
                {
                    //TODO: Попробовать потом просто присваивать значение строки,
                    //а не поэлементное присваивание
                    actualDataGridView.Rows[index].Cells[j].Value = pastDataGridView.Rows[size-(actual_order_number-index)].Cells[j].Value;

                }
                size = pastDataGridView.Rows.Count;
                
            }
            //в past_orderGridView в конце есть пустая строка
            //TODO: Разобраться с пустыми строками в конце обоих dataGridView
            actualDataGridView.Rows.RemoveAt(actual_order_number-1);


        }
        //Обновляет таблицу
        public void addRowToActualDataGridView(Dictionary<string,string> orderParametres)
        {
            int lastIndex = actualDataGridView.Rows.Count - 1;
            actualDataGridView.Rows.Add();
            int product_amount = Convert.ToInt32(orderParametres["product amount"]);
            //TODO: Разобраться с форматом ввода "," и "."
           double product_cost = Convert.ToDouble(orderParametres["product cost"]);
            
            actualDataGridView.Rows[lastIndex].Cells[0].Value = orderParametres["client"];
            actualDataGridView.Rows[lastIndex].Cells[1].Value = orderParametres["product name"];
            actualDataGridView.Rows[lastIndex].Cells[2].Value = product_amount;
            actualDataGridView.Rows[lastIndex].Cells[3].Value = orderParametres["product type"];
            actualDataGridView.Rows[lastIndex].Cells[4].Value = orderParametres["product size"];
            actualDataGridView.Rows[lastIndex].Cells[5].Value = product_cost;

            /*
             * orderParametres["client"]);
             * orderParametres["product name"]);
             * product_amount);
             * orderParametres["product type"]);
             * orderParametres["product size"]);
             * product_cost);
             * 
             */
        }

        private void openAddOrderForm(string path,string table_name, object sender, EventArgs e)
        {
            AddOrderForm form1 = new AddOrderForm(this);
            this.Enabled = false;
            form1.Show();
        }
    }

}
