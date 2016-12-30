using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestClass]
   public class CalculatorOpTest
    {
        [TestMethod]
        public void ShouldAddReurnNineWhenPassFiveandFour()
        {
            CalculatorOp sut = new CalculatorOp();
            int result = sut.Add(5,4);
            Assert.AreEqual(9,result);
        }
        [TestMethod]
        public void ShouldMulReurnTwentyWhenPassFiveandFour()
        {
            CalculatorOp sut = new CalculatorOp();
            int result = sut.Mul(5, 4);
            Assert.AreEqual(20, result);
        }
    }
}
