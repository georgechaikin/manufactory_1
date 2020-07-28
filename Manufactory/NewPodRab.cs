using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manufactory.Additional;

namespace Manufactory
{
    public partial class NewPodRab : SpecialForm
    {
        //Form parentForm;
        public NewPodRab()
        {
            this.ControlBox = false;
            //this.parentForm = parentForm;
            InitializeComponent();
        }

        private void NewPodRab_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void hideForm(object sender, EventArgs e)
        {
            //this.parentForm.Enabled = true;
            Program.forms["Add Order Form"].Enabled = true;
            this.Hide();
        }
        public override void updateData()
        {
            foreach(Control x in this.Controls)
                switch (x)
                {
                    case TextBox textBox:
                        textBox.Text = String.Empty;
                        break;
                }
        }
    }
}
