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
            //здесь будет код для создния нового списка кортжей, содержащих курс по заданной валюте
            //длина списка берется в зависимости от duration и обрезается из исходной очереди
            Console.WriteLine("Перемен, требуют наши сердца")
            throw new NotImplementedException();
        }
    }
}
