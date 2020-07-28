using Manufactory.Additional;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufactory
{
    public partial class NewVidRab : SpecialForm
    {
        //Form parentForm;
        public NewVidRab()
        {
            //this.parentForm = parentForm;
            InitializeComponent();
            this.ControlBox = false;
        }

        private void hideForm(object sender, EventArgs e)
        {
            //this.parentForm.Enabled = true;
            Program.forms["Add Order Form"].Enabled = true;
            this.Hide();
        }
        public override void updateData()
        {
            foreach (Control x in this.Controls)
                switch (x)
                {
                    case TextBox textBox:
                        textBox.Text = String.Empty;
                        break;
                }
        }
    }

}
