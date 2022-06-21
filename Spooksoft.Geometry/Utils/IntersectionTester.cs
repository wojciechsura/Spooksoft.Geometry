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

        public static bool CheckIntersection(Capsule2D capsule2D, Vector2D point)
        {
            // Point within radius of one of capsule endpoints - there is intersection
            if (point.DistanceTo(capsule2D.Spine.Start) <= capsule2D.Radius ||
                point.DistanceTo(capsule2D.Spine.End) <= capsule2D.Radius)
                return true;

            var factor = point.EvalProjectionFactor(capsule2D.Spine);

            // Projection of point outside capsule spaning vector (plus previous
            // condition not met) - no intersection
            if (factor < 0 || factor > 1)
                return false;

            var projected = capsule2D.Spine.Start + factor * capsule2D.Spine.SpanningVector;

            // Projection within capsule spanning vector and distance from
            // point to the capsule's spanning vector smaller or equal to radius
            // - there is an intersection
            if (point.DistanceTo(projected) <= capsule2D.Radius)
                return true;

            // In all other cases, there is no intersection
            return false;
        }

        public static bool CheckIntersection(FreeRectangle2D freeRectangle2D, FixedVector2D vector)
        {
            // Simplest case: one of segment's ends are inside the rectangle
            if (CheckIntersection(freeRectangle2D, vector.Start) || CheckIntersection(freeRectangle2D, vector.End))
                return true;

            // Otherwise we're checking for segment intersection

            if (new FixedVector2D(freeRectangle2D.TopLeft, freeRectangle2D.TopLeft + freeRectangle2D.FirstVector).IntersectsWith(vector))
                return true;

            if (new FixedVector2D(freeRectangle2D.TopLeft, freeRectangle2D.TopLeft + freeRectangle2D.SecondVector).IntersectsWith(vector))
                return true;

            if (new FixedVector2D(freeRectangle2D.TopLeft + freeRectangle2D.FirstVector, 
                freeRectangle2D.TopLeft + freeRectangle2D.FirstVector + freeRectangle2D.SecondVector).IntersectsWith(vector))
                return true;

            if (new FixedVector2D(freeRectangle2D.TopLeft + freeRectangle2D.SecondVector,
                freeRectangle2D.TopLeft + freeRectangle2D.FirstVector + freeRectangle2D.SecondVector).IntersectsWith(vector))
                return true;

            return false;
        }

        public static bool CheckIntersection(Capsule2D capsule2D, FixedVector2D vector)
        {
            var startProjectionFactor = capsule2D.Spine.Start.EvalProjectionFactor(vector);
            if (startProjectionFactor >= 0.0 && startProjectionFactor <= 1.0)
            {
                var startProjection = vector.Start + vector.SpanningVector * startProjectionFactor;
                
                // Segment intersects circle around capsule start point
                if ((startProjection - capsule2D.Spine.Start).Length <= capsule2D.Radius)
                    return true;
            }

            var endProjectionFactor = capsule2D.Spine.End.EvalProjectionFactor(vector);
            if (endProjectionFactor >= 0.0 && endProjectionFactor <= 1.0)
            {
                var endProjection = vector.Start + vector.SpanningVector * endProjectionFactor;

                // Segment intersects circle around capsule end point
                if ((endProjection - capsule2D.Spine.End).Length <= capsule2D.Radius)
                    return true;
            }

            // Now check segment/free rectangle intersection

            var capsuleNormal = capsule2D.Spine.SpanningVector.RightNormal.Unit * capsule2D.Radius;
            
            var rectTopLeft = capsule2D.Spine.Start - capsuleNormal;
            var rectVector1 = capsule2D.Spine.SpanningVector;
            var rectVector2 = 2 * capsuleNormal;

            var rectangle = new FreeRectangle2D(rectTopLeft, rectVector1, rectVector2);
            return rectangle.IntersectsWith(vector);            
        }

        public static bool CheckIntersection(FreeRectangle2D rectangle, Vector2D point)
        {
            // P + t * V1 + s * V2 = point
            // t * V1 + s * V2 = point - P

            var c = point - rectangle.TopLeft;

            (double t, double s) = MathTools.Solve(rectangle.FirstVector.X, rectangle.SecondVector.X, c.X,
                rectangle.FirstVector.Y, rectangle.SecondVector.Y, c.Y);

            if (double.IsNaN(t) || double.IsNaN(s) || double.IsPositiveInfinity(t) || double.IsPositiveInfinity(s))
                return false;

            return (t >= 0.0 && t <= 1.0 && s >= 0.0 && s <= 1.0);
        }

        public static bool CheckIntersection(FixedVector2D first, FixedVector2D second)
        {
            var A1 = first.Start;
            var D1 = first.SpanningVector;

            var A2 = second.Start;
            var D2 = second.SpanningVector;

            // A1 + t1 * D1 = A2 + t2 * D2
            // t1 * D1 - t2 * D2 = A2 - A1

            (double t1, double t2) = MathTools.Solve(D1.X, -D2.X, (A2.X - A1.X), D1.Y, -D2.Y, (A2.Y - A1.Y));

            // One of spanning vectors is zero
            if (double.IsNaN(t1) || double.IsNaN(t2))
                return false;

            // Segments are colinnear
            if (double.IsPositiveInfinity(t1) || double.IsPositiveInfinity(t2))
            {
                double deltaX = first.SpanningVector.X;
                double deltaY = first.SpanningVector.Y;

                // Now we express coordinates of vectors as multiplications of deltaX.
                // First vector is obviously 0 and 1, check the second one

                double secondVectorStart, secondVectorEnd;
                
                // Pick the axis, which has bigger delta (more accurate calculations)
                if (Math.Abs(deltaX) > Math.Abs(deltaY))
                {
                    secondVectorStart = (second.Start.X - first.Start.X) / deltaX;
                    secondVectorEnd = (second.End.X - first.Start.X) / deltaX;

                }
                else
                {
                    secondVectorStart = (second.Start.Y - first.Start.Y) / deltaY;
                    secondVectorEnd = (second.End.Y - first.Start.Y) / deltaY;
                }

                // Sort start and end in ascending order
                (secondVectorStart, secondVectorEnd) = secondVectorStart < secondVectorEnd ? (secondVectorStart, secondVectorEnd) : (secondVectorEnd, secondVectorStart);

                // Remember that in units of delta (deltaX or deltaY regardless)
                // First vector has coordinates of (0.0, 1.0). Now we only need
                // to check if those two ranges overlap.
                return (secondVectorStart <= 1.0 && secondVectorEnd >= 0.0);
            }

            return (t1 >= 0.0 && t1 <= 1.0 && t2 >= 0.0 && t2 <= 1.0);
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
