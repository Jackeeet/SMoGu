using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    /// <summary>
    /// интерфейс декларирующий классу для создания структуры для построения
    /// графика, чтобы он содержал метод для создания списка данных
    /// </summary>
    /// <typeparam name="T"> тип списка данных для построения графика </typeparam>
    interface ICreatable<T>
    {
        /// <summary>
        /// метод создания списка данных, получаемых из парсера
        /// </summary>
        /// <param name="currency"> тип валюты для которой строится список </param>
        /// <returns></returns>
         List<T> CreateNewTupleList(CurrencyType currency);
    }
}
