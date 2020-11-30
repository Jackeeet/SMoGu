using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    class HourlyDataParcer : IDataParcer<Tuple<decimal, decimal, decimal, DateTime>>
    {
        public Queue<Tuple<decimal, decimal, decimal, DateTime>> getData()
        {
            throw new NotImplementedException();
        }

        public void parceData()
        {
            throw new NotImplementedException();
        }
    }
}
