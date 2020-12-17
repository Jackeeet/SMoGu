using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMoGu.App.Test
{
    [TestClass]
    public class MainFormTests
    {
        [TestMethod]
        public void TestListBox()
        {
            var form = new MainForm();
            var testList = new List<string>();
            for (var i = 0; i < 10000; i++)
            {
                testList.Add(i.ToString());
                form.listBoxInvestments.Items.Add(testList[i]);
            }

            Assert.AreEqual(10000, form.listBoxInvestments.Items.Count);
            Assert.AreEqual(true, form.listBoxInvestments.ScrollAlwaysVisible);

        }

        [TestMethod]
        public void TestAllButtonOnLoadMainForm()
        {
            var testForm = new MainForm();
            //изначально эти кнопки должны быть выключены
            Assert.AreEqual(false, testForm.buttonSave.Enabled);
            Assert.AreEqual(false, testForm.buttonForCreateGrafic.Enabled);
            Assert.AreEqual(false, testForm.buttonForCreateInvestment.Enabled);

            testForm.radioButton1.Checked = true; //выбираем валюту доллара
            testForm.radioButtonOneYear.Checked = true; //выбираем период год
            Assert.AreEqual(true, testForm.buttonForCreateGrafic.Enabled);
            testForm.CreateGrafic();//строим график
            Assert.AreEqual(true, testForm.buttonForCreateInvestment.Enabled);

            //закидываем инвестции
            testForm.investments.AddInvestment("Text", 1000, CurrencyType.USD, 365);
            testForm.investments.AddInvestment("Text1", 10000, CurrencyType.CNY, 365);
            testForm.investments.AddInvestment("Text2", 100000, CurrencyType.EUR, 365);
            Assert.AreEqual(false, testForm.buttonSort.Enabled);
            //кнопка не включается, потому что листбокс не пополнен
        }
        [TestMethod]
        public void TestRadioButton()
        {
            var test = new MainForm();
            test.radioButton1.Checked = true;
            test.radioButtonHalfYear.Checked = true;
            //проверка, что одна радиокнопка не выключает другую кнопку другого происхождения
            Assert.AreEqual(true, test.radioButtonHalfYear.Checked);
        }

        [TestMethod]
        public void TestCheckedCurrency()
        {
            var test = new MainForm();
            test.radioButton1.Checked = true;
            Assert.AreEqual(CurrencyType.USD, test.CheckedCurrency());
        }
    }
}
