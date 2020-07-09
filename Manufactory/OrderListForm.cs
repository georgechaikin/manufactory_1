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
        public OrderListForm(int numberOfActualOrders, int numberOfPastOrders)
        {
            InitializeComponent();
            loadOrderLists();
        }
        /// <summary>
        /// Загружает заказы в таблицы
        /// </summary>
        private void loadOrderLists()
        {
            Dictionary<int,string> headingsArray = Values.headings.ToDictionary(s => s.Value, s => s.Key);
            var keyArray = headingsArray.Keys.ToArray();
            Array.Sort(keyArray);
            for(int i=0;i<keyArray.Length;i++)
                MessageBox.Show(i+": "+headingsArray[i]);
                //this.actualGridView.Columns.Add();
            //for(int i=Values.startrow;i>=Values.startrow-numberOfActualOrders)
        }
    }
}
