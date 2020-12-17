using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMoGu.App.Test
{
    [TestClass]
    public class TestDBManagercs
    {
        [TestMethod]
        //Проверка того, что после сохранения инвестций в файл, 
        //они не исчезают из их изначального места хранения.
        public void TestInvestmenAfterSave()
        {
            var testForm = new MainForm();
            var queue = new ChartData(TimeOptions.Half_Year);
            var queueItems = queue.CreateNewTupleList(CurrencyType.EUR);
            testForm.investments.SetCalc(queue);
            testForm.investments.AddInvestment("Text", 1000, CurrencyType.USD, 365);
            testForm.investments.AddInvestment("Text1", 10000, CurrencyType.CNY, 365);
            testForm.investments.AddInvestment("Text2", 100000, CurrencyType.EUR, 365);
            var save = new DBManager();
            //сохранение данных в файл
            save.SaveFile(testForm.investments);
            Assert.AreEqual(3, testForm.investments.Invs.Count);
        }
        //Проверка на способность сохранения файлов большого потока данных
        [TestMethod]
        public void TestOnBigFile()
        {
            try
            {
                var testForm = new MainForm();
                var queue = new ChartData(TimeOptions.Half_Year);
                var queueItems = queue.CreateNewTupleList(CurrencyType.EUR);
                testForm.investments.SetCalc(queue);
                var rnd = new Random();
                for (var i = 0; i < 1000; i++)
                    testForm.investments.AddInvestment("i", rnd.Next(100000), CurrencyType.USD, 365);
                var save = new DBManager();
                //сохранение данных в файл
                save.SaveFile(testForm.investments);
                Assert.AreEqual(true, true);
            }
            catch
            {
                Assert.AreEqual(true, false);
            }
        }
    }
}
