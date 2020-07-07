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
        public NewCardOrder(Form[] forms)
        {
            InitializeComponent();
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
                    catch(KeyNotFoundException) { continue; }
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
                        headingTextBoxPair.Add(x.Name, x);
                        break;
                }
            }
        }

    }

}
