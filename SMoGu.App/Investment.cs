﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SMoGu.App
{
    public class Investment
    {
        public readonly string InvestmentName;
        public readonly decimal Amount;
        public readonly CurrencyType Currency;

        public double RiskEstimate { get; private set; }
        public double ProceedsEstimate { get; private set; }
        public double ProfitPercentage { get; private set; }

        public Investment(string name, decimal amount, CurrencyType currency)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException();
            InvestmentName = name;
            if (amount < new decimal(0.01))
                throw new ArgumentException();
            Amount = amount;
            Currency = currency;

            RiskEstimate = CalculateRiskEstimate();
            ProceedsEstimate = CalculateProceedsEstimate();
            ProfitPercentage = CalculateProfitPercentage();
        }

        private double CalculateRiskEstimate()
        {
            // temporary
            return 0.0;
        }

        private double CalculateProceedsEstimate()
        {
            // temporary
            return 0.0;
        }

        private double CalculateProfitPercentage()
        {
            return ProceedsEstimate / (double)Amount * 100;
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
                return (int)Amount * 7127 + (int)Currency * 7121 + InvestmentName.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1:0.00} {2}", InvestmentName, Amount, Currency);
        }
    }
}