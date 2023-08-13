using ML = uk.andyjohnson.MathsLib;

namespace uk.andyjohnson.MathsLib.Tests
{
    [TestClass]
    public class PowTests
    {
        [TestMethod]
        public void IntegerValues()
        {
            // Some whole numbers
            Tests.AreEqual(System.Math.Pow(5D, 10D), ML.Math.Pow(5D, 10D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(-5D, 10D), ML.Math.Pow(-5D, 10D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(5D, -10D), ML.Math.Pow(5D, -10D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(-5D, -10D), ML.Math.Pow(-5D, -10D), Tests.Delta7);
        }


        [TestMethod]
        public void FractionalValues()
        {
            // Some fractional numbers
            Tests.AreEqual(System.Math.Pow(5.7D, 10.7D), ML.Math.Pow(5.7D, 10.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(-5.7D, 10.7D), ML.Math.Pow(-5.7D, 10.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(5.7D, -10.7D), ML.Math.Pow(5.7D, -10.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(-5.7D, -10.7D), ML.Math.Pow(-5.7D, -10.7D), Tests.Delta7);

            // Some more fractional numbers 0<x<11
            Tests.AreEqual(System.Math.Pow(0.7D, 10.7D), ML.Math.Pow(0.7D, 10.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(-0.7D, 10.7D), ML.Math.Pow(-0.7D, 10.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(0.7D, -10.7D), ML.Math.Pow(0.7D, -10.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(-0.7D, -10.7D), ML.Math.Pow(-0.7D, -10.7D), Tests.Delta7);

            Tests.AreEqual(System.Math.Pow(0.7D, 0.7D), ML.Math.Pow(0.7D, 0.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(-0.7D, 0.7D), ML.Math.Pow(-0.7D, 0.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(0.7D, -0.7D), ML.Math.Pow(0.7D, -0.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(-0.7D, -0.7D), ML.Math.Pow(-0.7D, -0.7D), Tests.Delta7);

            // Mixed whole and fractional numbers
            Tests.AreEqual(System.Math.Pow(5D, 0.7D), ML.Math.Pow(5D, 0.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(-5D, 0.7D), ML.Math.Pow(-5D, 0.7D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(0.7D, -5D), ML.Math.Pow(0.7D, -5D), Tests.Delta7);
            Tests.AreEqual(System.Math.Pow(-0.7D, -5D), ML.Math.Pow(-0.7D, -5D), Tests.Delta7);
        }
    }
}
