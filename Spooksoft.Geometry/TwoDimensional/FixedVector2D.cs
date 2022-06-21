using Spooksoft.Geometry.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.TwoDimensional
{
    public record struct FixedVector2D(Vector2D Start, Vector2D End)
    {
        public FixedVector2D(double x1, double y1, double x2, double y2)
            : this(new Vector2D(x1, y1), new Vector2D(x2, y2))
        {

        }

        public FixedVector2D RotateAroundStart(double angle)
        {
            var newEnd = Start + SpanningVector.Rotate(angle);
            return new(Start, newEnd);
        }

        public bool IntersectsWith(Rectangle2D rectangle) => IntersectionTester.CheckIntersection(rectangle, this);

        public bool IntersectsWith(FixedVector2D vector) => IntersectionTester.CheckIntersection(this, vector);

        public static FixedVector2D operator + (FixedVector2D vec1, Vector2D vec2)
        {
            return new(vec1.Start + vec2, vec1.End + vec2);
        }

        public static FixedVector2D operator - (FixedVector2D vec1, Vector2D vec2)
        {
            return new(vec1.Start - vec2, vec1.End - vec2);
        }        

        public double Length => Math.Sqrt(Math.Pow(End.X - Start.X, 2.0) + Math.Pow(End.Y - Start.Y, 2.0));

        public Vector2D SpanningVector => new(End.X - Start.X, End.Y - Start.Y);
    }
}
