using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class RadToDegTests
    {
        // Note that DegToRad is not implemented by System.Math

        [TestMethod]
        public void ValidValues()
        {
            Assert.AreEqual(0D, ML.Math.RadToDeg(0D));
            Assert.AreEqual(180D, ML.Math.RadToDeg(ML.Math.PI));
            Assert.AreEqual(360D, ML.Math.RadToDeg(ML.Math.PI * 2));

            // Tests roots and maxima/minim, and intermediate values from -4*PI to +4*PI
            for (var r = -4D * ML.Math.PI; r <= +4 * ML.Math.PI; r += ML.Math.PI * 0.1D)
            {
                var deg = r * (180D / ML.Math.PI);
                Assert.AreEqual(deg, ML.Math.RadToDeg(r), Tests.Delta);
            }
        }


        [TestMethod]
        public void OtherValue()
        {
            Assert.AreEqual(double.NaN, ML.Math.RadToDeg(double.NaN));
            Assert.AreEqual(double.PositiveInfinity, ML.Math.RadToDeg(double.PositiveInfinity));
            Assert.AreEqual(double.NegativeInfinity, ML.Math.RadToDeg(double.NegativeInfinity));
        }
    }
}
