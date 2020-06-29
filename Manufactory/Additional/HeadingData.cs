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
    /// <typeparam name="T">Тип поля data</typeparam>
    class HeadingData<T>
    {
        /// <summary>
        /// Данные для этой ячейки
        /// </summary>
        private T data;
        /// <summary>
        /// Порядковый номер заголовка в таблице
        /// </summary>
        private int indexNumber;


        public HeadingData()
        {

        }

        /// <summary>
        /// Возвращает данные, соответствующие ячейке
        /// </summary>
        /// <returns>Данные типа T</returns>
        public T getData()
        {
            return data;
        }
        
        //TODO: разобраться с тем, почему появляется ошибка в методе (пока проверку типа можно делать посредством "data is ...(Указанный тип данных, к примеру String) ")
        /*
        public Type getDataType()
        {
            this.data.GetType();
        }
        */
    }
}
