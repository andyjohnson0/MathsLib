using System.Runtime.Intrinsics.X86;
using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class TanTests
    {
        [TestMethod]
        public void ValidValues()
        {
            for (var r = 0D; r <= ML.Math.PI / 2D; r += ML.Math.PI * 0.1D)
            {
                var d = ML.Math.RadToDeg(r);
                if (d != 90D && d != 270D)
                {
                    Assert.AreEqual(System.Math.Tan(r), ML.Math.Tan(r), Tests.Delta);
                }
            }
        }


        [TestMethod]
        public void OtherValue()
        {
            Assert.AreEqual(double.NaN, ML.Math.Tan(double.NaN));
            Assert.AreEqual(double.PositiveInfinity, ML.Math.Tan(double.PositiveInfinity));
            Assert.AreEqual(double.NegativeInfinity, ML.Math.Tan(double.NegativeInfinity));
        }
    }
}
