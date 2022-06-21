using Spooksoft.Geometry.TwoDimensional;

namespace Spooksoft.Geometry.Test
{
    [TestClass]
    public class Vector2DTests
    {
        [TestMethod]
        public void LengthTest1()
        {
            // Arrange

            var vec = new Vector2D(0.0, 1.0);

            // Assert

            Assert.AreEqual(vec.Length, 1.0, 0.1);
        }

        [TestMethod]
        public void LengthTest2()
        {
            // Arrange

            var vec = new Vector2D(1.0, 0.0);

            // Assert

            Assert.AreEqual(vec.Length, 1.0, 0.1);
        }

        [TestMethod]
        public void LengthTest3()
        {
            // Arrange

            var vec = new Vector2D(1.0, 1.0);

            // Assert

            Assert.AreEqual(vec.Length, 1.4142, 0.0001);
        }

        [TestMethod]
        public void AngleTest1()
        {
            // Arrange

            var vec = new Vector2D(0.0, 1.0);

            // Assert

            Assert.AreEqual(vec.Angle, 0.0, 0.1);
        }

        [TestMethod]
        public void AngleTest2()
        {
            // Arrange

            var vec = new Vector2D(1.0, 0.0);

            // Assert

            Assert.AreEqual(vec.Angle, Math.PI / 2, 0.1);
        }

        [TestMethod]
        public void AngleTest3()
        {
            // Arrange

            var vec = new Vector2D(1.0, 1.0);

            // Assert

            Assert.AreEqual(vec.Angle, Math.PI / 4, 0.1);
        }

        [TestMethod]
        public void AngleTest4()
        {
            // Arrange

            var vec = new Vector2D(-1.0, -1.0);

            // Assert

            Assert.AreEqual(vec.Angle, 5 * Math.PI / 4, 0.1);
        }

        [TestMethod]
        public void AngleTest5()
        {
            // Arrange

            var vec = new Vector2D(-1.0, 1.0);

            // Assert

            Assert.AreEqual(vec.Angle, 7 * Math.PI / 4, 0.1);
        }

