using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    class OneDayQueue : ICreatable<Tuple<decimal, DateTime>>
    {
        public Queue<Tuple<decimal, decimal, decimal, DateTime>> queue;
        public List<Tuple<decimal, DateTime>> CreateNewTupleList(CurrencyType currency, TimeOptions duration)
        {
            if (duration != TimeOptions.One_Day) throw new ArgumentException();
            return CreateHelper(queue, currency);
        }

        private List<Tuple<decimal, DateTime>> CreateHelper(Queue<Tuple<decimal, decimal, decimal, DateTime>> queue, CurrencyType currency)
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
