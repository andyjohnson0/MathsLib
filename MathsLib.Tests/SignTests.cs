using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class SignTests
    {
        [TestMethod]
        public void PositiveValues()
        {
            Assert.AreEqual(1, ML.Math.Sign(1e-8D));
            Assert.AreEqual(1, ML.Math.Sign(0.1D));
            Assert.AreEqual(1, ML.Math.Sign(1D));
            Assert.AreEqual(1, ML.Math.Sign(10D));
            Assert.AreEqual(1, ML.Math.Sign(double.PositiveInfinity));
        }


        [TestMethod]
        public void NegativeValues()
        {
            Assert.AreEqual(-1, ML.Math.Sign(-1e-8D));
            Assert.AreEqual(-1, ML.Math.Sign(-0.1D));
            Assert.AreEqual(-1, ML.Math.Sign(-1D));
            Assert.AreEqual(-1, ML.Math.Sign(-10D));
            Assert.AreEqual(-1, ML.Math.Sign(double.NegativeInfinity));
        }


        [TestMethod]
        public void ZeroValue()
        {
            Assert.AreEqual(0, ML.Math.Sign(0D));
        }


        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void InvaidValues()
        {
            ML.Math.Sign(double.NaN);
        }
    }
}
