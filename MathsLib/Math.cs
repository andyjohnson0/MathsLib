namespace uk.andyjohnson.MathsLib
{
    /// <summary>
    /// Standalone implementation of some of the standard System.Math api.
    /// Originally developed for the .net Micro Framework.
    /// This implementation prioritises simplicity and portability over performance. System.Math will always be faster.
    /// Trancendental trigonometric functions are calculated using Taylor series (ee http://mathonweb.com/help_ebook/calc_funcs.htm).
    /// Square root is calculated using Newton's method.
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// Base of the natural logarithm,
        /// </summary>
        public const double E = 2.7182818284590451D;

        /// <summary>
        /// Ratio of a circle's circumference to its diameter.
        /// </summary>
        public const double PI = 3.1415926535897931D;

        /// <summary>
        /// PI * 2.
        /// Usefu for trigonometric calculations involving radians. If you don't believe me see http://tauday.com/.
        /// </summary>
        public const double Tau = 2.0D * PI;


        private const double piOver2 = PI / 2.0D;
        private const double piOver4 = PI / 4.0D;
        private const double piOver8 = PI / 8.0D;

        private const double deg360Over2 = 360D / 2D;


        /// <summary>
        /// Returns the Sine of the specified angle.
        /// </summary>
        /// <param name="d">Angle in radians.</param>
        /// <returns>
        /// Sine of the specified angle.
        /// If d is equal to System.Double.NaN, System.Double.NegativeInfinity, or System.Double.PositiveInfinity, then that value is returned.
        /// </returns>
        public static double Sin(double d)
        {
            if (double.IsNaN(d) || double.IsNegativeInfinity(d) || double.IsPositiveInfinity(d))
                return d;

            // Normalise input to range 0<=x<Tau
            while (d >= Tau)
            {
                d -= Tau;
            }
            while (d < 0)
            {
                d += Tau;
            }

            // Now d >= 0 && d < Tau
            // Mirror about pi and remember to negate result if necessary.
            var p = +1.0D;
            if (d >= PI)
            {
                d -= PI;
                p = -1.0D;
            }

            // Now d >= 0 && d < PI
            // Mirror about pi/2.
            if (d > piOver2)
            {
                d = piOver2 - (d - piOver2);
            }

            // Now d >= 0 && d < pi/22
            // Taylor series:
            //   sin(x) = x - (x^3)/3! + (x^5)/5! - ......
            var sgn = +1D;
            var fac = 1D;
            var sin = 0D;
            for (var i = 1; i <= 20; i = i + 2)
            {
                var t = sgn * (Pow(d, i) / fac);
                sin = sin + t;

                fac = fac * (i + 1) * (i + 2);
                sgn = -sgn;
            }

            return sin * p;
        }


        /// <summary>
        /// Returns the Cosine of the specified angle.
        /// </summary>
        /// <param name="d">Angle in radians.</param>
        /// <returns>
        /// Cosine of the specified angle.
        /// If d is equal to System.Double.NaN, System.Double.NegativeInfinity, or System.Double.PositiveInfinity, then that value is returned.
        /// </returns>
        public static double Cos(double d)
        {
            if (double.IsNaN(d) || double.IsNegativeInfinity(d) || double.IsPositiveInfinity(d))
                return d;

            // Normalise input to range 0<=x<Tau
            while (d >= Tau)
            {
                d -= Tau;
            }
            while (d < 0)
            {
                d += Tau;
            }

            // Now d >= 0 && d < Tau
            // Mirror about Pi.
            if (d > PI)
            {
                d = PI - (d - PI);
            }

            // Now d >= 0 && d < PI
            // Mirror about PI/2 and remember to negate result if necessary
            var p = +1.0D;
            if (d > piOver2)
            {
                d = piOver2 - (d - piOver2);
                p = -1.0D;
            }

            // Now d >= 0 && d < pi/2
            // Taylor series:
            //   cos(x) = 1 + (x^2)/2! - (x^4)/4! + ... + 
            var sgn = -1D;
            var fac = 2D;
            var cos = 1D;
            for (var i = 2; i <= 20; i = i + 2)
            {
                var t = sgn * (Pow(d, i) / fac);
                cos = cos + t;

                fac = fac * (i + 1) * (i + 2);
                sgn = -sgn;
            }

            return cos * p;
        }


        /// <summary>
        /// Returns the Tangent of the specified angle.
        /// </summary>
        /// <param name="d">Angle in radians.</param>
        /// <returns>Tangent of the specified angle.</returns>
        public static double Tan(double d)
        {
            if (double.IsNaN(d) || double.IsNegativeInfinity(d) || double.IsPositiveInfinity(d))
                return d;

            // We don't need to deal with the asymptotoes at pi/2 and 3pi/2 as these
            // values are not representable as doubles.

            // Use simple trig identity.
            return Sin(d) / Cos(d);


            /**********

            Another way to do this is to use the Taylor series for Tan(d) in the region 0 <= d <= pi/2.
            However this only seems to give accuracy to 2dp, even with 9 terms.

            // Map to 0 <= d <= 2pi
            var m = (long)(d / Tau);
            d -= (m * Tau);

            // Now 0 <= d <= 2pi
            if (d >= PI)
                d -= PI;

            // Now 0 <= d <= pi
            if (d >= piOver2)
                d -= piOver2;

            // Now 0 <= d <= pi/2
            // Taylor series:
            //   tan(x) = x + (1/3 x^3) + (2/15 x^5) + (17/315 x^7) + (62/2835 x^9) + (1382/155925 x^11) + (21844/6081075 x^13) + (929569/638512875 x^15) +
            //                (6404582/10854718875 x^17) + (443861162/1856156927625 x^19)
            var tan = d +
                      (1D / 3D) * Pow(d, 3) +
                      (2D / 15D) * Pow(d, 5) +
                      (62D / 2835D) * Pow(d, 9) +
                      (1382D / 155925D) * Pow(d, 11) +
                      (21844D / 6081075D) * Pow(d, 13) +
                      (929569D / 638512875D) * Pow(d, 15) +
                      (6404582D / 10854718875D) * Pow(d, 17) +
                      (443861162D / 1856156927625D) * Pow(d, 19);
            return tan;

            **********/
        }


        /// <summary>
        /// Returns the Arctangent (inverse tangent) of the specified angle.
        /// </summary>
        /// <param name="d">Angle in radians.</param>
        /// <returns>Arctangent of the specified angle.</returns>
        public static double Atan(double d)
        {
            if (double.IsNaN(d) || double.IsNegativeInfinity(d) || double.IsPositiveInfinity(d))
                return d;

            if (d < 0)
            {
                return -Atan(-d);
            }

            // Now d >= 0.0D
            if (d > 1.0D)
            {
                return piOver2 - Atan(1.0D / d);
            }

            // Now d <= 1.0D
            const double n = 0.268D; // 2-sqrt(3)
            if (d > n)
            {
                const double sqrt3 = 1.73205080757D;
                return (PI / 6.0D) + Atan(((sqrt3 * d) - 1) / (sqrt3 + d));
            }

            // Now d <= n
            double sgn = -1.0D;
            double s = d;
            for (var i = 3; i <= 20; i = i + 2)
            {
                double t = sgn * (Pow(d, i) / (double)i);
                s = s + t;
                sgn = -sgn;
            }

            return s;
        }


        /// <summary>
        /// Returns the square root of the specified number, calculated using Newton's method.
        /// </summary>
        /// <param name="d">A number, which must be >= 0</param>
        /// <returns>
        /// The square root of the spcified number.
        /// If d is equal to System.Double.NaN or System.Double.PositiveInfinity, then that value is returned.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">Argument must be >= 0</exception>
        public static double Sqrt(double d)
        {
            if (double.IsNaN(d) || double.IsPositiveInfinity(d))
                return d;
            if (d < 0)
                throw new System.ArgumentOutOfRangeException(nameof(d), "Value must be >= 0");
            if (d == 0D)
                return 0D;

            const double delta = 0.0000000001D;

            // Algorithm:
            // x <- 0.5(x + d/x)

            var x = d;
            while(true)
            {
                var x2 = 0.5D * (x + (d / x));
                if (Abs(x2 - x) < delta)
                    return x2;
                x = x2;
            }
        }


        /// <summary>
        /// Returns the absolute value of the specified number.
        /// </summary>
        /// <param name="d">A number.</param>
        /// <returns>The absolute value of the specified number.</returns>
        public static double Abs(double d)
        {
            return (d >= 0D) ? d : -d;
        }


        /// <summary>
        /// Returns the factorial of the specified number.
        /// </summary>
        /// <param name="n">A number. Must be grater than or equal to zero.</param>
        /// <returns>The factorial of the specified number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The argument must be greater than or equal to zero.</exception>
        public static long Factorial(long n)
        {
            if (n < 0)
                throw new System.ArgumentOutOfRangeException(nameof(n), "n must be >= 0");
            var fact = 1L;  // 0! == 1 by definition
            for (long i = 2; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }


        /// <summary>
        /// Rounds a decimal value to the nearest (up or down) integral value.
        /// </summary>
        /// <param name="d">A number</param>
        /// <returns>The specified number rounded to the nearest (up or down) integral place.</returns>
        public static double Round(double d)
        {
            if ((Abs(d) - (long)Abs(d)) < 0.5D)
            {
                return (double)(long)d;
            }
            else
            {
                return (double)(long)(d >= 0 ? d + 1D : d -1D);
            }
        }


        /// <summary>
        /// Rounds a number to a specified number of fractional digits.
        /// </summary>
        /// <param name="d">A number</param>
        /// <param name="numDigits">number of digits to round to.</param>
        /// <returns>The specified number rounded to a specified number of fractional digits.</returns>
        public static double Round(double d, int numDigits)
        {
            if (numDigits < 0)
                throw new System.ArgumentOutOfRangeException(nameof(numDigits), "Must be >= 0");

            if (d == 0)
                return 0;

            var m = Pow(10, numDigits);
            return Round(d * m) / m;
        }


        /// <summary>
        /// Returns the largest integer less than or equal to the specified number.
        /// </summary>
        /// <param name="d">A number.</param>
        /// <returns>
        /// The largest integer less than or equal to the specified number.
        /// If d is equal to System.Double.NaN, System.Double.NegativeInfinity, or System.Double.PositiveInfinity, then that value is returned.
        /// </returns>
        public static double Floor(double d)
        {
            if (double.IsNaN(d) || double.IsNegativeInfinity(d) || double.IsPositiveInfinity(d))
                return d;

            if (d >= 0)
            {
                // Round down. E.g. Floor(0.8) == 0, Floor(1.8) == 1
                return (double)(long)d;
            }
            else
            {
                // Round down. E.g. Floor(-0.8) == -1, Floor(-1.8) == 2
                return -Ceiling(-d);
            }
        }


        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified number.
        /// </summary>
        /// <param name="d">A number.</param>
        /// <returns>
        /// The smallest integer less than or equal to the specified number.
        /// If d is equal to System.Double.NaN, System.Double.NegativeInfinity, or System.Double.PositiveInfinity, then that value is returned.
        /// </returns>
        public static double Ceiling(double d)
        {
            if (double.IsNaN(d) || double.IsNegativeInfinity(d) || double.IsPositiveInfinity(d))
                return d;

            if (d >= 0)
            {
                // Round up: E.g. Ceiling(0.8) == 1, Ceiling(1.8) == 2
                return ((d - (long)d) > double.Epsilon) ? (double)(long)(d + 1D) : (double)(long)d;
            }
            else
            {
                // Round up: E.g. Ceiling(-0.8) == 0, Ceiling(-1.8) == -1
                return -Floor(-d);
            }
        }


        /// <summary>
        /// Returns a number raised to the power of another number.
        /// </summary>
        /// <param name="x">A number to be raised to a power (mantissa).</param>
        /// <param name="y">A number that specifies a power (exponent).</param>
        /// <returns>x to the power of y</returns>
        public static double Pow(double x, double y)
        {
            var c = System.Math.Pow(x, y);

            // These special cases are taken from the documentation for System.Math.Pow(double, double)
            if (double.IsNaN(x) || double.IsNaN(y))
                return double.NaN;
            if (!double.IsNaN(x) && y == 0)
                return 1D;
            if (double.IsNegativeInfinity(x) && y < 0D)
                return 0D;
            if (double.IsNegativeInfinity(x) && y >= 0 && y.IsOddInteger())
                return double.NegativeInfinity;
            if (double.IsNegativeInfinity(x) && y >= 0 && y.IsEvenInteger())
                return double.PositiveInfinity;
            if (x < 0 && !double.IsNegativeInfinity(x) && !y.IsInteger() && !double.IsNegativeInfinity(y) && !double.IsPositiveInfinity(y))
                return double.NaN;  // Cresult would be complex
            if (x == -1D && (double.IsNegativeInfinity(y) || double.IsPositiveInfinity(y)))
                return double.NaN;
            if (x > -1D && x < 1 && double.IsNegativeInfinity(y))
                return double.PositiveInfinity;
            if (x > -1D && x < 1D && double.IsPositiveInfinity(y))
                return 0D;
            if ((x < -1D && x > 1D) && double.IsNegativeInfinity(y))
                return 0D;
            if ((x < -1D || x > 1D) && double.IsPositiveInfinity(y))
                return double.PositiveInfinity;
            if (x == 0D && y > 0D)
                return 0D;
            if (x == 1D && !double.IsNaN(y))
                return 1D;
            if (double.IsPositiveInfinity(x) && y < 0D)
                return 0D;
            if (double.IsPositiveInfinity(x) && y > 0D)
                return double.PositiveInfinity;

            if (x >= 0)
            {
                if (y >= 0)
                {
                    //       let  m = x^y
                    // therefore  ln(m) = y * ln(x)
                    // therefore  m = exp(y * ln(x)) 
                    var p = Exp(y * Log(x));
                    return p;
                }
                else // y < 0)
                {
                    var p = 1D / Pow(x, -y);
                    return p;
                }
            }
            else // x < 0
            {
                // By preconditions above y must be an integer, otherwise the result would be complex.
                var s = y.IsEvenInteger() ? +1D : -1D;
                var p = s * Pow(-x, y);
                return p;
            }
        }


        /// <summary>
        /// Returns an integer that indicates the sign of a double-precision floating-point number.
        /// </summary>
        /// <param name="d"></param>
        /// <returns>
        /// If d == 0 then returns 0.
        /// if d < 0 then returns -1.
        /// if d > 0 then returns +1.
        /// </returns>
        public static int Sign(double d)
        {
            if (double.IsNaN(d))
                throw new System.ArithmeticException($"{nameof(d)} must be a number");

            if (d < 0D)
                return -1;
            else if (d > 0D)
                return +1;
            else return 0;
        }



        /// <summary>
        /// Returns e raised to the specified power.
        /// </summary>
        /// <param name="d">A number specifying a power.</param>
        /// <returns>
        /// The number e raised to the power d. If d equals NaN or PositiveInfinity, that value is returned.
        /// If d equals NegativeInfinity, 0 is returned.
        /// </returns>
        public static double Exp(double d)
        {
            return System.Math.Exp(d);  // TODO
        }



        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number.
        /// </summary>
        /// <param name="d"></param>
        /// <returns>
        /// If d is positive then returns the natural logarithm of d.
        /// If d is zero then returns NegativeInfinity.
        /// If d is negative then returns NaN.
        /// If d is equal to NaN then returns NaN.
        /// If d is equal to PositiveInfinity then returns PositiveInfinity
        /// </returns>
        public static double Log(double d)
        {
            return System.Math.Log(d);  // TODO
        }



        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="d">An angle in degrees.</param>
        /// <returns>
        /// The equivalent angle in radians.
        /// If d is equal to System.Double.NaN, System.Double.NegativeInfinity, or System.Double.PositiveInfinity, then that value is returned.
        /// </returns>
        public static double DegToRad(double d)
        {
            if (double.IsNaN(d) || double.IsNegativeInfinity(d) || double.IsPositiveInfinity(d))
                return d;

            return d * (Math.PI / deg360Over2);
        }


        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="d">An angle in radians.</param>
        /// <returns>
        /// The equivalent angle in degrees.
        /// If d is equal to System.Double.NaN, System.Double.NegativeInfinity, or System.Double.PositiveInfinity, then that value is returned.
        /// </returns>
        public static double RadToDeg(double d)
        {
            if (double.IsNaN(d) || double.IsNegativeInfinity(d) || double.IsPositiveInfinity(d))
                return d;

            return d * (deg360Over2 / PI);
        }
    }
}
