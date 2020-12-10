using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    /// <summary>
    /// класс данных и методов для построения графика
    /// </summary>
    public class ChartData : ICreatable<Tuple<decimal, DateTime>>
    {
        /// <summary>
        /// очередь, из которой берутся данные для построения графика
        /// </summary>
        public Queue<Tuple<decimal, decimal, decimal, DateTime>> queue;
        /// <summary>
        /// временной промежуток по которому строится график
        /// </summary>
        public readonly TimeOptions duration;
        /// <summary>
        /// конструктор класса
        /// </summary>
        /// <param name="duration"> временной промежуток по которому строится график </param>
        public ChartData(TimeOptions duration)
        {
            this.duration = duration;
            DailyDataParser parcer = new DailyDataParser(duration);
            queue = parcer.GetData();
        }
        /// <summary>
        /// метод, создающий список содержащий пары "курс валюты - дата" по заданному типу валюты
        /// </summary>
        /// <param name="currency"> заданный тип валюты </param>
        /// <returns></returns>
        public List<Tuple<decimal, DateTime>> CreateNewTupleList(CurrencyType currency)
        {
            if (duration.Equals(TimeOptions.One_Day)) throw new ArgumentException("Введен некорректный временной параметр");
            return CreateHelper(queue, currency);
        }
        /// <summary>
        /// вспомогательный метод создания списка, который преобразует очередь в список пар
        /// </summary>
        /// <param name="queue"> исходная очередь </param>
        /// <param name="currency"> тип валюты по которому строится график </param>
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
