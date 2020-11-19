using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    interface ICreatable<T>
    {
         List<T> CreateNewTupleList(CurrencyType currency, TimeOptions duration);
    }
}
