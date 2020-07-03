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
        private string path;
        private string tableName;
        private NewVidRab vidRab;
        private NewPodRab podRab;
        public NewAdd(string path, string tableName)
        {
            this.path = path;
            this.tableName = tableName;
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


            addCellsFromCollection(this.Controls);
            addCellsFromCollection(this.vidRab.Controls);
            addCellsFromCollection(this.podRab.Controls);
            
            using (var file_stream = new FileStream(Values.path, FileMode.Open, FileAccess.Write))
            {
                
            }
        }
       /// <summary>
       /// Заполняет строку под номером startrow данными из textBox'ов в заданной коллекции.
       /// </summary>
       /// <param name="collection">Коллекция, содержащая произвольные элементы на нашей Form. Передается обычно поле Controls из Form.</param>
        private void addCellsFromCollection(System.Windows.Forms.Control.ControlCollection collection)
        { 
            //Пробегаемся по всем объектам коллекции(внутри коллекции объекты нашей формы)
            foreach (Control x in collection)
            {
                if (x.GetType() == typeof(TextBox))//Рассматриваем пока что только textBox'ы
                {
                    try 
                    {
                        Values.tableSheet.GetRow(Values.startrow).CreateCell(Values.numericHeadings[x.Name]).SetCellValue(Convert.ToDouble(x.Text));
                    }
                    catch (FormatException)// Проверяет, записаны ли данные в виде числа
                    {
                        MessageBox.Show(x.Name + " не соответствует требуемому шаблону чисел");
                        continue;
                    }
                    
                    /*catch (NullReferenceException)
                    {
                        continue;
                    }
                    */
                    catch (KeyNotFoundException)//Если textBox не указан в списке числовых данных, то он ищется уже в списке строчных данных
                    {
                        #region Поиск textBox'a в списке строчных данных(Values.stringHeadings)
                        try
                        {
                            //string text = x.Text;
                            //MessageBox.Show(x.Name);
                            //MessageBox.Show(Values.stringHeadings[x.Name].ToString());
                            //MessageBox.Show((text is null).ToString());
                            //MessageBox.Show(Values.startrow.ToString());

                            Values.tableSheet.GetRow(Values.startrow).CreateCell(Values.stringHeadings[x.Name]).SetCellValue(x.Text);//Если использовать GetCell() вместо CreateCell то независимо от try-catch может выброситься NullReferenceException.

                        }
                        /*catch (NullReferenceException e)
                        {
                            MessageBox.Show(e.Message);
                            continue;
                        }*/
                        catch (FormatException)
                        {
                            MessageBox.Show(x.Name + " не соответствует требуемому шаблону");
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
        }
    }

}
