using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class RoundTests
    {
        [TestMethod]
        public void RoundToWhole()
        {
            for (var n = -10D; n <= 10D; n += 0.1D)
            {
                Assert.AreEqual(System.Math.Round(n), ML.Math.Round(n), Tests.Delta);
            }
        }


        [TestMethod]
        public void RoundToNumDigits()
        {
            for (var n = -10D; n <= 10D; n += 0.1D)
            {
                for (var dp = 0; dp <= 10D; dp += 1)
                {
                    Assert.AreEqual(System.Math.Round(n, dp), ML.Math.Round(n, dp), Tests.Delta);
                }
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invalid()
        {
            ML.Math.Round(ML.Math.PI, -1);
        }
    }
}
