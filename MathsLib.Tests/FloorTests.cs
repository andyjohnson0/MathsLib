using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class FloorTests
    {
        [TestMethod]
        public void PositiveValues()
        {
            Assert.AreEqual(System.Math.Floor(0.8D), ML.Math.Floor(0.8D));
            Assert.AreEqual(System.Math.Floor(1D),   ML.Math.Floor(1D));
            Assert.AreEqual(System.Math.Floor(1.8D), ML.Math.Floor(1.8D));
            Assert.AreEqual(System.Math.Floor(2D),   ML.Math.Floor(2D));
        }


        [TestMethod]
        public void ZeroValue()
        {
            Assert.AreEqual(System.Math.Floor(0D), ML.Math.Floor(0D));
        }


        [TestMethod]
        public void NegativeValues()
        {
            Assert.AreEqual(System.Math.Floor(-0.8D), ML.Math.Floor(-0.8D));
            Assert.AreEqual(System.Math.Floor(-1D),   ML.Math.Floor(-1D));
            Assert.AreEqual(System.Math.Floor(-1.8D), ML.Math.Floor(-1.8D));
            Assert.AreEqual(System.Math.Floor(-2D),   ML.Math.Floor(-2D));
        }


        [TestMethod]
        public void OtherValue()
        {
            Assert.AreEqual(double.NaN, ML.Math.Floor(double.NaN));
            Assert.AreEqual(double.NegativeInfinity, ML.Math.Floor(double.NegativeInfinity));
            Assert.AreEqual(double.PositiveInfinity, ML.Math.Floor(double.PositiveInfinity));
        }
    }
}
