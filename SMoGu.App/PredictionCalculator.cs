using System;
using System.Collections.Generic;
using System.Linq;
using static SMoGu.App.EquationSolver;

namespace SMoGu.App
{
    /// <summary>
    /// Калькулятор, прогнозирующий изменение курса валюты.
    /// </summary>
    public class PredictionCalculator
    {
        private static Random rnd = new Random();
        /// <summary>
        /// Исходные данные о курсе валют для прогнозирования.
        /// </summary>
        public ChartData RawData { get; private set; }
        /// <summary>
        /// Конструктор класса. 
        /// </summary>
        /// <param name="data"> Исходные данные. </param>
        public PredictionCalculator(ChartData data)
        {
            RawData = data;
        }

        /// <summary>
        /// Прогнозирует изменения курса валюты в течение указанного времени. 
        /// </summary>
        /// <param name="predictionCount"> Количество дней, для которого строится прогноз. </param>
        /// <param name="currency"> Выбранная валюта. </param>
        /// <returns> Список, состоящий из стоимости валюты на текущий день и на следующие predictionCount дней. </returns>
        public List<Tuple<decimal, DateTime>> PredictCurrencyValues(int predictionCount, CurrencyType currency)
        {
            var data = RawData.CreateNewTupleList(currency);
            var result = new List<Tuple<decimal, DateTime>>();
            result.Add(data[data.Count - 1]);

            // количество параметров, которые вычисляются для авторегрессии
            var paramsCount = data.Count / 2;
            var coefs = DetermineARCoefs(data, paramsCount);

            for (int i = 0; i < predictionCount; i++)
                result.Add(PredictNext(data, paramsCount, coefs));
            return result;
        }

        /// <summary>
        /// Прогнозирует изменения курса валюты на один день.
        /// Прогнозирование осуществляется на основе имеющихся данных о курсе валют
        /// с помощью авторегрессионной(AR) модели. 
        /// </summary>
        /// <param name="data"> Исходные данные. </param>
        /// <param name="paramsCount"> Количество параметров для AR-модели. </param>
        /// <param name="coefs"> Коэффициенты AR-модели. </param>
        /// <returns> Спрогнозированное значение. </returns>
        private static Tuple<decimal, DateTime> PredictNext(List<Tuple<decimal, DateTime>> data, int paramsCount, decimal[] coefs)
        {
            // константа
            decimal c = new decimal(0.0);
            // белый шум
            var whiteNoise = new decimal((rnd.NextDouble() * (1.0 + 1.0) - 1.0));
            var next = c + whiteNoise;
            var end = data.Count - 1;
            for (int i = 0; i < paramsCount; i++)
            {
                next += data[end - i].Item1 * coefs[i];
            }
            return Tuple.Create(next, data[end].Item2.AddDays(1));
        }

        /// <summary>
        /// Определяет коэффициенты AR-модели.
        /// </summary>
        /// <param name="data"> Исходные данные. </param>
        /// <param name="paramsCount"> Количество параметров для AR-модели. </param>
        /// <returns> Массив коэффициентов. </returns>
        private static decimal[] DetermineARCoefs(List<Tuple<decimal, DateTime>> data, int paramsCount)
        {
            double[] freeColumn = data.Skip(data.Count - paramsCount)
                                           .Select(e => (double)e.Item1)
                                        .Reverse()
                                           .ToArray();
            double[][] matrix = new double[paramsCount][];
            var end = data.Count - 2;
            for (int i = 0; i < paramsCount; i++)
            {
                matrix[i] = new double[paramsCount];
                for (int j = paramsCount - 1; j >= 0; j--)
                {
                    matrix[i][j] = (double)data[end - j - i].Item1;
                }
            }
            return GaussSolver(matrix, freeColumn).Select(e => (decimal)e).ToArray();
        }
    }
}