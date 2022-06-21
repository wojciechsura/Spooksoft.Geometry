using Spooksoft.Geometry.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.TwoDimensional
{
    public record struct Capsule2D        
    {
        private readonly double radius;
        private readonly FixedVector2D spine;

        public Capsule2D(FixedVector2D spine, double radius)
        {
            if (radius < 0.0)
                throw new ArgumentOutOfRangeException(nameof(radius));

            this.spine = spine;
            this.radius = radius;
        }

        public bool IntersectsWith(Vector2D point) => IntersectionTester.CheckIntersection(this, point);

        public bool IntersectsWith(FixedVector2D vector) => IntersectionTester.CheckIntersection(this, vector);

        public FixedVector2D Spine
        {
            get => spine;
            init => spine = value;
        }

        public double Radius
        {
            get => radius;
            init
            {
                if (value < 0.0)
                    throw new ArgumentOutOfRangeException(nameof(Radius));

                radius = value;
            }
        }
    }
}
