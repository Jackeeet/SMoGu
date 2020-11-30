using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    interface IDataParser<T>
    {
    	Queue<T> getData();
        void parceData();
    }
}
