using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace uk.andyjohnson.MathsLib
{
    /// <summary>
    /// Extension methods for System.Double
    /// </summary>
    internal static class DoubleExt
    {
        public static bool IsInteger(this double d)
        {
            return (d % 1 == 0);
        }


        public static bool IsEvenInteger(this double d)
        {
            return d.IsInteger() && (d % 2 == 0);
        }


        public static bool IsOddInteger(this double d)
        {
            return d.IsInteger() && (d % 2 == 1);
        }
    }
}
