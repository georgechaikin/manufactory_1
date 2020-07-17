using Manufactory.Additional;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufactory
{
    /// <summary>
    /// Форма с двумя таблицами: список актуальных заказов и список прошлых заказов.
    /// Кол-во выводимых заказов зависит от значений переменных numberOfActualOrders и numberOfPastOrders
    /// </summary>
    public partial class OrderListForm : Form
    {
        private int numberOfActualOrders;
        private int numberOfPastOrders;
        private Form mainForm;
        public OrderListForm(Form mainForm, int numberOfActualOrders, int numberOfPastOrders)
        {
            this.mainForm = mainForm;
            this.numberOfActualOrders = numberOfActualOrders;
            this.numberOfPastOrders = numberOfPastOrders;
            InitializeComponent();
            this.actualGridView.AllowUserToAddRows = false;//Пока запретим редактировать заказы в этой форме
            this.pastGridView.AllowUserToAddRows = false;
            this.FormClosed += new FormClosedEventHandler(this.enableMainForm);
            loadOrderLists();
        }
        /// <summary>
        /// Загружает заказы в таблицы
        /// </summary>
        private void loadOrderLists()
        {

            Dictionary<int, string> headings = Values.headings.ToDictionary(s => s.Value, s => s.Key);
            var keyArray = headings.Keys.ToArray();
            //Array.Sort(keyArray);

            //Задаем заголовки для обоих DataGridView
            for (int i = 0; i < keyArray.Length; i++)
            {
                this.pastGridView.Columns.Add(headings[i], headings[i]);
                this.actualGridView.Columns.Add(headings[i], headings[i]);

            }

            //Вычитаем из i эти значения в методе setCellValue, чтобы заполнять соответствующие таблицы с нужного индекса (чтобы не выходить за рамки существующих строк)
            int actualBeginIndex = Values.currentRowIndex - numberOfActualOrders;
            int pastBeginIndex = Values.currentRowIndex - numberOfActualOrders - numberOfPastOrders;

            //Заполняем actualGridView
            //TODO: Добавить условие на считывание за пределами данных
            for (int i = Values.currentRowIndex - numberOfActualOrders; i < Values.currentRowIndex; i++)
            {
                if (i < Values.startRowIndex)
                {
                    actualBeginIndex++;
                    continue;
                }
                this.actualGridView.Rows.Add();
                for (int j = 0; j < keyArray.Length; j++)
                {
                    setCellValue(this.actualGridView, i, j, actualBeginIndex);
                }
            }
            //Заполняем pastGridView
            for (int i = Values.currentRowIndex - numberOfActualOrders - numberOfPastOrders; i < Values.currentRowIndex - numberOfActualOrders; i++)
            {
                if (i < Values.startRowIndex)
                {
                    pastBeginIndex++;
                    continue;
                }
                this.pastGridView.Rows.Add();
                for (int j = 0; j < keyArray.Length; j++)
                {
                    setCellValue(this.pastGridView, i, j, pastBeginIndex);
                }
            }
        }
        /// <summary>
        /// Заполняет ячейку таблицы
        /// </summary>
        /// <param name="dataGridView">DataGridView для заполнения</param>
        /// <param name="i">Индекс строки в Values.tableSheet</param>
        /// <param name="j">Индекс столбца в Values.tableSheet</param>
        /// <param name="beginIndex">Вычитаем из индекса строки значение beginIndex, чтобы заполнение начиналось с нулевой строки</param>
        private void setCellValue(DataGridView dataGridView, int i, int j, int beginIndex)
        {
            //MessageBox.Show(i + "," + j);
            var cell = Values.tableSheet.GetRow(i).GetCell(j);
            if (cell != null)
            {
                //MessageBox.Show((i).ToString() + "," + j.ToString());
                //MessageBox.Show((i - beginIndex).ToString() + "," + j.ToString());
                //Заполняем ячейку в зависимости от типа данных
                //Можно потом добавить не только считывание строчек и цифр, а также формул(возможно и ссылок, надо потом попробовать)
                switch (cell.CellType)
                {
                    case NPOI.SS.UserModel.CellType.Numeric:
                        dataGridView.Rows[i - beginIndex].Cells[j].Value = Values.tableSheet.GetRow(i).GetCell(j).NumericCellValue;
                        break;
                    case NPOI.SS.UserModel.CellType.String:
                        dataGridView.Rows[i - beginIndex].Cells[j].Value = Values.tableSheet.GetRow(i).GetCell(j).StringCellValue;
                        break;
                }
            }
            else
            {
                //Код для обработки исключения
            }
        }
        /// <summary>
        /// Применяется при нажатии на крестик
        /// </summary>
        private void enableMainForm(object sender, FormClosedEventArgs e)
        {
            this.mainForm.Enabled = true;
        }
    }
}
