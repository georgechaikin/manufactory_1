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
    public partial class NewAdd : Form
    {
        private string path;
        private string tableName;
        private NewVidRab vidRab;
        private NewPodRab podRab;
        private Dictionary<string, int> headings;
        public NewAdd(string path, string tableName,Dictionary<string,int> headings)
        {
            this.vidRab = new NewVidRab(this);
            this.podRab = new NewPodRab(this);
            InitializeComponent();
            foreach(Control x in this.Controls)
            {
                MessageBox.Show(x.Name);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewAdd_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Открывает окно для доп. информации (Подготовительные работы)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openPodRab(object sender, EventArgs e)//TODO: Узнать, удаляет ли GC Формы после нажатия на крестик
        {
            this.Enabled = false;
            podRab.Show();
        }
       /// <summary>
       /// Открывает окно для доп. информации (Вид работ)
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void openVidRab(object sender, EventArgs e)//TODO: Узнать, удаляет ли GC Формы после нажатия на крестик
        {
            {
                this.Enabled = false;
                vidRab.Show();
            }
        }

        /// <summary>
        /// Добавляет заказ в таблицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addOrder(object sender, EventArgs e)
        {

        }
    }
}
