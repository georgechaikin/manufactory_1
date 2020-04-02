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
        
        //Здесь можно передавать DataGridView через другое приложение
        public Form1()
        { 
            InitializeComponent();
            addOrder_button.Click+= new System.EventHandler(this.add_data);
        }

        private void load_Table(string path)
        {
            if (!File.Exists(path))
            {
                //Какой-то код
                //Пока можно не писать
                MessageBox.Show("Не указан путь");
                return;
            }

            using (var file_stream=new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(file_stream);

                //Главная табличка м.б. не с индексом "0"
                var table_name = workbook.GetSheetAt(0).SheetName;
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
