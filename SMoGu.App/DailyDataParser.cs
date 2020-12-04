using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SMoGu.App
{
    class DailyDataParser : IDataParser<Tuple<decimal, decimal, decimal, DateTime>>
    {
        private String finalDate;
        private String startDate;
        private List<decimal> listUSD;
        private List<decimal> listEUR;
        private List<decimal> listCNY;
        private List<DateTime> listDate;
        private static List<Tuple<string, CurrencyType>> IDS = new List<Tuple<string, CurrencyType>> 
        {
            Tuple.Create("R01235", CurrencyType.USD),
            Tuple.Create("R01239", CurrencyType.EUR),
            Tuple.Create("R01375", CurrencyType.CNY)
        };
         
        public DailyDataParser(TimeOptions duration)
        {
            var today = DateTime.Now;
            var final = today.Date;
            DateTime start;
            switch (duration)
            {
                case TimeOptions.One_Week:
                    {
                        start = today.AddDays(-9);
                        break;
                    }
                case TimeOptions.One_Month:
                    {
                        start = today.AddMonths(-1);
                        break;
                    }
                case TimeOptions.Three_Months:
                    {
                        start = today.AddMonths(-3);
                        break;
                    }
                case TimeOptions.Half_Year:
                    {
                        start = today.AddMonths(-6);
                        break;
                    }
                case TimeOptions.One_Year:
                    {
                        start = today.AddYears(-1);
                        break;
                    }
                default: throw new InvalidOperationException("Некорректный параметр из TimeOptions");
            }
            startDate = start.ToString().Split(' ')[0];
            finalDate = final.ToString().Split(' ')[0];
        }

        public Queue<Tuple<decimal, decimal, decimal, DateTime>> GetData()
        {
            var queue = new Queue<Tuple<decimal, decimal, decimal, DateTime>>();
            ParceData();
            for (int i=0; i < listDate.Count; i++)
                queue.Enqueue(Tuple.Create(listUSD[i], listEUR[i], listCNY[i], listDate[i]));
            return queue;
        }

        public void ParceData()
        {
            WebClient webClient = new WebClient();
            listUSD = new List<decimal>();
            listEUR = new List<decimal>();
            listCNY = new List<decimal>();
            listDate = new List<DateTime>();
            foreach (var ID in IDS)
                Parce(webClient, ID);
        }

        private void Parce(WebClient webClient, Tuple<string, CurrencyType> ID)
        {
            var URL = "https://cbr.ru/currency_base/dynamics/?UniDbQuery.Posted=True&UniDbQuery.mode=1&UniDbQuery." +
               "date_req1=&UniDbQuery.date_req2=&UniDbQuery.VAL_NM_RQ=" +
               ID.Item1 +
               "&UniDbQuery.From=" +
               startDate +
               "&UniDbQuery.To=" +
               finalDate;
            var data = webClient.DownloadString(URL);
            var collectionResults = System.Text.RegularExpressions.Regex.Matches(data, @"<td>([0-9]+\,[0-9]+)</td>");
            ParceHelper(collectionResults, ID);
            if (ID.Item2.Equals(CurrencyType.CNY))
                ParceDate(data);
        }

        private void ParceHelper(System.Text.RegularExpressions.MatchCollection collectionResults, Tuple<string, CurrencyType> ID)
        {
            var list = new List<decimal>();
            foreach (var e in collectionResults)
                list.Add(Decimal.Parse(e.ToString().Substring(4, 7)));
            switch (ID.Item2)
            {
                case CurrencyType.USD:
                    {
                        listUSD = list;
                        break;
                    }
                case CurrencyType.EUR:
                    {
                        listEUR = list;
                        break;
                    }
                case CurrencyType.CNY:
                    {
                        listCNY = list.Select(t => t > 30 ? t / 10 : t).ToList();
                        break;
                    }
                default: throw new ArgumentException();
            }
        }

        private void ParceDate(string data)
        {
            var collectionResults = System.Text.RegularExpressions.Regex.Matches(data, @"<td>([0-9]+\.[0-9]+\.[0-9]+)</td>");
            foreach (var e in collectionResults)
            {
                var date=e.ToString().Substring(4, 10);
                var parceDate = date.Split('.');
                listDate.Add(new DateTime(int.Parse(parceDate[2]), int.Parse(parceDate[1]), int.Parse(parceDate[0])));
            }
        }
    }
}
