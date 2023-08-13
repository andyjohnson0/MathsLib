using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class AbsTests
    {
        [TestMethod]
        public void PositiveValues()
        {
            Assert.AreEqual(System.Math.Abs(0.8D), ML.Math.Abs(0.8D));
            Assert.AreEqual(System.Math.Abs(1D), ML.Math.Abs(1D));
            Assert.AreEqual(System.Math.Abs(1.8D), ML.Math.Abs(1.8D));
            Assert.AreEqual(System.Math.Abs(2D), ML.Math.Abs(2D));
        }


        [TestMethod]
        public void ZeroValues()
        {
            Assert.AreEqual(System.Math.Abs(0D), ML.Math.Abs(0D));
        }


        [TestMethod]
        public void NegativeValues()
        {
            Assert.AreEqual(System.Math.Abs(-0.8D), ML.Math.Abs(-0.8D));
            Assert.AreEqual(System.Math.Abs(-1D), ML.Math.Abs(-1D));
            Assert.AreEqual(System.Math.Abs(-1.8D), ML.Math.Abs(-1.8D));
            Assert.AreEqual(System.Math.Abs(-2D), ML.Math.Abs(-2D));
        }
    }
}
