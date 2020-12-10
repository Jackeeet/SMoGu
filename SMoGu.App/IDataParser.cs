namespace SMoGu.App
{
    /// <summary>
    /// Интерфейс требующий реализации в каждом парсере соответствующих методов
    /// </summary>
    /// <typeparam name="T"> тип данных для очереди </typeparam>
    interface IDataParser<T>
    {
        /// <summary>
        /// Метод для получения данных с произвольного сайта
        /// </summary>
        /// <returns> возвращает очередь с требуемыми значениями </returns>
        Queue<T> GetData();
        /// <summary>
        /// основной метод парсинга данных с произвольного сайта
        /// </summary>
        void ParceData();
    }
}
