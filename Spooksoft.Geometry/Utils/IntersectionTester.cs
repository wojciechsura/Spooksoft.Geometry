using Spooksoft.Geometry.TwoDimensional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.Utils
{
    internal static class IntersectionTester
    {
        public static bool CheckIntersection(Rectangle2D rectangle, Vector2D point)
        {
            return (point.X >= rectangle.TopLeft.X && point.X <= rectangle.BottomRight.X &&
                point.Y >= rectangle.TopLeft.Y && point.Y <= rectangle.BottomRight.Y);
        }

        /// <remarks>
        /// See https://noonat.github.io/intersect/#aabb-vs-segment
        /// </remarks>
        public static bool CheckIntersection(Rectangle2D rectangle, FixedVector2D vector)
        {
            var delta = vector.SpanningVector;
            var pos = vector.Start;

            var nearTimeX = (rectangle.TopLeft.X - vector.Start.X) / delta.X;
            var farTimeX = (rectangle.BottomRight.X - vector.Start.X) / delta.X;
            var nearTimeY = (rectangle.TopLeft.Y - vector.Start.Y) / delta.Y;
            var farTimeY = (rectangle.BottomRight.Y - vector.Start.Y) / delta.Y;

            (nearTimeX, farTimeX) = nearTimeX < farTimeX ? (nearTimeX, farTimeX) : (farTimeX, nearTimeX);
            (nearTimeY, farTimeY) = nearTimeY < farTimeY ? (nearTimeY, farTimeY) : (farTimeY, nearTimeY);

            if (nearTimeX > farTimeY || nearTimeY > farTimeX)
                return false;

            var nearTime = Math.Max(nearTimeX, nearTimeY);
            var farTime = Math.Min(farTimeX, farTimeY);

            if (nearTime >= 1 || farTime <= 0)
                return false;

            return true;
        }
    }
}
