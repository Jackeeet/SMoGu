using System;
using System.Linq;

namespace SMoGu.App
{
    /// <summary>
    /// Класс, предоставляющий методы для решения системы уравнений методом Гаусса.
    /// </summary>
    public class EquationSolver
    {
        /// <summary>
        /// Решает систему уравнений методом Гаусса.
        /// </summary>
        /// <param name="matrix"> Матрица коэффициентов уравнения. </param>
        /// <param name="freeColumn"> Столбец свободных членов. </param>
        /// <returns> Массив решений уравнения. </returns>
        public static double[] RunGaussSolver(double[][] matrix, double[] freeColumn)
        {
            var variableCount = matrix[0].Length;
            var augmented = matrix.Select(row =>
                                          row.Append(freeColumn[Array.IndexOf(matrix, row)])
                                             .ToArray())
                                  .ToArray();

            ModifyMatrix(augmented);
            return GetAnswer(augmented, variableCount);
        }

        /// <summary>
        /// Определяет решение системы уравнений из расширенной матрицы, 
        /// приведенной к ступенчатому виду.
        /// </summary>
        /// <param name="augmented"> Расширенная матрица. </param>
        /// <param name="varCount"> Количество переменных. </param>
        /// <returns> Массив решений уравнения. </returns>
        private static double[] GetAnswer(double[][] augmented, int varCount)
        {
            var answer = new double[varCount];
            if (SolutionExists(augmented, varCount))
            {
                var rowCount = augmented.Length;
                var markedRows = new bool[rowCount];

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
            }
            else
            {
                var baseCoef = 0.5;
                for (int i = 0; i < varCount; i++)
                    answer[i] = Math.Pow(baseCoef, i + 1);
            }
            return answer;
        }
        /// <summary>
        /// Проверяет, имеет ли система решение. 
        /// </summary>
        /// <param name="augmented"> Расширенная матрица. </param>
        /// <param name="varCount"> Количество переменных. </param>
        /// <returns> True, если решение существует. </returns>
        public static bool SolutionExists(double[][] augmented, int varCount)
        {
            foreach (var a in augmented)
            {
                var divisors = a.Take(varCount)
                                .Where(ai => ai != 0);
                if (divisors.Count() == 0 && a.Last() != 0)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Приводит расширенную матрицу к ступенчатому виду.
        /// </summary>
        /// <param name="augmented"> Расширенная матрица. </param>
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
        /// <summary>
        /// Преобразует одну строку матрицы.
        /// </summary>
        /// <param name="modifying"> Строка, в которой содержится ненулевой элемент. </param>
        /// <param name="modified"> Строка, к которой применяется преобразование. </param>
        /// <param name="column"> Столбец, в котором находится ненулевой элемент. </param>
        /// <returns> Преобразованная строка матрицы. </returns>
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