using Manufactory.Additional;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufactory
{
    public partial class NewAdd : Form
    {
        private NewVidRab vidRab;
        private NewPodRab podRab;
        private int numberOfActualOrders;
        public NewAdd()
        {
            this.vidRab = new NewVidRab(this);
            this.podRab = new NewPodRab(this);
            numberOfActualOrders = 0;
            InitializeComponent();
            this.requestNumberTextBox.Text = Values.currentRowIndex.ToString();
            this.requestNumberTextBox.ReadOnly = true;

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
            this.Enabled = false;

            bool newAddSuccess = addCellsFromCollection(this.Controls);
            bool vidRabSuccess = addCellsFromCollection(this.vidRab.Controls);
            bool podRabSuccess = addCellsFromCollection(this.podRab.Controls);

            if (newAddSuccess && vidRabSuccess && podRabSuccess)
                using (var fileStream = new FileStream(Values.path, FileMode.Open, FileAccess.Write))
                {
                    Values.workbook.Write(fileStream);
                    MessageBox.Show("Заказ добавлен");
                }
            
            numberOfActualOrders++;
            Values.currentRowIndex++;
            this.requestNumberTextBox.Text = Values.currentRowIndex.ToString();
            this.Enabled = true;
            

        }

        /// <summary>
        /// Заполняет строку под номером startrow данными из textBox'ов в заданной коллекции.
        /// </summary>
        /// <param name="collection">Коллекция, содержащая произвольные элементы на нашей Form. Передается обычно поле Controls из Form.</param>
        private bool addCellsFromCollection(System.Windows.Forms.Control.ControlCollection collection)
        {
            bool success = true;
            //Пробегаемся по всем объектам коллекции(внутри коллекции объекты нашей формы)
            foreach (Control x in collection)
            {
                if (x.GetType() == typeof(TextBox))//Рассматриваем пока что только textBox'ы
                {
                    try
                    {
                        if (String.IsNullOrEmpty(x.Text))//TODO: Сделать проверку на наличие ненужных символов и т.п.
                            throw new FormatException();

                        //TODO: Вместо Name лучше использовать AccessibleName, так как при изменении Form через конструктор сбрасываются имена
                        Values.tableSheet.GetRow(Values.currentRowIndex).CreateCell(Values.numericHeadings[x.AccessibleName]).SetCellValue(Convert.ToDouble(x.Text));


                    }
                    catch (FormatException)// Проверяет, записаны ли данные в виде числа
                    {
                        MessageBox.Show("В текстовой строке для " + x.AccessibleName + " нужно ввести число. Также возможно, что поле не заполнено.");
                        success = false;
                        break;
                    }

                    catch (ArgumentNullException)
                    {
                        continue;
                    }

                    catch (KeyNotFoundException)//Если textBox не указан в списке числовых данных, то он ищется уже в списке строчных данных
                    {
                        #region Поиск textBox'a в списке строчных данных (Values.stringHeadings)
                        try
                        {
                            if (((TextBox)x).Text == null || ((TextBox)x).Text.Equals(String.Empty))
                                throw new FormatException();
                            Values.tableSheet.GetRow(Values.currentRowIndex).CreateCell(Values.stringHeadings[x.AccessibleName]).SetCellValue(x.Text);//Если использовать GetCell() вместо CreateCell то независимо от try-catch может выброситься NullReferenceException.
                            
                        }
                        catch (FormatException)// Проверяет, записаны ли данные в виде числа
                        {
                            MessageBox.Show("Поле " + x.Name + " не заполнено.");
                            success = false;
                            break;
                        }
                        catch (ArgumentNullException e)
                        {
                            MessageBox.Show(e.Message);
                            continue;
                        }
                        catch (KeyNotFoundException)
                        {
                            continue;
                        }
                        #endregion
                    }

                }
            }
            return success;
        }
        /// <summary>
        /// Показывает информацию по текущему заказу (заполненные и незаполненные поля заказа)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showCard(object sender, EventArgs e)
        {
            this.Enabled = false;
            NewCardOrder cardOrderForm = new NewCardOrder(new Form[] { this, this.vidRab, this.podRab });
            cardOrderForm.Show();

        }
        private void showOrderList(object sender, EventArgs e)
        {
            this.Enabled = false;
            OrderListForm orderListForm = new OrderListForm(this,numberOfActualOrders, 5);
            orderListForm.Show();
        }
    }

}
