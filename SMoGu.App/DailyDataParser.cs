using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;

namespace SMoGu.App
{
    /// <summary>
    /// Класс, обеспечивающий сбор данных о динамике курса валют.
    /// </summary>
    class DailyDataParser : IDataParser<Tuple<decimal, decimal, decimal, DateTime>>
    {
        /// <summary>
        /// Дата, по которой берется последнее значение валюты в этот день.
        /// </summary>
        private String finalDate;
        /// <summary>
        /// Начальная дата, с которой начинается парсинг валютных значений.
        /// </summary>
        private String startDate;
        /// <summary>
        /// Список значений доллара за определенный промежуток времени.
        /// </summary>
        private List<decimal> listUSD;
        /// <summary>
        /// Список значений евро за определенный промежуток времени.
        /// </summary>
        private List<decimal> listEUR;
        /// <summary>
        /// Список значений китайского юаня за определенный промежуток времени.
        /// </summary>
        private List<decimal> listCNY;
        /// <summary>
        /// Список дат, которым сопоставлены значения валют по этим датам.
        /// </summary>
        private List<DateTime> listDate;
        /// <summary>
        /// Список сопоставления уникального кода валюты на сайте ЦБ РФ и наименования валюты.
        /// </summary>
        private static List<Tuple<string, CurrencyType>> IDS = new List<Tuple<string, CurrencyType>> 
        {
            Tuple.Create("R01235", CurrencyType.USD),
            Tuple.Create("R01239", CurrencyType.EUR),
            Tuple.Create("R01375", CurrencyType.CNY)
        };

        /// <summary>
        /// Конструктор класса для заполнения значений требуемыми значениями по заданному параметру.
        /// </summary>
        /// <param name="duration"> Срок, на который нужно заполнить списки. </param>
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
        /// <summary>
        /// Метод, который из всех списков строит очередь, содержащую все значения сразу.
        /// </summary>
        /// <returns> Возвращает очередь, в которой все значения валют сопоставлены по дате. </returns>
        public Queue<Tuple<decimal, decimal, decimal, DateTime>> GetData()
        {
            var queue = new Queue<Tuple<decimal, decimal, decimal, DateTime>>();
            try
            {
                GetCBRData();
            }
            catch
            {
                ParseData();
            }
            for (int i = 0; i < listDate.Count; i++)
                queue.Enqueue(Tuple.Create(listUSD[i], listEUR[i], listCNY[i], listDate[i]));
            return queue;
        }
        /// <summary>
        /// Метод, заполняющий все списки данными с сайта.
        /// </summary>
        public void ParseData()
        {
            WebClient webClient = new WebClient();
            listUSD = new List<decimal>();
            listEUR = new List<decimal>();
            listCNY = new List<decimal>();
            listDate = new List<DateTime>();
            foreach (var ID in IDS)
                Parse(webClient, ID);
        }
        /// <summary>
        /// Метод - парсер данных с сайта ЦБ РФ по передаваемым критериям.
        /// </summary>
        /// <param name="webClient"> Веб-клиент, объект содержащий в себе методы для парсинга. </param>
        /// <param name="ID"> Уникальный идентификатор валюты, для которой производится парсинг. </param>
        private void Parse(WebClient webClient, Tuple<string, CurrencyType> ID)
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
            ParseHelper(collectionResults, ID);
            if (ID.Item2.Equals(CurrencyType.CNY))
                ParseDate(data);
        }
        /// <summary>
        /// Вспомогательный метод для парсинга, в котором определяется, какой список заполнять.
        /// </summary>
        /// <param name="collectionResults"> Список полученных значений с сайта. </param>
        /// <param name="ID"> Уникальный идентификатор валюты, для которой производится парсинг. </param>
        private void ParseHelper(System.Text.RegularExpressions.MatchCollection collectionResults, Tuple<string, CurrencyType> ID)
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
        /// <summary>
        /// Метод, который парсит даты для дальнейшего сопоставления их с курсами валют.
        /// </summary>
        /// <param name="data"> Код страницы в строковом представлении для дальнейшей обработки. </param>
        private void ParseDate(string data)
        {
            var collectionResults = System.Text.RegularExpressions.Regex.Matches(data, @"<td>([0-9]+\.[0-9]+\.[0-9]+)</td>");
            foreach (var e in collectionResults)
            {
                var date = e.ToString().Substring(4, 10);
                var parceDate = date.Split('.');
                listDate.Add(new DateTime(int.Parse(parceDate[2]), int.Parse(parceDate[1]), int.Parse(parceDate[0])));
            }
        }

        /// <summary>
        /// Собирает данные о курсах валют через веб-сервис ЦБР.
        /// </summary>
        private void GetCBRData()
        {
            listUSD = new List<decimal>();
            listEUR = new List<decimal>();
            listCNY = new List<decimal>();
            listDate = new List<DateTime>();

            // Подключение сервиса и запрос данных о курсе валют.
            var dailyInfo = new cbrDailyInfo.DailyInfo();
            // GetCursDynamic - метод веб-сервиса ЦБР для получения данных о динамике курса валют.
            var usdRows = dailyInfo.GetCursDynamic(DateTime.Parse(startDate), DateTime.Parse(finalDate), "R01235").Tables[0].Rows;
            var eurRows = dailyInfo.GetCursDynamic(DateTime.Parse(startDate), DateTime.Parse(finalDate), "R01239").Tables[0].Rows;
            var cnyRows = dailyInfo.GetCursDynamic(DateTime.Parse(startDate), DateTime.Parse(finalDate), "R01375").Tables[0].Rows;
            // Парсинг полученных данных и заполнение соответствующих списков.
            for (int i = 0; i < usdRows.Count; i++)
            {
                listUSD.Add(ParseCBRValues(usdRows[i]));
                listEUR.Add(ParseCBRValues(eurRows[i]));
                listCNY.Add(ParseCBRValues(cnyRows[i]));
                listDate.Add(DateTime.Parse(usdRows[i].ItemArray[0].ToString()));
            }
        }

        /// <summary>
        /// Достает стоимость единицы выбранной валюты из 
        /// указанного ряда в таблице данных. 
        /// </summary>
        /// <param name="row"> Ряд в таблице данных. </param>
        /// <returns> Значение курса валюты. </returns>
        private decimal ParseCBRValues(DataRow row) => new decimal(double.Parse(row.ItemArray[3].ToString()) / double.Parse(row.ItemArray[2].ToString()));
    }
}
