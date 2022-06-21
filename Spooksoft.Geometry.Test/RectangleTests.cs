using Spooksoft.Geometry.TwoDimensional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.Test
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void IntersectsWithFixedVectorTest1()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new FixedVector2D(-1.0, 1.0, 3.0, 1.0);

            // Assert

            Assert.AreEqual(true, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithFixedVectorTest2()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new FixedVector2D(-1.0, -1.0, 3.0, 3.0);

            // Assert

            Assert.AreEqual(true, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithFixedVectorTest3()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new FixedVector2D(1.0, 1.0, 1.5, 1.5);

            // Assert

            Assert.AreEqual(true, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithFixedVectorTest4()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new FixedVector2D(-1.0, -1.0, -1.0, 3.0);

            // Assert

            Assert.AreEqual(false, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithFixedVectorTest5()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new FixedVector2D(0.0, 3.0, 1.0, 3.0);

            // Assert

            Assert.AreEqual(false, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithFixedVectorTest6()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new FixedVector2D(1.1, -1.1, 3.1, 1.1);

            // Assert

            Assert.AreEqual(false, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithFixedVectorTest7()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new FixedVector2D(1.5, 1.0, 3.0, 1.0);

            // Assert

            Assert.AreEqual(true, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithFixedVectorTest8()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new FixedVector2D(3.0, 1.0, 1.5, 1.0);

            // Assert

            Assert.AreEqual(true, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithPointTest1()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new Vector2D(1.5, 1.5);

            // Assert

            Assert.AreEqual(true, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithPointTest2()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new Vector2D(-1.0, 1.0);

            // Assert

            Assert.AreEqual(false, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithPointTest3()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new Vector2D(1.0, 3.0);

            // Assert

            Assert.AreEqual(false, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithPointTest4()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new Vector2D(3.0, 1.0);

            // Assert

            Assert.AreEqual(false, rect.IntersectsWith(vec));
        }

        [TestMethod]
        public void IntersectsWithPointTest5()
        {
            // Arrange

            var rect = new Rectangle2D(0.0, 0.0, 2.0, 2.0);
            var vec = new Vector2D(1.0, -1.0);

            // Assert

            Assert.AreEqual(false, rect.IntersectsWith(vec));
        }

    }
}
