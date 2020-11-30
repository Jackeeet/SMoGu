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
                default: throw new InvalidOperationException("чет не то попало в блок switch, надо бы проверить что за дрянь сюда залезла");
            }
            startDate = start.ToString().Split(' ')[0];
            finalDate = final.ToString().Split(' ')[0];
        }

        public Queue<Tuple<decimal, decimal, decimal, DateTime>> getData()
        {
            var queue = new Queue<Tuple<decimal, decimal, decimal, DateTime>>();
            parceData();
            for (int i=0; i < listDate.Count; i++)
                queue.Enqueue(Tuple.Create(listUSD[i], listEUR[i], listCNY[i], listDate[i]));
            return queue;
        }

        public void parceData()
        {
            WebClient webClient = new WebClient();
            parceUSD(webClient);
            parceEUR(webClient);
            parceCNY_AndDate(webClient);
        }

        private void parceUSD(WebClient webClient)
        {
            listUSD = new List<decimal>();
            var URL = "https://cbr.ru/currency_base/dynamics/?UniDbQuery.Posted=True&UniDbQuery.mode=1&UniDbQuery." +
               "date_req1=&UniDbQuery.date_req2=&UniDbQuery.VAL_NM_RQ=R01235&UniDbQuery.From=" +
               startDate +
               "&UniDbQuery.To=" +
               finalDate;
            var data = webClient.DownloadString(URL);
            var collectionResults = System.Text.RegularExpressions.Regex.Matches(data, @"<td>([0-9]+\,[0-9]+)</td>");
            foreach (var e in collectionResults)
                listUSD.Add(Decimal.Parse(e.ToString().Substring(4, 7)));
        }

        private void parceEUR(WebClient webClient)
        {
            listEUR = new List<decimal>();
            var URL = "https://cbr.ru/currency_base/dynamics/?UniDbQuery.Posted=True&UniDbQuery.mode=1&UniDbQuery." +
                "date_req1=&UniDbQuery.date_req2=&UniDbQuery.VAL_NM_RQ=R01239&UniDbQuery.From=" +
               startDate +
               "&UniDbQuery.To=" +
               finalDate;
            var data = webClient.DownloadString(URL);
            var collectionResults = System.Text.RegularExpressions.Regex.Matches(data, @"<td>([0-9]+\,[0-9]+)</td>");
            foreach (var e in collectionResults)
                listEUR.Add(Decimal.Parse(e.ToString().Substring(4, 7)));
        }

        private void parceCNY_AndDate(WebClient webClient)
        {
            listCNY = new List<decimal>();
            var URL = "https://cbr.ru/currency_base/dynamics/?UniDbQuery.Posted=True&UniDbQuery.mode=1&UniDbQuery." +
                "date_req1=&UniDbQuery.date_req2=&UniDbQuery.VAL_NM_RQ=R01375&UniDbQuery.From=" +
               startDate +
               "&UniDbQuery.To=" +
               finalDate;
            var data = webClient.DownloadString(URL);
            var collectionResults = System.Text.RegularExpressions.Regex.Matches(data, @"<td>([0-9]+\,[0-9]+)</td>");
            foreach (var e in collectionResults)
            {
                var cny = Decimal.Parse(e.ToString().Substring(4, 7));
                listCNY.Add(cny > 30 ? cny/10 : cny);
            }
            parceDate(data);
        }

        private void parceDate(string data)
        {
            listDate = new List<DateTime>(); 
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
