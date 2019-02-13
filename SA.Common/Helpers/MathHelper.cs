using System;

namespace SA.Common.Helpers
{
    public class MathHelper
    {
        public const double DoublePrecision = .00001;

        public static bool DoubleAreEqual(double? a, double? b)
        {
            if (a.HasValue && !b.HasValue)
                return false;

            if (b.HasValue && !a.HasValue)
                return false;

            if (!a.HasValue && !b.HasValue)
                return true;

            return Math.Abs(a.Value - b.Value) <= DoublePrecision;
        }
    }
}
