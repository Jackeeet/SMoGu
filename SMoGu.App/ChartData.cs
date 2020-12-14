using System;
using System.Collections.Generic;
using System.Linq;

namespace SMoGu.App
{
    /// <summary>
    /// Класс данных и методов для построения графика.
    /// </summary>
    public class ChartData : ICreatable<Tuple<decimal, DateTime>>
    {
        /// <summary>
        /// Очередь, из которой берутся данные для построения графика.
        /// </summary>
        public Queue<Tuple<decimal, decimal, decimal, DateTime>> queue;
        /// <summary>
        /// Временной промежуток, по которому строится график.
        /// </summary>
        public readonly TimeOptions duration;
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="duration"> Временной промежуток, по которому строится график. </param>
        public ChartData(TimeOptions duration)
        {
            this.duration = duration;
            DailyDataParser parcer = new DailyDataParser(duration);
            queue = parcer.GetData();
        }
        /// <summary>
        /// Метод, создающий список, содержащий пары "курс валюты - дата" по заданному типу валюты.
        /// </summary>
        /// <param name="currency"> Заданный тип валюты. </param>
        /// <returns></returns>
        public List<Tuple<decimal, DateTime>> CreateNewTupleList(CurrencyType currency)
        {
            if (duration.Equals(TimeOptions.One_Day)) throw new ArgumentException("Введен некорректный временной параметр");
            return CreateHelper(queue, currency);
        }
        /// <summary>
        /// Вспомогательный метод создания списка, который преобразует очередь в список пар.
        /// </summary>
        /// <param name="queue"> Исходная очередь. </param>
        /// <param name="currency"> Тип валюты, по которому строится график. </param>
        /// <returns></returns>
        private static List<Tuple<decimal, DateTime>> CreateHelper(Queue<Tuple<decimal, decimal, decimal, DateTime>> queue, CurrencyType currency)
        {
            switch (currency)
            {
                case CurrencyType.USD: return queue.Select(t => Tuple.Create(t.Item1, t.Item4)).ToList();
                case CurrencyType.EUR: return queue.Select(t => Tuple.Create(t.Item2, t.Item4)).ToList();
                case CurrencyType.CNY: return queue.Select(t => Tuple.Create(t.Item3, t.Item4)).ToList();
                default: throw new ArgumentException();
            }
        }
    }
}
