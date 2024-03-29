﻿using NUnit.Framework;
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
            //Arrange
            var expectValue = 5;
            var dividend = 10;
            var divisor = 2;

            //Act
            int actuallValue = Mathematics.Divide(dividend, divisor);

            //Assert
            Assert.AreEqual(expectValue, actuallValue);
        }



        [Test]
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
