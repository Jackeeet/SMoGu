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
        public List<Tuple<decimal, DateTime>> CreateNewTupleList(CurrencyType currency, TimeOptions duration)
        {
            throw new NotImplementedException();
        }
    }
}
