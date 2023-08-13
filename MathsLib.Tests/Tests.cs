using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.andyjohnson.MathsLib.Tests
{
    public static class Tests
    {
        // Maximum allowed difference between MathsLib.Maths calculation and the equivalent using System.Maths.
        public const double Delta = 1E-10;
        public const double Delta7 = 1E-7;

        /// <summary>
        /// Extends Assert.AreEqual() to perform equivalance checks for double.NaN, double.NegativeInfinity,
        /// and double.PositiveInfinity. On failure also outputs expected and actual values, and actual delta.
        /// </summary>
        /// <param name="expected">Expected value.</param>
        /// <param name="actual">Actual value.</param>
        /// <param name="delta">Maximum allowed difference between expected and actual.</param>
        public static void AreEqual(double expected, double actual, double delta, string? msg = null)
        {
            if (double.IsNaN(expected) && double.IsNaN(actual))
                return;
            if (double.IsNegativeInfinity(expected) && double.IsNegativeInfinity(actual))
                return;
            if (double.IsPositiveInfinity(expected) && double.IsPositiveInfinity(actual))
                return;

            try
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual, delta);
            }
            catch (Exception)
            {
                Console.WriteLine($"AreEqual(expected:{expected}, actual:{actual}, delta:{delta}) failed");
                Console.WriteLine($"Actual delta was {System.Math.Abs(expected - actual)}");
                if (!string.IsNullOrEmpty(msg))
                {
                    Console.WriteLine($"Message: {msg}");
                }
                throw;
            }
        }
    }
}
