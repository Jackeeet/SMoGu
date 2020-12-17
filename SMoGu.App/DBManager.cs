using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SMoGu.App
{
    /// <summary>
    /// Класс, обеспечивающий сохранение данных.
    /// </summary>
    class DBManager
    {
        /// <summary>
        /// Сохраняет данные о созданных вариантах инвестиции
        /// в текстовый файл.
        /// </summary>
        /// <param name="invsForSave"> Список вариантов инвестиции. </param>
        public void SaveFile(Investments invsForSave)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            List<string> text = invsForSave.Invs.Select(i => (i.InvestmentName + "\n Валюта: " + i.Currency.ToString() + 
            "; Через " + i.PredictionPeriod + " дн. на счету будет " + Math.Round(i.ProceedsEstimate,2).ToString() + " Руб.; Процент риска " + Math.Round(i.RiskEstimate, 2) +
            "%; Доходность инвестиции: " + Math.Round(i.ProfitPercentage * 100, 2) + " Руб.").ToString()).ToList();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                foreach(var el in text)
                    streamWriter.WriteLine(el);
                streamWriter.Close();
                MessageBox.Show("Сохранение прошло успешно");
            }
        }
    }
}
