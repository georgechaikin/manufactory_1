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
    public partial class Form2 : Form
    {
        private XSSFWorkbook workbook;
        private XSSFSheet table_sheet;
        public Form2(string path,string table_name)
        {
            InitializeComponent(path,table_name);
            this.Load += (object sender, EventArgs e) => this.Form2_Load(path, table_name, sender, e);
        }

        private void Form2_Load(string path,string sheet_name,object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                //Какой-то код для обработки исключения
            }
            using (var file_stream=new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(file_stream);
                table_sheet = (XSSFSheet)workbook.GetSheet(sheet_name);
            }

            //int past_order_number = 3

            //Добавляем столбцы
            past_dataGridView.Columns.Add("Заказчик", "Заказчик");
            past_dataGridView.Columns.Add("Наименование", "Наименование изделия");
            past_dataGridView.Columns.Add("Кол-во", "Кол-во изделия");
            past_dataGridView.Columns.Add("Вид", "Вид материала");
            past_dataGridView.Columns.Add("Размеры", "Размеры материала");
            past_dataGridView.Columns.Add("Стоимость", "стоимость материала");
            //Считываем талибцу(нужные нам столбцы)
            int i = 5;
            
            //Записываем в цикле каждую строку
            while (table_sheet.GetRow(i) != null)
            {
                if (table_sheet.GetRow(i).GetCell(0) == null)
                    break;
           
                //Добавляем строку
                past_dataGridView.Rows.Add();

                //Записываем строку
                for (int j = 0; j < 6; j++)
                {
                    var cell = table_sheet.GetRow(i).GetCell(j);
                    if (cell != null)
                    {
                        //MessageBox.Show(table_sheet.GetRow(i).GetCell(j).ToString());
                        switch (cell.CellType)
                        {
                            case NPOI.SS.UserModel.CellType.Numeric:
                                past_dataGridView.Rows[i-5].Cells[j].Value = table_sheet.GetRow(i).GetCell(j).NumericCellValue;
                                break;
                            case NPOI.SS.UserModel.CellType.String:
                                past_dataGridView.Rows[i-5].Cells[j].Value = table_sheet.GetRow(i).GetCell(j).StringCellValue;
                                break;
                        }
                    }
                    else
                    {
                        //Потом код напишу
                    }

                }
                i++;
        }

            //Добавляем актуальные заказы

            //Добавляем столбцы
            actual_dataGridView.Columns.Add("Заказчик", "Заказчик");
            actual_dataGridView.Columns.Add("Наименование", "Наименование изделия");
            actual_dataGridView.Columns.Add("Кол-во", "Кол-во изделия");
            actual_dataGridView.Columns.Add("Вид", "Вид материала");
            actual_dataGridView.Columns.Add("Размеры", "Размеры материала");
            actual_dataGridView.Columns.Add("Стоимость", "стоимость материала");

            //Актуальные заказы(Последние три)(Можно как-нибудь и отрегулировать кол-во)
            int actual_order_number = 5;

            int size = past_dataGridView.Rows.Count;
            for (int index = 0; index < actual_order_number; index++)
            {
                //Добавляем строку
                actual_dataGridView.Rows.Add();
                for (int j = 0; j < 6; j++)
                {
                    //TODO: Попробовать потом просто присваивать значение строки,
                    //а не поэлементное присваивание
                    actual_dataGridView.Rows[index].Cells[j].Value = past_dataGridView.Rows[size-(actual_order_number-index)].Cells[j].Value;

                }
                size = past_dataGridView.Rows.Count;
                //past_dataGridView.Rows.RemoveAt(size - 1 - index);
            }
            actual_dataGridView.Rows.RemoveAt(actual_order_number-1);


        }

        private int getRowsCount()//TODO: Оптимизировать как-нибудь метод
        {
            int i = 5;//
            while (table_sheet.GetRow(i) != null)
            {
                if (table_sheet.GetRow(i).GetCell(0) != null)
                    i++;
                else return i;
            }
            return i;
        }
    }

}
