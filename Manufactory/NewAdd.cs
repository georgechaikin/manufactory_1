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
        public NewAdd()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewAdd_Load(object sender, EventArgs e)
        {

        }

        private void openPodRab(object sender, EventArgs e)//TODO: Узнать, удаляет ли GC Формы после нажатия на крестик
        {
            NewPodRab podRab = new NewPodRab(this);
            this.Enabled = false;
            podRab.Show();
        }

        private void openVidRab(object sender, EventArgs e)//TODO: Узнать, удаляет ли GC Формы после нажатия на крестик
        {
            {
                NewVidRab vidRab = new NewVidRab(this);
                this.Enabled = false;
                vidRab.Show();
            }
        }
    }
}
