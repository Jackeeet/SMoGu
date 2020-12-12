using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMoGu.App
{
    /// <summary>
    /// Класс, в котором есть методы для создания текстого файла, хранящего данные об инвестициях
    /// </summary>
    class DataBaseCreator
    {
        /// <summary>
        /// путь до текстового файла
        /// </summary>
        private string path = @"\DataBase.txt";
        /// <summary>
        /// поле, хранящее информацию об инвестициях в строковом представлении
        /// </summary>
        private List<string> inv;
        /// <summary>
        /// заголовок текстового документа
        /// </summary>
        private string name = "Наименование инвестиции: ВАЛЮТА; Прибыль; Риски; Доходность";
        /// <summary>
        /// метод, записывающий данные об инвестициях в текстовый документ DataBase.txt
        /// </summary>
        public void CreateDataBase()
        {
            /*var pathDialog = new FolderBrowserDialog();
            if (pathDialog.ShowDialog() == DialogResult.OK)
                path = pathDialog.SelectedPath;//Путь к директории*/

            var investments = new Investments();
            CreateListInvestments(investments.invs);
            var writer = new StreamWriter(path, false, Encoding.Default);
            writer.WriteLine(name);
            foreach (var investment in inv)
                writer.WriteLine(investment);
            writer.Close();
        }
        /// <summary>
        /// метод, заполняющий список, хранящий данные об инвестициях в формате строк 
        /// </summary>
        /// <param name="investments"> список инвестиций в первоначальном представлении </param>
        private void CreateListInvestments(List<Investment> investments)
        {
            inv = investments.Select(i => i.InvestmentName + ": " + i.Currency.ToString() + "; " + 
            i.ProceedsEstimate.ToString() +"; " + Math.Round(i.RiskEstimate*100, 2) + 
            "%; " + Math.Round(i.ProfitPercentage*100, 2) + ".").ToList();
        }
    }
}
