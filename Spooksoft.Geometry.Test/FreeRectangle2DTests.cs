using Spooksoft.Geometry.TwoDimensional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.Test
{
    [TestClass]
    public class FreeRectangle2DTests
    {
        [TestMethod]
        public void IntersectionTest1()
        {
            // Arrange

            var rect = new FreeRectangle2D(new Vector2D(-1.0, 0.0),
                new Vector2D(1.0, 1.0),
                new Vector2D(1.0, -1.0));
            var point = new Vector2D(0.0, 0.0);

            // Assert

            Assert.AreEqual(true, rect.IntersectsWith(point));
        }

        [TestMethod]
        public void IntersectionTest2()
        {
            // Arrange

            var rect = new FreeRectangle2D(new Vector2D(-1.0, 0.0),
                new Vector2D(1.0, 1.0),
                new Vector2D(1.0, -1.0));
            var point = new Vector2D(0.0, 0.9);

            // Assert

            Assert.AreEqual(true, rect.IntersectsWith(point));
        }

        [TestMethod]
        public void IntersectionTest3()
        {
            // Arrange

            var rect = new FreeRectangle2D(new Vector2D(-1.0, 0.0),
                new Vector2D(1.0, 1.0),
                new Vector2D(1.0, -1.0));
            var point = new Vector2D(0.9, 0.0);

            // Assert

            Assert.AreEqual(true, rect.IntersectsWith(point));
        }

        [TestMethod]
        public void IntersectionTest4()
        {
            // Arrange

            var rect = new FreeRectangle2D(new Vector2D(-1.0, 0.0),
                new Vector2D(1.0, 1.0),
                new Vector2D(1.0, -1.0));
            var point = new Vector2D(-1.1, 0.0);

            // Assert

            Assert.AreEqual(false, rect.IntersectsWith(point));
        }

        [TestMethod]
        public void IntersectionTest5()
        {
            // Arrange

            var rect = new FreeRectangle2D(new Vector2D(-1.0, 0.0),
                new Vector2D(1.0, 1.0),
                new Vector2D(1.0, -1.0));
            var point = new Vector2D(0.6, 0.6);

            // Assert

            Assert.AreEqual(false, rect.IntersectsWith(point));
        }

        [TestMethod]
        public void IntersectionTest6()
        {
            // Arrange

            var rect = new FreeRectangle2D(new Vector2D(-1.0, 0.0),
                new Vector2D(1.0, 1.0),
                new Vector2D(1.0, -1.0));
            var point = new Vector2D(0.0, 1.1);

            // Assert

            Assert.AreEqual(false, rect.IntersectsWith(point));
        }
    }
}
