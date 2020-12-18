using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App.Test
{

    [TestClass]
    public class DataParserTests
    {
        [TestMethod]
        //проверка на правильность работы парсера данных с сайта ЦБ РФ
        public void CorrectWorkingDataParser()
        {
            var data = new Queue<Tuple<decimal, decimal, decimal, DateTime>>();
            data.Enqueue(Tuple.Create((decimal)73.6618, (decimal)89.2044, (decimal)11.2752, new DateTime(2020, 12, 9, 1, 0, 0)));
            data.Enqueue(Tuple.Create((decimal)73.3057, (decimal)88.9418, (decimal)11.2126, new DateTime(2020, 12, 10, 1, 0, 0)));
            data.Enqueue(Tuple.Create((decimal)73.7124, (decimal)89.1330, (decimal)11.2578, new DateTime(2020, 12, 11, 1, 0, 0)));
            data.Enqueue(Tuple.Create((decimal)73.1195, (decimal)88.7744, (decimal)11.1778, new DateTime(2020, 12, 12, 1, 0, 0)));
            data.Enqueue(Tuple.Create((decimal)72.9272, (decimal)88.5847, (decimal)11.1557, new DateTime(2020, 12, 15, 1, 0, 0)));
            data.Enqueue(Tuple.Create((decimal)73.4453, (decimal)89.1846, (decimal)11.2219, new DateTime(2020, 12, 16, 1, 0, 0)));
            data.Enqueue(Tuple.Create((decimal)73.4201, (decimal)89.3229, (decimal)11.2310, new DateTime(2020, 12, 17, 1, 0, 0)));
            data.Enqueue(Tuple.Create((decimal)72.9781, (decimal)89.2887, (decimal)11.1693, new DateTime(2020, 12, 18, 1, 0, 0)));

            var parser = new DailyDataParser(TimeOptions.One_Week);
            var testData = parser.GetData();
            for (int i=0; i<testData.Count; i++)
            {
                Assert.AreEqual(data.Dequeue(), testData.Dequeue());
            }
        }

    }
}
