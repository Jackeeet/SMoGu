using System.Collections.Generic;

namespace SMoGu.App
{
    /// <summary>
    /// Интерфейс, декларирующий классу, создающему структуру для построения
    /// графика, чтобы он содержал метод для создания списка данных.
    /// </summary>
    /// <typeparam name="T"> Тип списка данных для построения графика. </typeparam>
    interface ICreatable<T>
    {
        /// <summary>
        /// Метод, создающий список данных, получаемых из парсера
        /// </summary>
        /// <param name="currency"> Тип валюты, для которой строится список. </param>
         List<T> CreateNewTupleList(CurrencyType currency);
    }
}
