using Spooksoft.Geometry.TwoDimensional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.Test
{
    [TestClass]
    public class Ray2DTests
    {
        [TestMethod]
        public void FixedVectorIntersectionTest1()
        {
            // Arrange
            var ray = new Ray2D(new Vector2D(0.0, 0.0), new Vector2D(1.0, 0.0));
            var vector = new FixedVector2D(2.0, 1.0, 2.0, -1.0);

            // Act
            (bool intersects, Vector2D? intersectionPoint) = ray.IntersectsWith(vector);

            // Assert
            Assert.IsTrue(intersects);
            Assert.IsNotNull(intersectionPoint);
            Assert.AreEqual(2.0, intersectionPoint.Value.X, Constants.DoubleEpsilon);
            Assert.AreEqual(0.0, intersectionPoint.Value.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void FixedVectorIntersectionTest2()
        {
            // Arrange
            var ray = new Ray2D(new Vector2D(0.0, 0.0), new Vector2D(-1.0, 0.0));
            var vector = new FixedVector2D(2.0, 1.0, 2.0, -1.0);

            // Act
            (bool intersects, Vector2D? intersectionPoint) = ray.IntersectsWith(vector);

            // Assert
            Assert.IsFalse(intersects);
            Assert.IsNull(intersectionPoint);
        }

        [TestMethod]
        public void FixedVectorIntersectionTest3()
        {
            // Arrange
            var ray = new Ray2D(new Vector2D(0.0, 0.0), new Vector2D(1.0, 0.0));
            var vector = new FixedVector2D(0.0, 1.0, 2.0, 1.0);

            // Act
            (bool intersects, Vector2D? intersectionPoint) = ray.IntersectsWith(vector);

            // Assert
            Assert.IsFalse(intersects);
            Assert.IsNull(intersectionPoint);
        }

        [TestMethod]
        public void FixedVectorIntersectionTest4()
        {
            // Arrange
            var ray = new Ray2D(new Vector2D(0.0, 0.0), new Vector2D(1.0, 0.0));
            var vector = new FixedVector2D(0.0, 0.0, 2.0, 0.0);

            // Act
            (bool intersects, Vector2D? intersectionPoint) = ray.IntersectsWith(vector);

            // Assert
            Assert.IsTrue(intersects);
            Assert.IsNull(intersectionPoint);
        }

        [TestMethod]
        public void FixedVectorIntersectionTest5()
        {
            // Arrange
            var ray = new Ray2D(new Vector2D(0.0, 0.0), new Vector2D(1.0, 1.0));
            var vector = new FixedVector2D(0.0, 5.0, 5.0, 0.0);

            // Act
            (bool intersects, Vector2D? intersectionPoint) = ray.IntersectsWith(vector);

            // Assert
            Assert.IsTrue(intersects);
            Assert.IsNotNull(intersectionPoint);
            Assert.AreEqual(2.5, intersectionPoint.Value.X, Constants.DoubleEpsilon);
            Assert.AreEqual(2.5, intersectionPoint.Value.Y, Constants.DoubleEpsilon);
        }
    }
}
