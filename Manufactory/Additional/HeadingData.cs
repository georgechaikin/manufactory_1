using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufactory.Additional
{
    /// <summary>
    /// Данные определённого заголовкаы
    /// </summary>
    class HeadingData
    {
        /// <summary>
        /// Данные для этой ячейки
        /// </summary>
        private string data;
        /// <summary>
        /// Порядковый номер заголовка в таблице (начинается с 0)
        /// </summary>
        private int indexNumber;
        /// <summary>
        /// Тип данных ячейки
        /// </summary>
        private CellType dataType;

        public HeadingData(int indexNumber, CellType dataType, string data)
        {
            this.indexNumber = indexNumber;
            this.data = data;
            this.dataType = dataType;
        }

        /// <summary>
        /// Возвращает данные, соответствующие ячейке, в соответсвие с типом данных
        /// </summary
        public void writeData(IRow row)//TODO: Проверить, как работает
        {
            switch (this.dataType) //Всего у CellType 7 типов
            {
                case NPOI.SS.UserModel.CellType.Numeric:
                    row.GetCell(indexNumber).SetCellValue(Convert.ToDouble(data));
                    break;
                case NPOI.SS.UserModel.CellType.String:
                    row.GetCell(indexNumber).SetCellValue(data);
                    break;
            }
           
        }
        
    }
}
