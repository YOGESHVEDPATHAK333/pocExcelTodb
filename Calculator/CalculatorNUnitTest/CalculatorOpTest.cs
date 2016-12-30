using Calculator;
using NUnit.Framework;

namespace CalculatorNUnitTest
{
    [TestFixture]
    public class CalculatorOpTest
    {
        [Test]
        public void ShouldAddReurnNineWhenPassFiveandFour()
        {
            CalculatorOp sut = new CalculatorOp();
            int result = sut.Add(5, 4);
            Assert.That(result,Is.EqualTo (9));
        }
        [Test]
        public void ShouldMulReurnNineWhenPassFiveandFour()
        {
            CalculatorOp sut = new CalculatorOp();
            int result = sut.Add(5, 4);
            Assert.That(result, Is.EqualTo(20));
        }
    }
}
