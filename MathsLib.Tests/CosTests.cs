using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class CosTests
    {
        [TestMethod]
        public void ValidValues()
        {
            // Tests roots and maxima/minim, and intermediate values from -45*PI to +4*PI
            for (var r = -4 * ML.Math.PI; r <= 4 * ML.Math.PI; r += ML.Math.PI * 0.1D)
            {
                Assert.AreEqual(System.Math.Cos(r), ML.Math.Cos(r), Tests.Delta);
            }
        }


        [TestMethod]
        public void OtherValue()
        {
            Assert.AreEqual(double.NaN, ML.Math.Cos(double.NaN));
            Assert.AreEqual(double.PositiveInfinity, ML.Math.Cos(double.PositiveInfinity));
            Assert.AreEqual(double.NegativeInfinity, ML.Math.Cos(double.NegativeInfinity));
        }
    }
}
