using Spooksoft.Geometry.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.TwoDimensional
{
    public record struct Ray2D(Vector2D Origin, Vector2D Direction)
    {
        public (bool intersects, Vector2D? pointOfIntersection) IntersectsWith(FixedVector2D vector) => IntersectionTester.CheckIntersection(this, vector);
    }
}
