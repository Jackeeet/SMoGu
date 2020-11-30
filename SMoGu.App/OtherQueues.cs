using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    class OtherQueues : ICreatable<Tuple<decimal, DateTime>>
    {
        public Queue<Tuple<decimal, decimal, decimal, DateTime>> queue;

        public OtherQueues(TimeOptions duration)
        {

            DailyDataParcer parcer = new DailyDataParcer(duration);
            queue = parcer.getData();
        }

        public List<Tuple<decimal, DateTime>> CreateNewTupleList(CurrencyType currency, TimeOptions duration)
        {
            if (duration.Equals(TimeOptions.One_Day)) throw new ArgumentException("Ты че дурак бл*ть?! Написано же другие очереди, " +
                "нет надо изъеб*уться бл*ть, показать, что тебе все дозволено, мудила ты редкостная");
            return Queue<Tuple<decimal, decimal, decimal, DateTime>>.CreateHelper(queue, currency);
        }
    }
}
