using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Smogu
{
    public class Investment
    {
        public readonly string InvestmentName;
        public readonly Decimal Amount;
        public readonly CurrencyType Currency;

        private double riskEstimate;
        private double proceedsEstimate;
        private double profitPercentage;

        public Investment(string name, Decimal amount, CurrencyType currency)
        {
            InvestmentName = name;
            Amount = amount;
            Currency = currency;
            riskEstimate = CalculateRiskEstimate();
            proceedsEstimate = CalculateProceedsEstimate();
            profitPercentage = CalculateProfitPercentage();
        }

        private static double CalculateRiskEstimate()
        {
            throw new NotImplementedException();
        }

        private static double CalculateProceedsEstimate()
        {
            throw new NotImplementedException();
        }

        private static double CalculateProfitPercentage()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Investment)) return false;
            var invt = obj as Investment;
            return InvestmentName == invt.InvestmentName && Amount == invt.Amount && Currency == invt.Currency;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (int)Amount * 7127 + Currency * 7121 + InvestmentName.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1:0.00} {2}", InvestmentName, Amount, Currency);
        }
    }
}