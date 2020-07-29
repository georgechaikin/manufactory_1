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
        public NewVidRab()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;
            this.textBox8.ReadOnly = true;
            this.textBox1.TextChanged += (sender, e) => showCost(sender, e, textBox1, textBox5,17);
            this.textBox2.TextChanged += (sender, e) => showCost(sender, e, textBox2, textBox6,15.5);
            this.textBox3.TextChanged += (sender, e) => showCost(sender, e, textBox3, textBox7,12);
            this.textBox4.TextChanged += (sender, e) => showCost(sender, e, textBox4, textBox8,750);
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

        protected void showCost(object sender, EventArgs e,Control inputControl, Control outputControl,double price)//TODO: Поменять на decimal
        {
           
            try
            {
                outputControl.Text = (Convert.ToDouble(inputControl.Text) * price).ToString();
            }
            catch(FormatException)
            {
                outputControl.Text = String.Empty;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
