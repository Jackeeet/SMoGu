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

        public OneDayQueue()
        {
            HourlyDataParser parcer = new HourlyDataParser();
            queue = parcer.getData();
        }

        public List<Tuple<decimal, DateTime>> CreateNewTupleList(CurrencyType currency, TimeOptions duration)
        {
            if (duration != TimeOptions.One_Day) throw new ArgumentException("Ой дурааак...");
            return Queue<Tuple<decimal, decimal, decimal, DateTime>>.CreateHelper(queue, currency);
        }
    }
}
