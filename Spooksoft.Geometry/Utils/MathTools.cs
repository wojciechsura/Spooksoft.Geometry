using Spooksoft.Geometry.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.Utils
{
    public static class MathTools
    {
        public static (double x1, double x2) Solve(double a1, double b1, double c1, double a2, double b2, double c2)
        {
            var det = a1 * b2 - a2 * b1;

            var det1 = c1 * b2 - c2 * b1;
            var det2 = a1 * c2 - a2 * c1;

            if (det.IsZero())
            {
                if (det1.IsZero() && det2.IsZero())
                    return (double.PositiveInfinity, double.PositiveInfinity);
                else
                    return (double.NaN, double.NaN);
            }

            return (det1 / det, det2 / det);
        }
    }
}
