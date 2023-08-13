using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class CeilingTests
    {
        [TestMethod]
        public void PositiveValues()
        {
            Assert.AreEqual(System.Math.Ceiling(0.8D), ML.Math.Ceiling(0.8D));
            Assert.AreEqual(System.Math.Ceiling(1D),   ML.Math.Ceiling(1D));
            Assert.AreEqual(System.Math.Ceiling(1.8D), ML.Math.Ceiling(1.8D));
            Assert.AreEqual(System.Math.Ceiling(2D),   ML.Math.Ceiling(2D));
        }


        [TestMethod]
        public void ZeroValue()
        {
            Assert.AreEqual(System.Math.Ceiling(0D), ML.Math.Ceiling(0D));
        }


        [TestMethod]
        public void NegativeValues()
        {
            Assert.AreEqual(System.Math.Ceiling(-0.8D), ML.Math.Ceiling(-0.8D));
            Assert.AreEqual(System.Math.Ceiling(-1D),   ML.Math.Ceiling(-1D));
            Assert.AreEqual(System.Math.Ceiling(-1.8D), ML.Math.Ceiling(-1.8D));
            Assert.AreEqual(System.Math.Ceiling(-2D),   ML.Math.Ceiling(-2D));
        }


        [TestMethod]
        public void OtherValue()
        {
            Assert.AreEqual(double.NaN, ML.Math.Ceiling(double.NaN));
            Assert.AreEqual(double.NegativeInfinity, ML.Math.Ceiling(double.NegativeInfinity));
            Assert.AreEqual(double.PositiveInfinity, ML.Math.Ceiling(double.PositiveInfinity));
        }
    }
}
