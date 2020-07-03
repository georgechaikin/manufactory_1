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
        public NewAdd()
        {
            this.vidRab = new NewVidRab(this);
            this.podRab = new NewPodRab(this);
            InitializeComponent();
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
                        if (((TextBox)x).Text == null || ((TextBox)x).Text.Equals(String.Empty))//TODO: Сделать проверку на наличие ненужных символов и т. п.
                            throw new FormatException();
                        Values.tableSheet.GetRow(Values.startrow).CreateCell(Values.numericHeadings[x.Name]).SetCellValue(Convert.ToDouble(x.Text));
                        

                    }
                    catch (FormatException)// Проверяет, записаны ли данные в виде числа
                    {
                        MessageBox.Show("В текстовой строке для " + x.Name + " нужно ввести число. Также возможно, что поле не заполнено.");
                        success = false;
                        break;
                    }

                    /*catch (NullReferenceException)
                    {
                        continue;
                    }
                    */
                    catch (KeyNotFoundException)//Если textBox не указан в списке числовых данных, то он ищется уже в списке строчных данных
                    {
                        #region Поиск textBox'a в списке строчных данных (Values.stringHeadings)
                        try
                        {
                            Values.tableSheet.GetRow(Values.startrow).CreateCell(Values.stringHeadings[x.Name]).SetCellValue(x.Text);//Если использовать GetCell() вместо CreateCell то независимо от try-catch может выброситься NullReferenceException.
                            if (((TextBox)x).Text == null || ((TextBox)x).Text.Equals(String.Empty))
                                throw new FormatException();
                        }
                        catch (FormatException)// Проверяет, записаны ли данные в виде числа
                        {
                            MessageBox.Show("Поле " + x.Name + " не заполнено.");
                            success = false;
                            break;
                        }
                        /*catch (NullReferenceException e)
                        {
                            MessageBox.Show(e.Message);
                            continue;
                        }*/
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
    }

}
