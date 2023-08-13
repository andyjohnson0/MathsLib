using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class AtanTests
    {
        [TestMethod]
        public void ValidValues()
        {
            for (var r = -4 * ML.Math.PI; r <= 4 * ML.Math.PI; r += ML.Math.PI * 0.1D)
            {

                Assert.AreEqual(System.Math.Atan(r), ML.Math.Atan(r), Tests.Delta);
            }
        }


        [TestMethod]
        public void OtherValue()
        {
            Assert.AreEqual(double.NaN, ML.Math.Atan(double.NaN));
            Assert.AreEqual(double.PositiveInfinity, ML.Math.Atan(double.PositiveInfinity));
            Assert.AreEqual(double.NegativeInfinity, ML.Math.Atan(double.NegativeInfinity));
        }
    }
}
