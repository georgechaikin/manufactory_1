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
    public partial class NewVidRab : Form
    {
        Form parentForm;
        public NewVidRab(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(this.enableParentForm);
        }

        /// <summary>
        /// Применяется при нажатии на крестик
        /// </summary>
        private void enableParentForm(object sender, FormClosedEventArgs e)
        {
            this.parentForm.Enabled = true;
        }
    }
}
