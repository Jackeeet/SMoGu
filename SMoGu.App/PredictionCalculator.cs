using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    public class PredictionCalculator
    {
        private static Random rnd = new Random();
        public ChartData RawData { get; private set; }

        public PredictionCalculator(ChartData data)
        {
            RawData = data;
        }

        // возвращает список, состоящий из сегодняшней стоимости валюты и предсказанную стоимость на predictionCount дней
        public List<Tuple<decimal, DateTime>> PredictCurrencyValues(int predictionCount, CurrencyType currency)
        {
            var data = RawData.CreateNewTupleList(currency);
            var result = new List<Tuple<decimal, DateTime>>();
            result.Add(data[data.Count-1]);

            // количество параметров, которые вычисляются для авторегрессии
            var paramsCount = data.Count / 2;
            var coefs = DetermineARCoefs(data, paramsCount);

            for (int i = 0; i < predictionCount; i++)
                result.Add(PredictNext(data, paramsCount, coefs));
            return result;
        }

        // тут короче авторегрессия (AR-модель)
        // по идее лучше бы использовать ARMA, но что-то я не понимаю, как сюда прикрутить скользящее среднее
        // если останется время, попробую прикрутить его тоже
        private static Tuple<decimal, DateTime> PredictNext(List<Tuple<decimal, DateTime>> data, int paramsCount, decimal[] coefs)
        {
            // константа
            decimal c = new decimal(0.0);
            // шум - по идее надо использовать нормальное распределение, но чет сложно
            var whiteNoise = new decimal((rnd.NextDouble() * (1.0 + 1.0) - 1.0));
            var next = c + whiteNoise;
            var end = data.Count - 1;
            for (int i = 0; i < paramsCount; i++)
            {
                next += data[end - i].Item1 * coefs[i];
            }
            return Tuple.Create(next, data[end].Item2.AddDays(1));
        }


        // создаем систему уравнений для определения коэффициентов и вызываем решатель Гаусса
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
            return Solve(matrix, freeColumn).Select(e => (decimal)e).ToArray();
        }

        // решатель системы уравнений методом Гаусса
        private static double[] Solve(double[][] matrix, double[] freeColumn)
        {
            var variableCount = matrix[0].Length;
            var augmented = matrix.Select(row =>
                                          row.Append(freeColumn[Array.IndexOf(matrix, row)])
                                             .ToArray())
                                  .ToArray();

            ModifyMatrix(augmented);
            return GetAnswer(augmented, variableCount);
        }


        // куча вспомогательных методов
        private static double[] GetAnswer(double[][] augmented, int varCount)
        {
            CheckIfSolutionExists(augmented, varCount);
            var rowCount = augmented.Length;
            var markedRows = new bool[rowCount];
            var answer = new double[varCount];
            for (int col = 0; col < varCount; col++)
            {
                int row = 0;
                for (; row < rowCount; row++)
                    if (augmented[row][col] != 0 && !markedRows[row])
                    {
                        markedRows[row] = true;
                        answer[col] = augmented[row].Last() / augmented[row][col];
                        break;
                    }
            }
            return answer;
        }

        private static void CheckIfSolutionExists(double[][] augmented, int rowLength)
        {
            foreach (var a in augmented)
            {
                var divisors = a.Take(rowLength)
                                .Where(ai => ai != 0);
                if (divisors.Count() == 0 && a.Last() != 0)
                    throw new ArgumentException("No solution");
            }
        }

        private static void ModifyMatrix(double[][] augmented)
        {
            var rowCount = augmented.Length;
            var variableCount = augmented[0].Length - 1;
            var markedRows = new bool[rowCount];

            for (int col = 0; col < variableCount; col++)
            {
                int row = 0;
                for (; row < rowCount; row++)
                    if (augmented[row][col] != 0 && !markedRows[row])
                    {
                        markedRows[row] = true;
                        break;
                    }

                for (int newRow = 0; newRow < rowCount && row < rowCount; newRow++)
                    if (newRow != row)
                        augmented[newRow] = ModifyLine(augmented[row], augmented[newRow], col);
            }
        }

        private static double[] ModifyLine(double[] modifying, double[] modified, int column)
        {
            var multiplier = -1 * modified[column] / modifying[column];

            var newModifying = ((double[])modifying.Clone()).Select(m => m * multiplier)
                                                            .ToArray();
            return modified.Zip(newModifying, (item1, item2) => item1 + item2)
                           .ToArray();
        }


    }
}

// старая версия на очередях, пусть полежит на всякий случай
//private static decimal[] DetermineARCoefs(Queue<Tuple<decimal, DateTime>> data, int paramsCount)
//{
//    double[] freeColumn = data.Skip(data.Count - paramsCount)
//                               .Select(e => (double)e.Item1)
//                               .ToArray();
//    double[][] matrix = new double[paramsCount][];
//    var dataEnd = data.Tail;
//    for (int i = 0; i < paramsCount; i++)
//    {
//        matrix[i] = GetEquation(dataEnd, paramsCount);
//        dataEnd = dataEnd.Previous;
//    }
//    return Solve(matrix, freeColumn).Select(e => (decimal)e).ToArray();
//}

//private static double[] GetEquation(QueueItem<Tuple<decimal, DateTime>> end, int paramsCount)
//{
//    var result = new double[paramsCount];
//    for (int i = paramsCount - 1; i >= 0; i--)
//    {
//        result[i] = (double)end.Value.Item1;
//        end = end.Previous;
//    }
//    return result;
//}