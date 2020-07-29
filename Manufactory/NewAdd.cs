using Manufactory.Additional;
using NPOI.SS.UserModel;
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
    public partial class NewAdd : SpecialForm
    {
        public NewAdd()
        {
            InitializeComponent();
            this.requestNumberTextBox.Text = (Values.currentRowIndex - Values.startRowIndex).ToString();
            this.requestNumberTextBox.ReadOnly = true;
            this.FormClosing += new FormClosingEventHandler(openMainForm);
            this.materialCostTextBox.TextChanged += (sender, e) => updateData();
            this.productNumberTextBox.TextChanged += (sender, e) => updateData();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewAdd_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Применяется при нажатии на крестик
        /// </summary>
        private void openMainForm(object sender, FormClosingEventArgs e)
        {

            Program.forms["Main Form"].resetData();
            Program.forms["Add Order Form"].resetData();
            Program.forms["Pod Rab Form"].resetData();
            Program.forms["Vid Rab Form"].resetData();
            Program.forms["Main Form"].Enabled = true;
            e.Cancel = true;
            this.Hide();
        }
        /// <summary>
        /// Открывает окно для доп. информации (Подготовительные работы)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openPodRab(object sender, EventArgs e)//TODO: Узнать, удаляет ли GC Формы после нажатия на крестик
        {
            this.Enabled = false;
            Program.forms["Pod Rab Form"].Show();
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
                Program.forms["Vid Rab Form"].Show();
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
            if (Values.tableSheet.GetRow(Values.currentRowIndex) == null)
                Values.tableSheet.CreateRow(Values.currentRowIndex);
            bool newAddSuccess = addCellsFromCollection(this.Controls);
            bool vidRabSuccess = addCellsFromCollection(Program.forms["Vid Rab Form"].Controls);
            bool podRabSuccess = addCellsFromCollection(Program.forms["Pod Rab Form"].Controls);


            //TODO: Найти более правильный способ избежать повреждения файла (в данный момент используется FileMode.Create вместо FileMode.Open)
            if (newAddSuccess && vidRabSuccess && podRabSuccess)
            {
                using (var fileStream = new FileStream(Values.path, FileMode.Create, FileAccess.Write))
                {
                    Values.workbook.Write(fileStream);
                    MessageBox.Show("Заказ добавлен");
                }
                Values.numberOfActualOrders++;
                Values.currentRowIndex++;
                this.requestNumberTextBox.Text = (Values.currentRowIndex - Values.startRowIndex).ToString();
            }
            //else Values.tableSheet.RemoveRow(Values.tableSheet.GetRow(Values.currentRowIndex));

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
                try
                {
                    if (String.IsNullOrEmpty(x.Text))//TODO: Сделать проверку на наличие ненужных символов и т.п.
                        throw new FormatException();

                    //ICellStyle styleDateFormat=Values.workbook.CreateCellStyle();
                    //styleDateFormat.DataFormat = 8;
                    //Values.tableSheet.GetRow(Values.currentRowIndex).CreateCell(Values.numericHeadings[x.AccessibleName]).SetCellValue(Convert.ToDouble(x.Text));
                    Values.tableSheet.GetRow(Values.currentRowIndex).CreateCell(Values.numericHeadings[x.AccessibleName]);
                    //Values.tableSheet.GetRow(Values.currentRowIndex).GetCell(Values.numericHeadings[x.AccessibleName]).CellStyle=styleDateFormat;
                    Values.tableSheet.GetRow(Values.currentRowIndex).GetCell(Values.numericHeadings[x.AccessibleName]).SetCellValue(x.Text);



                }
                //catch(NullReferenceException) { MessageBox.Show(x.AccessibleName); }
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
                        if (String.IsNullOrEmpty(x.Text))//TODO: Сделать проверку на наличие ненужных символов и т.п.
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
            Program.forms["Card Form"].resetData();
            Program.forms["Card Form"].Show();

        }
        private void showOrderList(object sender, EventArgs e)
        {
            //this.Enabled = false;
            //OrderListForm orderListForm = new OrderListForm(this,Values.numberOfActualOrders, 5);
            //orderListForm.Show();
        }
        public override void resetData()
        {
            foreach (Control x in this.Controls)
                switch (x)
                {
                    case TextBox textBox:
                        textBox.Text = String.Empty;
                        break;
                    case ComboBox comboBox:
                        comboBox.Text = String.Empty;
                        break;
                }
            this.requestNumberTextBox.Text = (Values.currentRowIndex - Values.startRowIndex).ToString();
        }
        public override void updateData()//TODO: сделать подсчёт итоговой стоимости проще
        {
            SpecialForm podRabForm = Program.forms["Pod Rab Form"];
            SpecialForm vidRabForm = Program.forms["Vid Rab Form"];
            decimal podRabSum = 0;
            decimal vidRabSum = 0;
            foreach (Control x in podRabForm.Controls)
                switch (x)
                {
                    case TextBox textBox:
                        try
                        {
                            if (textBox.ReadOnly) podRabSum += Convert.ToDecimal(textBox.Text);
                        }
                        catch (FormatException)
                        {
                            continue;
                        }
                        break;
                }
            foreach (Control x in vidRabForm.Controls)
                switch (x)
                {
                    case TextBox textBox:
                        try
                        {
                            if (textBox.ReadOnly) vidRabSum += Convert.ToDecimal(textBox.Text);
                        }
                        catch (FormatException)
                        {
                            continue;
                        }
                        break;
                }
            try
            {
                this.totalCostLabel.Text = (Convert.ToDecimal(this.productNumberTextBox.Text) * Convert.ToDecimal(this.materialCostTextBox.Text) + podRabSum+vidRabSum).ToString();
            }
            catch(FormatException)
            {
                this.totalCostLabel.Text = String.Empty;
            }
        }
        private void updateTotalCost(object sender, EventArgs e)
        {
            SpecialForm podRabForm = Program.forms["Pod Rab Form"];
            SpecialForm vidRabForm = Program.forms["Vid Rab Form"];
            //this.totalCostLabel.Text = 
        }
    }

}