        [TestMethod]
        public void WithLengthTest1()
        {
            // Arrange

            var vec = new Vector2D(3.0, 4.0);

            // Act

            var angle = vec.Angle;
            var newVec = vec.WithLength(10.0);

            // Assert

            Assert.AreEqual(10.0, newVec.Length, Constants.DoubleEpsilon);
            Assert.AreEqual(angle, newVec.Angle, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void WithLengthTest2()
        {
            // Arrange

            var vec = new Vector2D(9.0, -5.0);

            // Act

            var angle = vec.Angle;
            var newVec = vec.WithLength(10.0);

            // Assert

            Assert.AreEqual(10.0, newVec.Length, Constants.DoubleEpsilon);
            Assert.AreEqual(angle, newVec.Angle, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void WithLengthTest3()
        {
            // Arrange

            var vec = new Vector2D(-8.0, -12.0);

            // Act

            var angle = vec.Angle;
            var newVec = vec.WithLength(10.0);

            // Assert

            Assert.AreEqual(10.0, newVec.Length, Constants.DoubleEpsilon);
            Assert.AreEqual(angle, newVec.Angle, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void ToUnitVectorTest1()
        {
            // Arrange

            var vec = new Vector2D(1.0, 9.0);

            // Act

            var unit = vec.Unit;

            // Assert

            Assert.AreEqual(1.0, unit.Length, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void ProjectToTest1()
        {
            // Arrange

            var vec1 = new Vector2D(1.0, 1.0);
            var vec2 = new Vector2D(2.0, 0.0);

            // Act

            var vec3 = vec1.ProjectTo(vec2);

            // Assert

            Assert.AreEqual(1.0, vec3.X, Constants.DoubleEpsilon);
            Assert.AreEqual(0.0, vec3.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void ProjectToTest2()
        {
            // Arrange

            var vec1 = new Vector2D(2.0, 0.0);
            var vec2 = new Vector2D(1.0, 1.0);

            // Act

            var vec3 = vec1.ProjectTo(vec2);

            // Assert

            Assert.AreEqual(1.0, vec3.X, Constants.DoubleEpsilon);
            Assert.AreEqual(1.0, vec3.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void ProjectToTest3()
        {
            // Arrange

            var vec1 = new Vector2D(1.0, 2.0);
            var vec2 = new FixedVector2D(1.0, 1.0, 2.0, 2.0);

            // Act

            var vec3 = vec1.ProjectTo(vec2);

            // Assert

            Assert.AreEqual(1.5, vec3.X, Constants.DoubleEpsilon);
            Assert.AreEqual(1.5, vec3.Y, Constants.DoubleEpsilon);
        }
        

        [TestMethod]
        public void ProjectionFactorTest1()
        {
            // Arrange

            var vec1 = new Vector2D(1.0, 1.0);
            var vec2 = new Vector2D(2.0, 0.0);

            // Act

            double fac = vec1.EvalProjectionFactor(vec2);

            // Assert

            Assert.AreEqual(0.5, fac, Constants.DoubleEpsilon);            
        }

        [TestMethod]
        public void ProjectionFactorTest2()
        {
            // Arrange

            var vec1 = new Vector2D(2.0, 0.0);
            var vec2 = new Vector2D(1.0, 1.0);

            // Act

            var fac = vec1.EvalProjectionFactor(vec2);

            // Assert

            Assert.AreEqual(1.0, fac, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void ProjectionFactorTest3()
        {
            // Arrange

            var vec1 = new Vector2D(1.0, 2.0);
            var vec2 = new FixedVector2D(1.0, 1.0, 2.0, 2.0);

            // Act

            var fac = vec1.EvalProjectionFactor(vec2);

            // Assert

            Assert.AreEqual(0.5, fac, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void AddTest()
        {
            // Arrange

            var vec1 = new Vector2D(2.0, 5.0);
            var vec2 = new Vector2D(8.0, 3.0);

            // Act

            var vec3 = vec1 + vec2;

            // Assert

            Assert.AreEqual(10.0, vec3.X, Constants.DoubleEpsilon);
            Assert.AreEqual(8.0, vec3.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void SubtractTest()
        {
            // Arrange

            var vec1 = new Vector2D(2.0, 5.0);
            var vec2 = new Vector2D(8.0, 3.0);

            // Act

            var vec3 = vec1 - vec2;

            // Assert

            Assert.AreEqual(-6.0, vec3.X, Constants.DoubleEpsilon);
            Assert.AreEqual(2.0, vec3.Y, Constants.DoubleEpsilon);        
        }

        [TestMethod]
        public void MultiplyTest1()
        {
            // Arrange

            var vec1 = new Vector2D(2.0, 5.0);

            // Act

            var vec2 = vec1 * 1.5;

            // Assert

            Assert.AreEqual(3.0, vec2.X, Constants.DoubleEpsilon);
            Assert.AreEqual(7.5, vec2.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void MultiplyTest2()
        {
            // Arrange

            var vec1 = new Vector2D(2.0, 5.0);

            // Act

            var vec2 = 1.5 * vec1;

            // Assert

            Assert.AreEqual(3.0, vec2.X, Constants.DoubleEpsilon);
            Assert.AreEqual(7.5, vec2.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void DivideTest()
        {
            // Arrange

            var vec1 = new Vector2D(2.0, 5.0);

            // Act

            var vec2 = vec1 / 2.0;

            // Assert

            Assert.AreEqual(1.0, vec2.X, Constants.DoubleEpsilon);
            Assert.AreEqual(2.5, vec2.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void DotProductWithTest1()
        {
            // Arrange

            var vec1 = new Vector2D(2.0, 5.0);
            var vec2 = new Vector2D(8.0, 3.0);

            // Act

            var product = vec1.DotProductWith(vec2);

            // Assert

            Assert.AreEqual(31.0, product, Constants.DoubleEpsilon);           
        }

        [TestMethod]
        public void ToRightNormal1Test()
        {
            // Arrange

            var vec = new Vector2D(2.0, 5.0);

            // Act

            var normal = vec.RightNormal;

            // Assert

            Assert.AreEqual(5.0, normal.X, Constants.DoubleEpsilon);
            Assert.AreEqual(-2.0, normal.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void ToRightNormal2Test()
        {
            // Arrange

            var vec = new Vector2D(-1.0, -1.0);

            // Act

            var normal = vec.RightNormal;

            // Assert

            Assert.AreEqual(-1.0, normal.X, Constants.DoubleEpsilon);
            Assert.AreEqual(1.0, normal.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void RotateTest1()
        {
            // Arrange

            var vec = new Vector2D(1.0, 1.0);

            // Act

            var rotated = vec.Rotate(Math.PI / 2.0);

            // Assert

            Assert.AreEqual(1.0, rotated.X, Constants.DoubleEpsilon);
            Assert.AreEqual(-1.0, rotated.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void RotateTest2()
        {
            // Arrange

            var vec = new Vector2D(1.0, 0.0);

            // Act

            var rotated = vec.Rotate(-Math.PI / 4.0);

            // Assert

            Assert.AreEqual(Math.Sqrt(2.0) / 2.0, rotated.X, Constants.DoubleEpsilon);
            Assert.AreEqual(Math.Sqrt(2.0) / 2.0, rotated.Y, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void DistanceToTest()
        {
            // Arrange

            var vec1 = new Vector2D(1.0, 1.0);
            var vec2 = new Vector2D(2.0, 2.0);

            // Act

            double dist = vec1.DistanceTo(vec2);

            // Assert

            Assert.AreEqual(Math.Sqrt(2), dist, Constants.DoubleEpsilon);
        }
    }
}