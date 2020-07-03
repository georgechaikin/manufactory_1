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
    public partial class AddOrderForm : Form
    { 
        private XSSFWorkbook workbook;
        private XSSFSheet tableSheet;
        private string workbookPath;
        private MainForm mainForm;
        //Здесь можно передавать DataGridView через другое приложение
        public AddOrderForm(MainForm mainForm)
        {
            //string path = "Таблица заказов.xlsx";
            InitializeComponent();
            addOrder_button.Click+= new System.EventHandler(this.add_data);
            this.Load+=(object sender,EventArgs e)=>this.load_Table(mainForm.workbookPath,mainForm.sheetName, sender, e);
            this.mainForm = mainForm;
            this.FormClosed += new FormClosedEventHandler(this.enableMainForm);
            this.workbookPath = mainForm.workbookPath;
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
                tableSheet = (XSSFSheet)workbook.GetSheet(sheet_name);
                //file_stream.Close();

            }
            if (tableSheet == null)
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
            var table_row = tableSheet.GetRow(i);

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
                table_row = tableSheet.GetRow(i);
                
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
                using (var fileStream=new FileStream(workbookPath,FileMode.Create,FileAccess.Write))
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

        private bool setRow(int rownum, Dictionary<string,string> orderParametres)
        {
            bool success = true;
            int product_amount;
            double product_cost;
            try
            {
                //TODO: Ловить также случаи, когда стоимость переполнена(цена*количество)

                product_amount = Convert.ToInt32(orderParametres["product amount"]);
                //TODO: Разобраться с форматом ввода "," и "."
                product_cost = Convert.ToDouble(orderParametres["product cost"]);
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
            //TODO: Стоит добавить setCellValue() ячейкам
            tableSheet.GetRow(rownum).CreateCell(0).SetCellValue(orderParametres["client"]);
            tableSheet.GetRow(rownum).CreateCell(1).SetCellValue(orderParametres["product name"]);
            tableSheet.GetRow(rownum).CreateCell(2).SetCellValue(product_amount);
            tableSheet.GetRow(rownum).CreateCell(3).SetCellValue(orderParametres["product type"]);
            tableSheet.GetRow(rownum).CreateCell(4).SetCellValue(orderParametres["product size"]);
            tableSheet.GetRow(rownum).CreateCell(5).SetCellValue(product_cost);


            tableSheet.GetRow(rownum).GetCell(0).CellStyle.IsLocked = false;
            tableSheet.GetRow(rownum).GetCell(1).CellStyle.IsLocked = false;
            tableSheet.GetRow(rownum).GetCell(2).CellStyle.IsLocked = false;
            tableSheet.GetRow(rownum).GetCell(3).CellStyle.IsLocked = false;
            tableSheet.GetRow(rownum).GetCell(4).CellStyle.IsLocked = false;
            tableSheet.GetRow(rownum).GetCell(5).CellStyle.IsLocked = false;

            this.mainForm.addRowToActualDataGridView(orderParametres);


            return success;

        }
        /// <summary>
        /// Применяется при нажатии на крестик
        /// </summary>
        private void enableMainForm(object sender,FormClosedEventArgs e)
        {
            this.mainForm.Enabled = true;
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

        private void addOrder_button_Click(object sender, EventArgs e)
        {

        }
    }
}
