namespace SMoGu.App
{
    /// <summary>
    /// Интерфейс, требующий реализации в каждом парсере соответствующих методов.
    /// </summary>
    /// <typeparam name="T"> Тип данных для очереди. </typeparam>
    interface IDataParser<T>
    {
        /// <summary>
        /// Метод для получения данных с произвольного сайта.
        /// </summary>
        /// <returns> Возвращает очередь с требуемыми значениями. </returns>
        Queue<T> GetData();
        /// <summary>
        /// Основной метод парсинга данных с произвольного сайта.
        /// </summary>
        void ParseData();
    }
}
