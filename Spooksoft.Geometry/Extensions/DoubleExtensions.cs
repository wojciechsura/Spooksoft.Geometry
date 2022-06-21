using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.Extensions
{
    public static class DoubleExtensions
    {
        private static readonly double epsilon = 1e-15;

        public static bool IsZero(this double value) => Math.Abs(value) < epsilon;

        public static bool EqualsTo(this double value, double other) => Math.Abs(value - other) < epsilon;
    }
}
