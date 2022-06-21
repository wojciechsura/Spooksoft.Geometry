using Spooksoft.Geometry.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.TwoDimensional
{
    public record struct FreeRectangle2D
    {
        public FreeRectangle2D(Vector2D topLeft, Vector2D firstVector, Vector2D secondVector)
        {
            if (!firstVector.IsPerpendicularTo(secondVector))
                throw new ArgumentException("Vectors are not perpendicular!");

            TopLeft = topLeft;
            FirstVector = firstVector;
            SecondVector = secondVector;
        }

        public bool IntersectsWith(Vector2D point) => IntersectionTester.CheckIntersection(this, point);

        public bool IntersectsWith(FixedVector2D vector) => IntersectionTester.CheckIntersection(this, vector);

        public Vector2D TopLeft { get; }
        public Vector2D FirstVector { get; }
        public Vector2D SecondVector { get; }
    }
}
