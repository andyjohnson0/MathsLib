using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class SinTests
    {
        [TestMethod]
        public void ValidValues()
        {
            // Tests roots and maxima/minim, and intermediate values from -4*PI to +4*PI
            for(var r = -4 * ML.Math.PI; r <= 4 * ML.Math.PI; r += ML.Math.PI * 0.1D)
            {
                Assert.AreEqual(System.Math.Sin(r), ML.Math.Sin(r), Tests.Delta);
            }
        }


        [TestMethod]
        public void OtherValue()
        {
            Assert.AreEqual(double.NaN, ML.Math.Sin(double.NaN));
            Assert.AreEqual(double.PositiveInfinity, ML.Math.Sin(double.PositiveInfinity));
            Assert.AreEqual(double.NegativeInfinity, ML.Math.Sin(double.NegativeInfinity));
        }
    }
}
