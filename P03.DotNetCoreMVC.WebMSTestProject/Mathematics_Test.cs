using Microsoft.VisualStudio.TestTools.UnitTesting;
using P03.DotNetCoreMVC.Utility.WebHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.WebMSTestProject
{
    [TestClass]
    public class Mathematics_Test
    {
        [TestMethod]
        public void Test_Divide()
        {
            var expectValue = 5;
            var dividend = 10;
            var divisor = 2;

            //
            int actuallValue = Mathematics.Divide(dividend, divisor);

            Assert.AreEqual(expectValue, actuallValue);
        }



        [TestMethod]
        public void Divide_PositiveNumbers_ReturnsPositiveQuotient()
        {
            var expectValue = 5;
            var dividend = 10;
            var divisor = 2;

            //
            int actuallValue = Mathematics.Divide(dividend, divisor);

            Assert.AreEqual(expectValue, actuallValue);

        }

    }
}
