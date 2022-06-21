using Spooksoft.Geometry.TwoDimensional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.Test
{
    [TestClass]
    public class Capsule2DTests
    {
        [TestMethod]
        public void PointIntersectionTest1()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 0.0), 1);
            var point = new Vector2D(0.0, 0.0);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(point));
        }

        [TestMethod]
        public void PointIntersectionTest2()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 0.0), 1);
            var point = new Vector2D(-0.5, 0.0);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(point));
        }

        [TestMethod]
        public void PointIntersectionTest3()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 0.0), 1);
            var point = new Vector2D(10.5, 0.0);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(point));
        }

        [TestMethod]
        public void PointIntersectionTest4()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 0.0), 1);
            var point = new Vector2D(5.0, 0.5);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(point));
        }

        [TestMethod]
        public void PointIntersectionTest6()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 0.0), 1);
            var point = new Vector2D(3.0, -0.5);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(point));
        }

        [TestMethod]
        public void PointIntersectionTest7()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 0.0), 1);
            var point = new Vector2D(-1.5, 0.0);

            // Assert

            Assert.AreEqual(false, capsule.IntersectsWith(point));
        }

        [TestMethod]
        public void PointIntersectionTest8()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 0.0), 1);
            var point = new Vector2D(10.5, 1.0);

            // Assert

            Assert.AreEqual(false, capsule.IntersectsWith(point));
        }

        [TestMethod]
        public void PointIntersectionTest9()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 0.0), 1);
            var point = new Vector2D(5.0, 1.1);

            // Assert

            Assert.AreEqual(false, capsule.IntersectsWith(point));
        }

        [TestMethod]
        public void PointIntersectionTest10()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 0.0), 1);
            var point = new Vector2D(5.0, -1.1);

            // Assert

            Assert.AreEqual(false, capsule.IntersectsWith(point));
        }

        [TestMethod]
        public void FixedVectorIntersectionTest1()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 10.0), 1.0);
            var vector = new FixedVector2D(-0.2, 0.2, -0.2, 10.0);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(vector));
        }

        [TestMethod]
        public void FixedVectorIntersectionTest2()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 10.0), 1.0);
            var vector = new FixedVector2D(9.8, 10.2, 9.8, 20.0);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(vector));
        }

        [TestMethod]
        public void FixedVectorIntersectionTest3()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 10.0), 1.0);
            var vector = new FixedVector2D(-0.2, -10, -0.2, 0.2);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(vector));
        }

        [TestMethod]
        public void FixedVectorIntersectionTest4()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 10.0), 1.0);
            var vector = new FixedVector2D(9.8, 0.0, 9.8, 10.2);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(vector));
        }

        [TestMethod]
        public void FixedVectorIntersectionTest5()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 10.0), 1.0);
            var vector = new FixedVector2D(-5.1, -5.0, 10.1, 10.0);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(vector));
        }

        [TestMethod]
        public void FixedVectorIntersectionTest6()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 10.0), 1.0);
            var vector = new FixedVector2D(5.1, 5.0, 6.1, 6.0);

            // Assert

            Assert.AreEqual(true, capsule.IntersectsWith(vector));
        }

        [TestMethod]
        public void FixedVectorIntersectionTest7()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 10.0), 1.0);
            var vector = new FixedVector2D(7.0, 4.0, 9.0, 6.0);

            // Assert

            Assert.AreEqual(false, capsule.IntersectsWith(vector));
        }

        [TestMethod]
        public void FixedVectorIntersectionTest8()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 10.0), 1.0);
            var vector = new FixedVector2D(-2.0, 2.0, -1.1, 1.1);

            // Assert

            Assert.AreEqual(false, capsule.IntersectsWith(vector));
        }

        [TestMethod]
        public void FixedVectorIntersectionTest9()
        {
            // Arrange

            var capsule = new Capsule2D(new FixedVector2D(0.0, 0.0, 10.0, 10.0), 1.0);
            var vector = new FixedVector2D(0.0, -2.0, 5.0, -2.0);

            // Assert

            Assert.AreEqual(false, capsule.IntersectsWith(vector));
        }
    }
}
