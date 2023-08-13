using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class DegToRadTests
    {
        // Note that DegToRad is not implemented by System.Math

        [TestMethod]
        public void ValidValues()
        {
            Assert.AreEqual(0D,             ML.Math.DegToRad(0D));
            Assert.AreEqual(ML.Math.PI,     ML.Math.DegToRad(180));
            Assert.AreEqual(2D* ML.Math.PI, ML.Math.DegToRad(360));

            for (var d = -720D; d <= +720D; d += 10D)
            {
                var r = d * (ML.Math.PI / 180D);
                Assert.AreEqual(r, ML.Math.DegToRad(d));
            }
        }


        [TestMethod]
        public void OtherValue()
        {
            Assert.AreEqual(double.NaN, ML.Math.DegToRad(double.NaN));
            Assert.AreEqual(double.PositiveInfinity, ML.Math.DegToRad(double.PositiveInfinity));
            Assert.AreEqual(double.NegativeInfinity, ML.Math.DegToRad(double.NegativeInfinity));
        }
    }
}
