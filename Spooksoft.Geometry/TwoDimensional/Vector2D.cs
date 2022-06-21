using Spooksoft.Geometry.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.TwoDimensional
{
    public record struct Vector2D(double X, double Y)
    {
        // Private methods ----------------------------------------------------

        private double GetAngle()
        {
            var len = Length;
            if (len.IsZero())
                throw new ArithmeticException("Zero vector has no angle!");

            var angle = Math.Acos(Y / len);
            if (X < 0)
                angle = 2 * Math.PI - angle;

            return angle;
        }

        public double DistanceTo(Vector2D point)
        {
            return (point - this).Length;
        }

        public Vector2D WithLength(double length)
        {
            var len = Length;
            if (len.IsZero())
                throw new ArithmeticException("Cannot resize zero vector!");

            return this / len * length;
        }

        public Vector2D ProjectTo(Vector2D other)
        {
            var otherLen = other.Length;
            if (otherLen.IsZero())
                throw new ArithmeticException("Cannot project to zero vector!");

            var t = DotProductWith(other) / other.DotProductWith(other);
            return other * t;
        }

        public Vector2D ProjectTo(FixedVector2D other)
        {
            var shifted = this - other.Start;
            var projected = shifted.ProjectTo(other.SpanningVector);

            return other.Start + projected;
        }

        public double EvalProjectionFactor(FixedVector2D other)
        {
            var shifted = this - other.Start;
            var factor = shifted.EvalProjectionFactor(other.SpanningVector);

            return factor;
        }

        public double EvalProjectionFactor(Vector2D other)
        {
            var otherLen = other.Length;
            if (otherLen.IsZero())
                throw new ArithmeticException("Cannot project to zero vector!");

            return DotProductWith(other) / other.DotProductWith(other);            
        }

        public double DotProductWith(Vector2D other)
        {
            return X * other.X + Y * other.Y;
        }

        public Vector2D Rotate(double angle)
        {
            var cos = Math.Cos(angle);
            var sin = Math.Sin(angle);

            return new(cos * X + sin * Y, - sin * X + cos * Y);
        }

        public override string ToString()
        {
            return $"Vector2D: ({X}; {Y})";
        }

        public bool IsPerpendicularTo(Vector2D secondVector)
        {
            return this.DotProductWith(secondVector).IsZero();
        }

        public static Vector2D operator * (double value, Vector2D vector)
        {
            return new(vector.X * value, vector.Y * value);
        }

        public static Vector2D operator * (Vector2D vector, double value)
        {
            return new(vector.X * value, vector.Y * value);
        }

        public static Vector2D operator / (Vector2D vector, double value)
        {
            return new(vector.X / value, vector.Y / value);
        }

        public static Vector2D operator + (Vector2D first, Vector2D second)
        {
            return new(first.X + second.X, first.Y + second.Y);
        }

        public static Vector2D operator -(Vector2D first, Vector2D second)
        {
            return new(first.X - second.X, first.Y - second.Y);
        }

        // Public properties --------------------------------------------------

        public Vector2D RightNormal => new(Y, -X);

        public Vector2D Unit => WithLength(1.0);

        public double Angle => GetAngle();

        public double Length => Math.Sqrt(X * X + Y * Y);
    }
}
