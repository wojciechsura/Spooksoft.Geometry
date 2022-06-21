using Spooksoft.Geometry.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.TwoDimensional
{
    public record struct Rectangle2D(Vector2D TopLeft, Vector2D BottomRight)
    {
        public Rectangle2D(double x1, double y1, double x2, double y2)
            : this(new Vector2D(x1, y1), new Vector2D(x2, y2))
        {

        }

        public bool IntersectsWith(FixedVector2D vector) => IntersectionTester.CheckIntersection(this, vector);

        public bool IntersectsWith(Vector2D point) => IntersectionTester.CheckIntersection(this, point);
    }
}
