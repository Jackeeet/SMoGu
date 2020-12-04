using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    class ChartData : ICreatable<Tuple<decimal, DateTime>>
    {
        public Queue<Tuple<decimal, decimal, decimal, DateTime>> queue;

        public ChartData(TimeOptions duration)
        {
            DailyDataParser parcer = new DailyDataParser(duration);
            queue = parcer.GetData();
        }

        public List<Tuple<decimal, DateTime>> CreateNewTupleList(CurrencyType currency, TimeOptions duration)
        {
            if (duration.Equals(TimeOptions.One_Day)) throw new ArgumentException("Введен некорректный временной параметр");
            return CreateHelper(queue, currency);
        }

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
