using Spooksoft.Geometry.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooksoft.Geometry.Test
{
    [TestClass]
    public class MathToolsTests
    {
        [TestMethod]
        public void SolveTest1()
        {
            // Act

            // 2 * 8 + 3 * 5 = 31
            // 1 * 8 - 2 * 5 = -2

            (double x1, double x2) = MathTools.Solve(2.0, 3.0, 31.0, 1.0, -2.0, -2.0);

            // Assert

            Assert.AreEqual(8.0, x1, Constants.DoubleEpsilon);
            Assert.AreEqual(5.0, x2, Constants.DoubleEpsilon);
        }

        [TestMethod]
        public void SolveTest2()
        {
            // Act

            // 1 * 4 - 1 * 4 = 0
            // 2 * 4 - 2 * 4 = 0

            (double x1, double x2) = MathTools.Solve(1.0, -1.0, 0.0, 2.0, -2.0, 0.0);

            // Assert

            Assert.IsTrue(double.IsPositiveInfinity(x1));
            Assert.IsTrue(double.IsPositiveInfinity(x2));            
        }

        [TestMethod]
        public void SolveTest3()
        {
            // Act

            // 1 + 1 = 2
            // 1 + 1 != 3

            (double x1, double x2) = MathTools.Solve(1.0, 1.0, 2.0, 1.0, 1.0, 3.0);

            Assert.IsTrue(double.IsNaN(x1));
            Assert.IsTrue(double.IsNaN(x2));
        }
    }
}
