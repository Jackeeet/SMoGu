using System;
using System.Collections.Generic;

namespace SMoGu.App
{
    public class Investment
    {
        public readonly string InvestmentName;
        public readonly decimal Amount; // инвестируемая сумма
        public readonly CurrencyType Currency; // валюта
        public readonly int PredictionPeriod; // период прогнозирования изменения курса в днях
        public readonly List<Tuple<decimal, DateTime>> ValuesOverTime; // спрогнозированные данные

        public double RiskEstimate { get; private set; } // предполагаемые риски
        public decimal ProceedsEstimate { get; private set; } // предполагаемая прибыль (за сколько можно будет продать)
        public double ProfitPercentage { get; private set; } // процент доходности (эта штука еще называется "относительная величина прибыли")

        public Investment(string name, decimal amount, CurrencyType currency, int period, PredictionCalculator calc)
        {
            InvestmentName = name;
            Amount = amount;
            Currency = currency;
            PredictionPeriod = period;

            try
            {
                ValuesOverTime = calc.PredictCurrencyValues(period, currency);
            }
            catch
            {

            }

            RiskEstimate = CalculateRiskEstimate();
            ProceedsEstimate = CalculateProceedsEstimate();
            ProfitPercentage = CalculateProfitPercentage();
        }

        private double CalculateRiskEstimate()
        {
            // temporary
            return 0.0;
        }

        private decimal CalculateProceedsEstimate()
        {
            // прибыль = сумма продажи - сумма покупки
            return ValuesOverTime[ValuesOverTime.Count - 1].Item1 - ValuesOverTime[0].Item1;
        }

        private double CalculateProfitPercentage()
        {
            // формула отсюда
            // https://activeinvestor.pro/kak-schitat-dohodnost-investitsij-formuly-rascheta/
            // это первый попавшийся сайт на самом деле, я не шарю
            return (double)ProceedsEstimate / (double)Amount * 100;
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