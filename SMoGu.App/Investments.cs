﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SMoGu.App
{
    /// <summary>
    /// Класс-контейнер для вариантов инвестиций.
    /// </summary>
    public class Investments
    {
        /// <summary>
        /// Список для хранения созданных вариантов. 
        /// </summary>
        public List<Investment> Invs; 
        /// <summary>
        /// Калькулятор, необходимый для прогнозирования изменений курса валют. 
        /// </summary>
        public PredictionCalculator Calc { get; private set; }
        /// <summary>
        /// Сеттер для калькулятора.
        /// </summary>
        /// <param name="data"> Исходные данные о курсе валют. </param>
        public void SetCalc(ChartData data)
        {
            if (data == null)
                throw new ArgumentNullException();
            Calc = new PredictionCalculator(data);
        }
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public Investments()
        {
            Invs = new List<Investment>();
        }

        /// <summary>
        /// Создает и добавляет в список вариант инвестиции.
        /// Получает данные из формы создания варианта.
        /// </summary>
        /// <param name="name"> Название варианта инвестиции. </param>
        /// <param name="amount"> Предполагаемое количество валюты. </param>
        /// <param name="currency"> Валюта, в которую предполагается инвестировать. </param>
        /// <param name="period"> Период в днях, по окончанию которого предполагается продать купленную валюту. </param>
        public void AddInvestment(string name, decimal amount, CurrencyType currency, int period)
        {
            Invs.Add(new Investment(name, amount, currency, period, Calc));
        }

        /// <summary>
        /// Сортирует список вариантов в порядке убывания их предполагаемой прибыли.
        /// </summary>
        public void GetBestOptions()
        {
            Invs = Invs.OrderByDescending(inv => inv.ProceedsEstimate).ToList();
        }
    }
}
