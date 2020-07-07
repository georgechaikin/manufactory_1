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
    public partial class NewCardOrder : Form
    {
        Dictionary<string, Control> headingTextBoxPair;
        Form[] forms;
        public NewCardOrder(Form[] forms)
        {
            InitializeComponent();
            this.forms = forms;
            this.FormClosed += new FormClosedEventHandler(this.enableMainForm);
            setHeadingTextBoxPair();
            loadCard(forms);
            
        }

        private void loadCard(Form[] forms)
        {
            for(int i=0;i<forms.Length;i++)
                foreach(Control x in forms[i].Controls)
                {
                    try
                    {
                        headingTextBoxPair[x.Name].Text = x.Text;
                    }
                    catch(KeyNotFoundException) {
                        //MessageBox.Show(x.Name);
                        continue; }
                }
        }
        private void setHeadingTextBoxPair()
        {
            headingTextBoxPair = new Dictionary<string, Control>();
            foreach (Control x in this.Controls)
            {
                switch (x)
                {
                    case TextBox textBox:
                        textBox.ReadOnly = true;
                        headingTextBoxPair.Add(x.Name, x);
                        break;
                    case ComboBox comboBox:
                        break;
                }
            }
        }
        /// <summary>
        /// Применяется при нажатии на крестик
        /// </summary>
        private void enableMainForm(object sender, FormClosedEventArgs e)
        {
            this.forms[0].Enabled = true;//TODO: Не факт, что форма, с которой вызвали NewCardOrder, будет в начале массива. Так что желательно бы сделать более удобный способ обращения к нужному Form.
        }
    }

}
