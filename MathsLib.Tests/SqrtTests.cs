using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class SqrtTests
    {
        [TestMethod]
        public void PositiveValues()
        {
            Assert.AreEqual(System.Math.Sqrt(0.7D),   ML.Math.Sqrt(0.7D),   Tests.Delta);
            Assert.AreEqual(System.Math.Sqrt(1D),     ML.Math.Sqrt(1D),     Tests.Delta);
            Assert.AreEqual(System.Math.Sqrt(1.7D),   ML.Math.Sqrt(1.7D),   Tests.Delta);
            Assert.AreEqual(System.Math.Sqrt(2D),     ML.Math.Sqrt(2D),     Tests.Delta);
            Assert.AreEqual(System.Math.Sqrt(2.7D),   ML.Math.Sqrt(2.7D),   Tests.Delta);

            Assert.AreEqual(System.Math.Sqrt(97.13D), ML.Math.Sqrt(97.13D), Tests.Delta);
            Assert.AreEqual(System.Math.Sqrt(678D),   ML.Math.Sqrt(678D),   Tests.Delta);
        }


        [TestMethod]
        public void ZeroValue()
        {
            Assert.AreEqual(System.Math.Sqrt(0D), ML.Math.Sqrt(0D));
        }


        [TestMethod]
        public void OtherValue()
        {
            Assert.AreEqual(double.NaN, ML.Math.Sqrt(double.NaN));
            Assert.AreEqual(double.PositiveInfinity, ML.Math.Sqrt(double.PositiveInfinity));
            // NegativeInfinity counts as negative
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeValues1()
        {
            ML.Math.Sqrt(-1D);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeValues2()
        {
            ML.Math.Sqrt(double.NegativeInfinity);
        }
    }
}
