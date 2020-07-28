using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufactory.Additional
{
    /// <summary>
    /// Форма + специальные методы и поля
    /// </summary>
    public abstract class SpecialForm: Form
    {
        protected Dictionary<String, Control> headingTextBoxPair;
        /// <summary>
        /// Обновляет определённые компоненты в экземпляре класса 
        /// </summary>
        public abstract void updateData();
        /// <summary>
        /// Строит соответствие между названием объекта типа Control и AccesibleName этого объекта (В данном случае это делается для объектов типа TextBox)
        /// </summary>
        protected virtual void setHeadingTextBoxPair()
        {
            headingTextBoxPair = new Dictionary<string, Control>();
            foreach (Control x in this.Controls)
            {
                switch (x)
                {
                    case TextBox textBox:
                        try
                        {
                            textBox.ReadOnly = true;
                            //MessageBox.Show(x.AccessibleName == null ? "Empty" : x.AccessibleName);
                            headingTextBoxPair.Add(x.AccessibleName, x);

                        }
                        catch (ArgumentNullException) { }
                        break;
                    case ComboBox comboBox:
                        break;
                }
            }
        }
    }
}
