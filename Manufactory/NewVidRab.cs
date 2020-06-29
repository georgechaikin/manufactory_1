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
    public partial class NewVidRab : Form
    {
        Form parentForm;
        public NewVidRab(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            this.ControlBox = false;
        }

        private void hideForm(object sender, EventArgs e)
        {
            this.parentForm.Enabled = true;
            this.Hide();
        }
    }
}
