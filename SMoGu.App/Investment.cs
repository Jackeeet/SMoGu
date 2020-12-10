using System;
using System.Collections.Generic;

namespace SMoGu.App
{
    /// <summary>
    /// Создаваемый пользователем вариант инвестиции.
    /// </summary>
    public class Investment
    {
        /// <summary>
        /// Название варианта инвестиции.
        /// </summary>
        public readonly string InvestmentName;
        /// <summary>
        /// Предполагаемое количество валюты.
        /// </summary>
        public readonly decimal Amount;
        /// <summary>
        /// Валюта, в которую предполагается инвестировать.
        /// </summary>
        public readonly CurrencyType Currency;
        /// <summary>
        /// Период в днях, по окончанию которого предполагается продать купленную валюту.
        /// </summary>
        public readonly int PredictionPeriod;
        /// <summary>
        /// Список спрогнозированных значений курса выбранной валюты в течение выбранного периода.
        /// </summary>
        public readonly List<Tuple<decimal, DateTime>> ValuesOverTime;
        /// <summary>
        /// Предполагаемые риски, связанные с выбранным вариантом инвестиции.
        /// </summary>
        public double RiskEstimate { get; private set; }
        /// <summary>
        /// Предполагаемая сумма (в рублях), которую можно будет получить после продажи валюты.
        /// </summary>
        public decimal ProceedsEstimate { get; private set; } 
        /// <summary>
        /// Доходность инвестиции. Относительная величина прибыли инвестиции.
        /// </summary>
        public double ProfitPercentage { get; private set; }

        /// <summary>
        /// Конструктор класса Investment.
        /// </summary>
        /// <param name="name"> Название варианта инвестиции. </param>
        /// <param name="amount"> Количество валюты. </param>
        /// <param name="currency"> Валюта. </param>
        /// <param name="period"> Период прогнозирования. </param>
        /// <param name="calc"> Калькулятор, прогнозирующий изменения курса валют. </param>
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

        /// <summary>
        /// Метод для расчета предполагаемых рисков. 
        /// </summary>
        /// <returns> Процент риска, связанный с вариантом инвестиции. </returns>
        private double CalculateRiskEstimate()
        {
            // temporary
            return 0.0;
        }
        /// <summary>
        /// Метод для расчета предполагаемой прибыли от продажи валюты.
        /// Определяется по формуле [прибыль = сумма продажи - сумма покупки].
        /// </summary>
        /// <returns> Предполагаемая прибыль в рублях. </returns>
        private decimal CalculateProceedsEstimate()
        {
            return ValuesOverTime[ValuesOverTime.Count - 1].Item1 - ValuesOverTime[0].Item1;
        }
        /// <summary>
        /// Метод для расчета доходности инвестиции.
        /// Источник формулы: https://activeinvestor.pro/kak-schitat-dohodnost-investitsij-formuly-rascheta/
        /// </summary>
        /// <returns> Доходность инвестиции (в процентах). </returns>
        private double CalculateProfitPercentage()
        {
            return (double)ProceedsEstimate / (double)Amount * 100;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Investment)) return false;
            var invt = obj as Investment;
            return InvestmentName == invt.InvestmentName && Amount == invt.Amount && Currency == invt.Currency;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (int)Amount * 7127 + (int)Currency * 7121 + InvestmentName.GetHashCode();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: {1:0.00} {2}", InvestmentName, Amount, Currency);
        }
    }
}