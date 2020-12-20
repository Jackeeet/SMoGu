using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SMoGu.App.Test
{
    [TestClass]
    public class PredictionCalcTests
    {
        [TestMethod]
        public void CalcDeterminesCoefs()
        {
            var data = new List<Tuple<decimal, DateTime>>
            {
                Tuple.Create(76.7600m, DateTime.Now.AddDays(-3)),
                Tuple.Create(75.8146m, DateTime.Now.AddDays(-2)),
                Tuple.Create(75.4727m, DateTime.Now.AddDays(-1)),
                Tuple.Create(75.4518m, DateTime.Now)
            };

            MethodInfo modifier = typeof(PredictionCalculator).GetMethod("DetermineARCoefs", BindingFlags.Static | BindingFlags.NonPublic);
            var coefs = (decimal[])modifier.Invoke(null, new object[] { data, 2 });
            var expected = new[] { 1.535m, -0.533m };
            Assert.AreEqual((double)expected[0], (double)coefs[0], 10e-4);
            Assert.AreEqual((double)expected[1], (double)coefs[1], 10e-4);
        }
    }
}