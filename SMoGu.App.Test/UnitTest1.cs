using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMoGu.App.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMainForm_ListBox()
        {
            var form = new MainForm();
            var testList = new List<string>();
            var rnd = new Random();
            for(var i=0; i<10000; i++)
            {
                testList.Add(i.ToString());
                form.listBoxInvestments.Items.Add(testList[i]);
            }

            Assert.AreEqual(10000, form.listBoxInvestments.Items.Count);
            Assert.AreEqual(true, form.listBoxInvestments.ScrollAlwaysVisible);
        }
    }
}
