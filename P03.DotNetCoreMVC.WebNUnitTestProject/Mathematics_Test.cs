using NUnit.Framework;
using P03.DotNetCoreMVC.Utility.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.WebNUnitTestProject
{
    [TestFixture]
    public class Mathematics_Test
    {
        [Test]
        public void Test_Divide()
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
