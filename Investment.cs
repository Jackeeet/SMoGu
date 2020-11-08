using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Smogu
{
    public class Investment
    {
        public string InvestmentName;
        public double Amount;
        //public CurrencyType currencyType;

        public override bool Equals(object obj)
        {
           throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
