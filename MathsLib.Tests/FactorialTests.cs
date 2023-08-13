using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class FactorialTests
    {
        [TestMethod]
        public void ValidValues()
        {
            Assert.AreEqual(1L, ML.Math.Factorial(0L)); // 0! == 1 by definition
            Assert.AreEqual(1L, ML.Math.Factorial(1L));
            Assert.AreEqual(2L, ML.Math.Factorial(2L));
            Assert.AreEqual(6L, ML.Math.Factorial(3L));
            Assert.AreEqual(4L * 3L * 2L, ML.Math.Factorial(4L));
            Assert.AreEqual(10L * 9L * 8L * 7L * 6L * 5L * 4L * 3L * 2L, ML.Math.Factorial(10L));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidValue()
        {
            ML.Math.Factorial(-1L);
        }
    }
}
