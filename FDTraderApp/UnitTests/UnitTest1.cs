using System;
using System.Collections.Generic;
using FDTraderApp.Helpers;
using FDTraderApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SecurtiesDataCorrect()
        {
            List<Security> securities = Helpers.GetSecuritesData();

            Assert.AreEqual(3, securities.Count);
        }
    }
}