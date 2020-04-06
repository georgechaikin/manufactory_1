using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using NPOI.XSSF.UserModel; //XSSFWorkbook, XSSFSheet для xlsx файлов

namespace Manufactory
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.DataGridView data_grid;
        private XSSFWorkbook workbook;
        private XSSFSheet table_sheet;
        private string table_path;
        //Здесь можно передавать DataGridView через другое приложение
        public Form1(string table_path, string sheet_name)
        {
            //string path = "Таблица заказов.xlsx";
            InitializeComponent();
            addOrder_button.Click+= new System.EventHandler(this.add_data);
            this.Load+=(object sender,EventArgs e)=>this.load_Table(table_path,sheet_name, sender, e);
            this.table_path = table_path;
        }

        private void load_Table(string table_path,string sheet_name,object sender, EventArgs e)
        {
            if (!File.Exists(table_path))
            {
                //Какой-то код
                //Пока можно не писать
                MessageBox.Show("Не указан путь");
                return;
            }

            using (var file_stream=new FileStream(table_path, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(file_stream);
                table_sheet = (XSSFSheet)workbook.GetSheet(sheet_name);
                //file_stream.Close();

            }
            if (table_sheet == null)
            {
                MessageBox.Show("table is null");
            }
        }
        private void add_data(object sender, EventArgs e)
        {
            addOrder_button.Enabled = false;
            StringBuilder stringBuilder = new StringBuilder();

            #region Проверка на заполненность полей
            foreach (Control textBox in this.Controls)
            {
                if(textBox is TextBox)
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
                addOrder_button.Enabled = true;
                return;
            }
            #endregion

            //Тут будет основной говнокод)))
            //...
            int i = 5;
            var table_row = table_sheet.GetRow(i);

            //Ищет незаполненную строку
            //TODO: Может быть, что row будет null, нужно тогда его создавать
            while (table_row!=null)
            {
                if (table_row.GetCell(0) == null)
                    break;
                else if (table_row.GetCell(0).ToString().Equals(String.Empty))
                    break;
                //MessageBox.Show(table_row.GetCell(0).ToString() + ": " + table_row.GetCell(0).CellType);
                i++;
                table_row = table_sheet.GetRow(i);
                
            }

            

            //Информация о заказе
            //TODO: Сделать более адекватный способ заполнения клетки
            Dictionary<string, string> order_paramentres = new Dictionary<string, string>();
            order_paramentres.Add("client", client_textBox.Text);
            order_paramentres.Add("product name", productName_textBox.Text);
            order_paramentres.Add("product amount", productAmount_textBox.Text);
            order_paramentres.Add("product type", productType_textBox.Text);
            order_paramentres.Add("product size", productSize_textBox.Text);
            order_paramentres.Add("product cost", productCost_textBox.Text);

            //Добавление заказа
            bool success = setRow(i, order_paramentres);
            //Сохранение
            if(success==true)
                //TODO: Если поставить FileMode.Open, файл не отрывается
                using (var fileStream=new FileStream(table_path,FileMode.Create,FileAccess.Write))
            {

                    workbook.Write(fileStream);
                    MessageBox.Show("Заказ добавлен");
                //fileStream.Close();
            }
            else
            {
                addOrder_button.Enabled = true;
                return;
            }

            addOrder_button.Enabled = true;
        }

        private bool setRow(int rownum, Dictionary<string,string> order_parametres)
        {
            bool success = true;
            int product_amount;
            double product_cost;
            try
            {
                product_amount = Convert.ToInt32(order_parametres["product amount"]);
                //TODO: Разобраться с форматом ввода "," и "."
                product_cost = Convert.ToDouble(order_parametres["product cost"]);
            }
            catch(System.FormatException e)
            {
                MessageBox.Show("Проверьте формат числовых данных");
                return !success;
            }
            catch(System.OverflowException e)
            {
                MessageBox.Show("Вы ввели слишком большое число в одно из полей");
                return !success;
            }

            //table_sheet.GetRow(rownum).RowStyle = table_sheet.GetRow(rownum - 1).RowStyle;
            table_sheet.GetRow(rownum).CreateCell(0).SetCellValue(order_parametres["client"]);
            table_sheet.GetRow(rownum).CreateCell(1).SetCellValue(order_parametres["product name"]);
            table_sheet.GetRow(rownum).CreateCell(2).SetCellValue(product_amount);
            table_sheet.GetRow(rownum).CreateCell(3).SetCellValue(order_parametres["product type"]);
            table_sheet.GetRow(rownum).CreateCell(4).SetCellValue(order_parametres["product size"]);
            table_sheet.GetRow(rownum).CreateCell(5).SetCellValue(product_cost);
            //table_sheet.GetRow(rownum).GetCell(0).CellStyle.IsLocked=false;



            return success;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
