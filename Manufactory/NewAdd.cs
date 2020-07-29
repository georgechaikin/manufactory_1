﻿using Manufactory.Additional;
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
            this.requestNumberTextBox.Text = (Values.currentRowIndex-Values.startRowIndex).ToString();
            this.requestNumberTextBox.ReadOnly = true;
            this.FormClosing+=new FormClosingEventHandler(openMainForm);
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
           
            Program.forms["Main Form"].updateData();
            Program.forms["Add Order Form"].updateData();
            Program.forms["Pod Rab Form"].updateData();
            Program.forms["Vid Rab Form"].updateData();
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
                //vidRab.Show();
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

                            Values.tableSheet.GetRow(Values.currentRowIndex).CreateCell(Values.numericHeadings[x.AccessibleName]).SetCellValue(Convert.ToDouble(x.Text));


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
            //NewCardOrder cardOrderForm = new NewCardOrder(new Form[] { this, this.vidRab, this.podRab });
            //Program.forms["Card Form"] = new NewCardOrder(new Form[] { Program.forms["Add Order Form"], Program.forms["Pod Rab Form"], Program.forms["Vid Rab Form"] });
            Program.forms["Card Form"].updateData();
            Program.forms["Card Form"].Show();
            //cardOrderForm.Show();

        }
        private void showOrderList(object sender, EventArgs e)
        {
            //this.Enabled = false;
            //OrderListForm orderListForm = new OrderListForm(this,Values.numberOfActualOrders, 5);
            //orderListForm.Show();
        }
        public override void updateData()
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
    }

}
