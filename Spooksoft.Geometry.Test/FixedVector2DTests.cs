﻿using Spooksoft.Geometry.TwoDimensional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.Test
{
    [TestClass]
    public class FixedVector2DTests
    {
        [TestMethod]
        public void LengthTest1()
        {
            // Arrange

            var vec = new FixedVector2D(new Vector2D(1.0, 1.0), new Vector2D(2.0, 2.0));

            // Assert

            Assert.AreEqual(Math.Sqrt(2.0), vec.Length, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void AddTest1()
        {
            // Arrange

            var vec1 = new FixedVector2D(new Vector2D(1.0, 2.0), new Vector2D(3.0, 4.0));
            var vec2 = new Vector2D(5.0, 7.0);

            // Act

            var vec3 = vec1 + vec2;

            // Assert

            Assert.AreEqual(6.0, vec3.Start.X, Constants.DoubleEpsilon);
            Assert.AreEqual(9.0, vec3.Start.Y, Constants.DoubleEpsilon);
            Assert.AreEqual(8.0, vec3.End.X, Constants.DoubleEpsilon);
            Assert.AreEqual(11.0, vec3.End.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void SubtractTest1()
        {
            // Arrange

            var vec1 = new FixedVector2D(new Vector2D(1.0, 2.0), new Vector2D(3.0, 4.0));
            var vec2 = new Vector2D(5.0, 7.0);

            // Act

            var vec3 = vec1 - vec2;

            // Assert

            Assert.AreEqual(-4.0, vec3.Start.X, Constants.DoubleEpsilon);
            Assert.AreEqual(-5.0, vec3.Start.Y, Constants.DoubleEpsilon);
            Assert.AreEqual(-2.0, vec3.End.X, Constants.DoubleEpsilon);
            Assert.AreEqual(-3.0, vec3.End.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void SpanningVectorTest()
        {
            // Arrange

            var vec = new FixedVector2D(1.0, 3.0, 5.0, 9.0);

            // Act

            var spanning = vec.SpanningVector;

            // Assert

            Assert.AreEqual(4.0, spanning.X, Constants.DoubleEpsilon);
            Assert.AreEqual(6.0, spanning.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void RotateAroundStartTest()
        {
            // Arrange

            var vec1 = new FixedVector2D(1.0, 2.0, 3.0, 4.0);

            // Act

            var vec2 = vec1.RotateAroundStart(Math.PI / 2.0);

            // Assert

            Assert.AreEqual(1.0, vec2.Start.X, Constants.DoubleEpsilon);
            Assert.AreEqual(2.0, vec2.Start.Y, Constants.DoubleEpsilon);
            Assert.AreEqual(3.0, vec2.End.X, Constants.DoubleEpsilon);
            Assert.AreEqual(0.0, vec2.End.Y, Constants.DoubleEpsilon);
        }
    }
}
