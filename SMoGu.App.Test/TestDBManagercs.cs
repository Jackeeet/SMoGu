using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMoGu.App.Test
{
    [TestClass]
    class TestDBManagercs
    {
        [TestMethod]
        public void TestListBox()
        {
            var testForm = new MainForm();
            testForm.investments.AddInvestment("Text", 1000, CurrencyType.USD, 365);
            testForm.investments.AddInvestment("Text1", 10000, CurrencyType.CNY, 365);
            testForm.investments.AddInvestment("Text2", 100000, CurrencyType.EUR, 365);
            var save = new DBManager();
            save.SaveFile(testForm.investments);
            Assert.AreEqual(3, testForm.investments.Invs);
        }
    }
}
